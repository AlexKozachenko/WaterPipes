using System;

namespace WaterPipes
{
    internal class MoveRight : Key
    {
        public MoveRight()
        {
            Input = ConsoleKey.RightArrow;
        }

        public override bool Action(Pipes pipes)
        {
            pipes.CellAbscissaX++;
            // если абсцисса заходит на правую границу рамки, смещаем на 2 влево, чтобы установить левее границы;
            // отнимется 2, т.к. fieldWidth это количество клеток по ширине, но нумерация начинается с нуля,
            // соответственно правая граница рамки это fieldWidth - 1, соотв. крайняя абсцисса - fieldWidth - 2
            if (pipes.CellAbscissaX > pipes.FieldWidth - 2)
            {
                pipes.CellAbscissaX = pipes.FieldWidth - 2;
            }
            return true;
        }
    }
}