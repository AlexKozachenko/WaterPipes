using System;

namespace WaterPipes
{
    internal abstract class Key
    {
        private ConsoleKey input;

        public ConsoleKey Input
        {
            get => input;
            set => input = value;
        }

        public abstract bool Action(Pipes pipes);
    }
}