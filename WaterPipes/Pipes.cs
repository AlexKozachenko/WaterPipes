﻿// загрузка на mystat
using System;
using System.Threading;

namespace WaterPipes
{
    public delegate void Operation(int y, int x);
    
    internal class Pipes
    {
        // к каждой размерности поля из задания прибавляется 2 за счет рамки
        private const int fieldHeight = 17;
        private const int fieldWidth = 32;
        private const int speed = 400;
        private Cell[,] bufferField = new Cell[fieldHeight, fieldWidth];
        // координаты начальной точки (верхний левый угол поля) с учетом счетчика шагов и рамки
        private int cellAbscissaX = 1;
        private int cellOrdinateY = 2;
        private Cell[,] field = new Cell[fieldHeight, fieldWidth];
        private Operation lambda;
        private int step = 0;

        public Pipes()
        {
            InitializeField(field);
            InitializeField(bufferField);
        }

        public Cell[,] BufferField
        {
            get => bufferField;
        }

        public int CellAbscissaX
        {
            get => cellAbscissaX;
            set => cellAbscissaX = value;
        }

        public int CellOrdinateY
        {
            get => cellOrdinateY;
            set => cellOrdinateY = value;
        }

        public Cell[,] Field
        {
            get => field;
        }

        public int FieldHeight
        {
            get => fieldHeight;
        }

        public int FieldWidth
        {
            get => fieldWidth;
        }

        public static void ManualInput(Pipes pipes)
        {
            do
            {
                const char accentuationLetter = 'X';
                Console.CursorVisible = false;
                pipes.PrintField();
                Console.SetCursorPosition(pipes.CellAbscissaX, pipes.CellOrdinateY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(accentuationLetter);
                Console.ResetColor();
                Console.SetCursorPosition(pipes.CellAbscissaX, pipes.CellOrdinateY);
                ICommand useKey = new KeyRead(Console.ReadKey().Key, pipes);
                useKey.Execute();
            } while (KeyRead.Exit);
        }

        private void Bypass(int y, int x, Operation operation)
        {   // число измерений игрового пространства - 2
            const int dimensions = 2;
            // максимальное число соседних ячеек без учета диагоналей равно 4
            const int maxCountOfNeighborCells = 4;
            // создаем двумерный массив для хранения координат соседних ячеек
            // абсциссы хранятся в строке 0
            const int xBuffer = 0;
            // ординаты хранятся в строке 1
            const int yBuffer = 1;
            ///*int */emptyNeighborCells = 0;
            int neighborCellIndex = 0;
            // двумерный массив для хранения координат соседних ячеек
            int[,] neighborCells = new int[maxCountOfNeighborCells, dimensions];
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if ((i == y && j == x - 1)
                        || (i == y && j == x + 1)
                        || (i == y - 1 && j == x)
                        || (i == y + 1 && j == x))
                    {
                        neighborCells[neighborCellIndex, yBuffer] = i;
                        neighborCells[neighborCellIndex, xBuffer] = j;
                        neighborCellIndex++;
                    }
                }
            }
            for (int i = 0; i < maxCountOfNeighborCells; i++)
            {
                if ((neighborCells[i, xBuffer] < 1) || (neighborCells[i, yBuffer] < 1))
                {
                    continue;
                }
                if ((neighborCells[i, xBuffer] > fieldWidth - 1) || (neighborCells[i, yBuffer] > fieldHeight - 1))
                {
                    continue;
                }
                operation.Invoke(neighborCells[i, yBuffer], neighborCells[i, xBuffer]);
            }
        }

        private bool CompareFields(Cell[,] field1, Cell[,] field2)
        {
            bool isEqual = true;
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    if ((field1[i, j].Color != field2[i, j].Color)
                        || (field1[i, j].IsActive != field2[i, j].IsActive)
                        || (field1[i, j].IsFull != field2[i, j].IsFull)
                        || (field1[i, j].Letter != field2[i, j].Letter))
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            return isEqual;
        }

        public void CopyField(Cell[,] source, Cell[,] destination)
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    destination[i, j].Color = source[i, j].Color;
                    destination[i, j].IsActive = source[i, j].IsActive;
                    destination[i, j].IsFull = source[i, j].IsFull;
                    destination[i, j].Letter = source[i, j].Letter;
                }
            }
        }

        public int CountActiveNeighbours(int y, int x)
        {
            int activeNeighbors = 0;
            lambda = (ordinate, abscissa) =>
            {
                if (field[ordinate, abscissa].IsActive)
                {
                    activeNeighbors++;
                }
            };
            Bypass(y, x, lambda);
            return activeNeighbors;
        }

        public int CountActives()
        {
            int activeCells = 0;
            for (int i = 1; i < fieldHeight - 1; i++)
            {
                for (int j = 1; j < fieldWidth - 1; j++)
                {
                    if (bufferField[i, j].IsActive)
                    {
                        activeCells++;
                    }
                }
            }
            return activeCells;
        }

        public int CountFilled()
        {
            int fullCells = 0;
            for (int i = 1; i < FieldHeight - 1; i++)
            {
                for (int j = 1; j < FieldWidth - 1; j++)
                {
                    if (BufferField[i, j].IsFull)
                    {
                        fullCells++;
                    }
                }
            }
            return fullCells;
        }

        public void Game()
        {
            do
            {
                Thread.Sleep(speed);
                CopyField(field, bufferField);
                PrintField();
                Filling();
                step++;
            } while (!CompareFields(field, bufferField));
        }

        public void InitializeField(Cell[,] field)
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    field[i, j] = new Cell();
                }
            }
        }

        private void Filling()
        {
            for (int i = 1; i < fieldHeight - 1; i++)
            {
                for (int j = 1; j < fieldWidth - 1; j++)
                {
                    if (bufferField[i, j].IsFull)
                    {
                        lambda = (ordinate, abscissa) =>
                        {
                            if ((!field[ordinate, abscissa].IsFull) && (field[ordinate, abscissa].IsActive))
                            {
                                field[ordinate, abscissa] = new FilledPipeCell();
                            }
                        };
                        Bypass(i, j, lambda);
                    }
                }
            }
        }

        private void PrintField()
        {
            const char frameElement = '+';
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Step: ");
            Console.SetCursorPosition("Step: ".Length, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(step);
            Console.Write('\n');
            Console.ResetColor();
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    if ((i == 0) || (j == 0) || (j == fieldWidth - 1) || (i == fieldHeight - 1))
                    {
                        Console.Write(frameElement);
                    }
                    else
                    {
                        Console.SetCursorPosition(j, i + 1);
                        Console.ForegroundColor = field[i, j].Color;
                        Console.Write(field[i, j].Letter);
                        Console.ResetColor();
                    }
                }
                Console.Write('\n');
            }
        }

        public void Test()
        {
            do
            {
                CopyField(Field, BufferField);
                Filling();
            } while (!CompareFields(field, bufferField));
        }

        public void TestClear()
        {
            for (int i = 1; i < FieldHeight - 1; i++)
            {
                for (int j = 1; j < FieldWidth - 1; j++)
                {
                    if ((Field[i, j].IsFull) && (Field[i, j].Letter != 'S'))
                    {
                        Field[i, j] = new PipeCell();
                    }
                }
            }
        }
    }
}   