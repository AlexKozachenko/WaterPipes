using System;

namespace WaterPipes
{
    internal class ExitInput : Key
    {
        public ExitInput()
        {
            Input = ConsoleKey.Spacebar;
        }

        public override bool Action(Pipes pipes)
        {
            return false;
        }
    }
}