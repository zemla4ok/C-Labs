using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Author
    {
        public string NSF { get; set; }     //ФИО+
        public string Gender { get; set; }  //пол
        public string Country { get;  set; } //страна

        public Author() { }

        public Author(string Firstname, string Lastname, string Fathername, string pGender, string pCountry)
        {
            this.NSF = Lastname + " " + Firstname[0] + ". " + Fathername[0] + ".";
            this.Gender = pGender;
            this.Country = pCountry;
        }
    }
}
