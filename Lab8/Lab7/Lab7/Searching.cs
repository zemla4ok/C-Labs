using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    static class Searching
    {
        public static List<Book> SearchByYear(string pYear, List<Book> list)
        {
            int sYear;
            List<Book> rc = new List<Book>();
            Regex regex = new Regex(@"\d{4}");
            if (!regex.IsMatch(pYear))
                MessageBox.Show("Введите год в формате yyyy");
            else
            {
                sYear = Convert.ToInt32(pYear);
                foreach (Book b in list)
                {
                    if (sYear <= Convert.ToInt32(b.StartDate.Substring(6, 4)))
                        rc.Add(b);
                }
            }
            return rc;
        }

        public static List<Book> SearchByPages(int sPage, int lPage, List<Book> list)
        {
            List<Book> rc = new List<Book>();
            foreach (Book b in list)
                if (b.Pages >= sPage && b.Pages <= lPage)
                    rc.Add(b);
            return rc;
        }

        public static List<Book> SearchingByPagesAndYear(string pYear, int sPage, int lPage, List<Book> list)
        {
            List<Book> rc = new List<Book>();
            Regex regex = new Regex(@"\d{4}");
            if (!regex.IsMatch(pYear))
                MessageBox.Show("Введите год в формате yyyy");
            else
            {
                int sYear = Convert.ToInt32(pYear);
                foreach (Book b in list)
                    if (b.Pages >= sPage && b.Pages <= lPage && sYear <= Convert.ToInt32(b.StartDate.Substring(6, 4)))
                        rc.Add(b);
            }
            return rc;
        }
    }
}
