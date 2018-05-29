using System;

namespace WaterPipes
{
    internal class FilledPipeCell : PipeCell
    {
        public FilledPipeCell()
        {
            Color = ConsoleColor.Blue;
            IsFull = true;
        }
    }
}