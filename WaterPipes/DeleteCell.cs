using System;

namespace WaterPipes
{
    internal class DeleteCell : Key
    {
        private Cell[,] buffer;
     
        public DeleteCell()
        {
            Input = ConsoleKey.Delete;
        }

        public override bool Action(Pipes pipes)
        {
            buffer = new Cell[pipes.FieldHeight, pipes.FieldWidth];
            pipes.InitializeField(buffer);
            pipes.CopyField(pipes.Field, buffer);
            if (pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX].IsActive)
            {
                pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX] = new Cell();
            }
            // тестовый прогон системы
            pipes.Test();
            // если число активных ячеек не равно числу заполненных, значит есть изолированные аппендиксы
            // и выполняется откат на предыдущую конфигурацию поля, предварительно записанную в буфер
            if (pipes.CountActives() != pipes.CountFilled())
            {
                pipes.CopyField(buffer, pipes.Field);
            }
            pipes.TestClear();
            return true;
            }
        }   
    }