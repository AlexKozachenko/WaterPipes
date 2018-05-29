using System.Collections;
using System.Collections.Generic;

namespace WaterPipes
{
    internal class Keyboard : IEnumerable
    {
        private ICollection<Key> keys = new List<Key>();

        public Keyboard()
        {
            keys.Add(new MoveUp());
            keys.Add(new MoveDown());
            keys.Add(new MoveLeft());
            keys.Add(new MoveRight());
            keys.Add(new DeleteCell());
            keys.Add(new AddSource());
            keys.Add(new AddPipe());
            keys.Add(new ExitInput());
        }

        public IEnumerator GetEnumerator()
        {
            return keys.GetEnumerator();
        }
    }
}