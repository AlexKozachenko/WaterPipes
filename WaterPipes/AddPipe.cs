using System;

namespace WaterPipes
{
    internal class AddPipe : Key
    {
        public AddPipe()
        {
            Input = ConsoleKey.Enter;
        }

        public override bool Action(Pipes pipes)
        {
            //ордината смещается вниз за счет счетчика шагов, поднимаем на 1
            if (!(pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX].IsActive)
                && (pipes.CountActiveNeighbours(pipes.CellOrdinateY - 1, pipes.CellAbscissaX) > 0))
            {
                pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX] = new PipeCell();
            }
            return true;
        }
    }
}