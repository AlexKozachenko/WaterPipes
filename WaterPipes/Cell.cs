using System;

namespace WaterPipes
{
    internal class Cell
    {
        private ConsoleColor color;
        private bool isActive;
        private bool isFull;
        private char letter;

        public Cell()
        {
            isActive = false;
            isFull = false;
            letter = ' ';
        }

        public ConsoleColor Color
        {
            get => color;
            set => color = value;
        }

        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }

        public bool IsFull
        {
            get => isFull;
            set => isFull = value;
        }

        public char Letter
        {
            get => letter;
            set => letter = value;
        }
    }
}