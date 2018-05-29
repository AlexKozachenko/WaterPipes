using System;

namespace WaterPipes
{
    internal class MoveUp : Key
    {
        public MoveUp()
        {
            Input = ConsoleKey.UpArrow;
        }

        public override bool Action(Pipes pipes)
        {
            pipes.CellOrdinateY--;
            // если ордината заходит на верхнюю границу рамки, смещаем под нее (0 - счетчик, 1 - рамка, 2 - начальная ордината)
            if (pipes.CellOrdinateY == 1)
            {
                pipes.CellOrdinateY = 2;
            }
            return true;
        }
    }
}