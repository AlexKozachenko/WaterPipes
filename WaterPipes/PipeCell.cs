using System;

namespace WaterPipes
{
    internal class PipeCell : Cell
    {
        public PipeCell()
        {
            Color = ConsoleColor.White;
            Letter = 'O';
            IsActive = true;
            IsFull = false;
        }
    }
}