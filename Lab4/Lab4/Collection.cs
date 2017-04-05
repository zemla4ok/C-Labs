using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//кол-во с нулями
//кол-во из диапазона
namespace Lab4
{
    class Collection<T> where T : MyClass
    {
        private Queue<T> myQueue;

        public Collection()
        {
            myQueue = new Queue<T>();
        }
        public Collection(Queue<T> val)
        {
            myQueue = new Queue<T>();
            this.myQueue = val;
        }
        public void SetElementToEnd(T val)
        {
            if (val == null)
                throw new NullReferenceException("Нулевой элемент");
            this.myQueue.Enqueue(val);
        }
        public T GetFirstElem()
        {
            return this.myQueue.Peek();
        }
        public void DeleteFirstElem()
        {
            this.myQueue.Dequeue();
        }
        public void DeleteAllElements()
        {
            this.myQueue.Clear();
        }
        public T this[int index]
        {
            get
            {
                if (index > myQueue.Count())
                    throw new MemberAccessException("Ошибочный индекс");
                return myQueue.ElementAt<T>(index);
            }
        }
        public Queue<T> GetMyQueue()
        {
            return this.myQueue;
        }
    }
    class MyClass : IEnumerable
    {
        public int myVal { set; get; }

        public MyClass() { }
        public MyClass(int val)
        {
            this.myVal = val;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
