using System;

namespace WaterPipes
{
    internal class MoveLeft : Key
    {
        public MoveLeft()
        {
            Input = ConsoleKey.LeftArrow;
        }

        public override bool Action(Pipes pipes)
        {
            pipes.CellAbscissaX--;
            // если абсцисса заходит на левую границу рамки, смещаем на 1 клетку вправо (0 - рамка, 1 - начальная абсцисса)
            if (pipes.CellAbscissaX == 0)
            {
                pipes.CellAbscissaX = 1;
            }
            return true;
        }
    }
}