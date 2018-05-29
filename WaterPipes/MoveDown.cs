using System;

namespace WaterPipes
{
    internal class MoveDown : Key
    {
        public MoveDown()
        {
            Input = ConsoleKey.DownArrow;
        }

        public override bool Action(Pipes pipes)
        {
            pipes.CellOrdinateY++;
            // если ордината заходит на нижнюю границу, устанавливаем над ней
            if (pipes.CellOrdinateY > pipes.FieldHeight - 1)
            {
                pipes.CellOrdinateY = pipes.FieldHeight - 1;
            }
            return true;
        }
    }
}