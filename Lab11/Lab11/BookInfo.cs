using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab11
{
    class BookInfo
    {
        public int AuthID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int Pages { get; set; }
        public BitmapImage Photo { get; set; }

        public BookInfo(string bName, string aName, int p, BitmapImage img, int ai, int bi)
        {
            BookName = bName;
            AuthorName = aName;
            Pages = p;
            Photo = img;
            AuthID = ai;
            BookID = bi;
        }
    }
}
