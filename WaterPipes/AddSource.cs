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
            //ордината смещается вниз за счет счетчика поколений, поднимаем на 1
            if (!(pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX].IsActive))
            {
                pipes.Field[pipes.CellOrdinateY - 1, pipes.CellAbscissaX] = new SourceCell();
            }
            return true;
        }
    }
}