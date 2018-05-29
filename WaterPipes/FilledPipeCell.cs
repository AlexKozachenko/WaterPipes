using System;

namespace WaterPipes
{
    internal class FilledPipeCell : Cell
    {
        public FilledPipeCell()
        {
            Color = ConsoleColor.Blue;
            Letter = 'O';
            IsActive = true;
            IsFull = true;
        }
    }
}