using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class MyAttribute : ValidationAttribute
    {
        public string Name { get; set; }
        public MyAttribute() { }
        public MyAttribute(string pName)
        {
            this.Name = pName;
        }

        public override bool IsValid(object value)
        {
            if(value != null)
            {
                string name = value.ToString();
                if (!name.StartsWith(" "))
                    return true;
                else this.ErrorMessage = "пробел не может быть первым";
            }
            return false;
        }
    }
    public class Book
    {
        [Required(ErrorMessage = "не уст")]
        public string BookName { get; set; }        //название
        [Range(50, 10000, ErrorMessage = "Недопустимое уоличество страниц")]
        public virtual int Pages { get; set; }      //кол-во страниц
        [MyAttribute]
        public string Additions { get; set; }       //CD/DVD
        public string StartDate { get; set; }       //дата поступления
        public Author author;                              //автор

        public Book() { }

        public Book(string pBookName, int pPages, string pAdditions, string pStartDate, Author pAuthor)
        {
            this.BookName = pBookName;
            this.Pages = pPages;
            this.Additions = pAdditions;
            this.StartDate = pStartDate.Substring(0, 10);
            this.author = pAuthor;
        }

        public override string ToString()
        {
            return BookName + " " + Pages + "стр. " +
                Additions + " " + StartDate + "; " +
                author.NSF + " " + author.Gender + " " + author.Country;
        }
    }
}
