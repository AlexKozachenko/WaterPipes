using System;

namespace WaterPipes
{
    internal class SourceCell : Cell
    {
        public SourceCell()
        {
            Color = ConsoleColor.Yellow;
            IsActive = true;
            IsFull = true;
            Letter = 'S';
        }
    }
}