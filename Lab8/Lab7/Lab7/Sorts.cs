using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    static class Sorts
    {
        public static List<Book> SortByAuthorName(List<Book> list)
        {
            List<Book> rc = new List<Book>();
            var r = from b in list
                    orderby b.author.NSF
                    select b;
            foreach (Book b in r)
                rc.Add(b);
            return rc;
        }

        public static List<Book> SortByStartYear(List<Book> list)
        {
            List<Book> rc = new List<Book>();
            var r = from b in list
                    orderby b.StartDate.Substring(6,4)
                    select b;
            foreach (Book b in r)
                rc.Add(b);
            return rc;
        }
    }
}
