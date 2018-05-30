using System;

namespace WaterPipes
{
    internal class PipeCell : Cell
    {
        public PipeCell()
        {
            Color = ConsoleColor.White;
            IsActive = true;
            Letter = 'O';
        }
    }
}