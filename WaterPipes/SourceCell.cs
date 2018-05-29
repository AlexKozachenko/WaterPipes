using System;

namespace WaterPipes
{
    internal class SourceCell : Cell
    {
        public SourceCell()
        {
            Color = ConsoleColor.Yellow;
            Letter = 'S';
            IsActive = true;
            IsFull = true;
        }
    }
}