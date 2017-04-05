using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    delegate int D();
    abstract class ProgLang
    {
        public int integerType { get; set; }
        public double doubleType { get; set; }
        public String stringType { get; set; }

        
    }

    interface Operations
    {
        void WriteToFile();
        Tuple<int, string, double> Cortage(int pInt, String pString, double pDouble);
    }
}