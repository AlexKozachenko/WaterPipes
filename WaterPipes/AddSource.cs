using System;

namespace WaterPipes
{
    internal class AddSource : Key
    {
        public AddSource()
        {
            Input = ConsoleKey.S;
        }

        public override bool Action(Pipes pipes)
        {
            if (!(pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX].IsActive))
            {
                pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX] = new SourceCell();
            }
            return true;
        }
    }
}