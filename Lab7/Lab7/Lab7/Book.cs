using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Book
    {
        public string BookName { get;  set; }        //название
        public int Pages { get;  set; }              //кол-во страниц
        public string Additions { get;  set; }       //CD/DVD
        public string StartDate { get;  set; }       //дата поступления
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
