using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    internal class ForEachClass
    {
        internal class ForEachEnumerator
        {
            private int state = 0;
            public int Current { get => state; }

            public bool MoveNext()
            {
                if (state == 10)
                {
                    return false;
                }
                state++;
                return true;
            }
        }
        public ForEachEnumerator GetEnumerator()
        {
            return new ForEachEnumerator();
        }
    }
}
