using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_2
{
    class MyClass : IEnumerable
    {
        public int myIntVal { set; get; }


        public MyClass() { }
        public MyClass(int val)
        {
            this.myIntVal = val;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}