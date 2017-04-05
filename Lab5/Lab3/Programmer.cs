using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    delegate void UI();
    class Programmer
    {
        //events
        public event UI Update;
        public event UI Reset;

        //methods to do event
        public void OnUpdate()
        {
            Update();
        }
        public void OnReset()
        {
            Reset();
        }
    }
}