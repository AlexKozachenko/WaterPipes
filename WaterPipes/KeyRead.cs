using System;

namespace WaterPipes
{
    internal class KeyRead : ICommand
    {
        private static bool exit = true;
        private ConsoleKey input;
        private Pipes pipes;

        public KeyRead(ConsoleKey input, Pipes pipes)
        {
            this.pipes = pipes;
            this.input = input;
        }

        public static bool Exit
        {
            get => exit;
        }

        public void Execute()
        {
            foreach (Key key in new Keyboard())
            {
                if (key.Input == input)
                {
                    if (!key.Action(pipes))
                    {
                        exit = false;
                    }
                    break;
                }
            }
        }
    }
}