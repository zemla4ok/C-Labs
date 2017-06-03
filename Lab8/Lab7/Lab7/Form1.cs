using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WpfApplication2;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Book> list = new List<Book>();

        #region Lab7
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //if (!Validator.ValidTextBoxes(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,
                //    this.textBox4.Text, this.textBox5.Text, this.comboBox1.Text, this.numericUpDown1.Value.ToString()))
                //    MessageBox.Show("Поля не могут быть пустыми");
                //else if (!Validator.ValidRadio(this.radioButton1.Checked, this.radioButton2.Checked))
                //    MessageBox.Show("Выберите пол автора");
                //else
                //{
                Book book = new Book(this.textBox5.Text, Convert.ToInt32(this.numericUpDown1.Value), this.comboBox1.Text, this.monthCalendar1.SelectionStart.Date.ToString(),
                    new Author(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,
                    this.radioButton1.Checked == true ? this.radioButton1.Text : this.radioButton2.Text, this.textBox4.Text));
                if (Validate(book))
                {
                    list.Add(book);
                    this.listBox1.Items.Add(book.ToString());
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool Validate(Book book)
        {
            var result = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(book, context, result, true))
            {
                foreach (var error in result)
                {
                    listBox1.Items.Add(error.ErrorMessage);
                }
                return false;
            }
            return true;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("ListBooks.xml", FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            List<Book> lst;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("ListBooks.xml", FileMode.Open))
            {
                lst = (List<Book>)formatter.Deserialize(fs);
            }
            foreach (Book b in lst)
            {
                list.Add(b);
                this.listBox1.Items.Add(b.ToString());
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            list.Clear();
        }
        #endregion
        #region valid
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
        }
        #endregion
        #region Lab8
        List<Book> searchingList = new List<Book>();
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v1.1\n(C)Kotovich Dmitry");
        }
        private void button4_Click(object sender, EventArgs e)//поиск по году
        {
            searchingList.Clear();
            this.listBox2.Items.Clear();
            searchingList = Searching.SearchByYear(this.textBox6.Text, list);
            if (searchingList != null)
                foreach (Book b in searchingList)
                    this.listBox2.Items.Add(b);
        }
        private void button5_Click(object sender, EventArgs e)//поиск по страницам
        {
            searchingList.Clear();
            this.listBox2.Items.Clear();
            searchingList = Searching.SearchByPages(Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), list);
            if (searchingList != null)
                foreach (Book b in searchingList)
                    this.listBox2.Items.Add(b);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            searchingList.Clear();
            this.listBox2.Items.Clear();
            searchingList = Searching.SearchingByPagesAndYear(this.textBox6.Text, Convert.ToInt32(this.numericUpDown2.Value),
                Convert.ToInt32(this.numericUpDown3.Value), list);
            if (searchingList != null)
                foreach (Book b in searchingList)
                    this.listBox2.Items.Add(b);

        }
        private void button8_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("Searching.xml", FileMode.Create))
            {
                formatter.Serialize(fs, searchingList);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            List<Book> lst;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("Searching.xml", FileMode.Open))
            {
                lst = (List<Book>)formatter.Deserialize(fs);
            }
            foreach (Book b in lst)
            {
                list.Add(b);
                this.listBox1.Items.Add(b.ToString());
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            List<Book> buf = new List<Book>();
            buf = Sorts.SortByAuthorName(searchingList);
            searchingList.Clear();
            this.listBox2.Items.Clear();
            foreach (Book b in buf)
            {
                searchingList.Add(b);
                this.listBox2.Items.Add(b);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            List<Book> buf = new List<Book>();
            buf = Sorts.SortByStartYear(searchingList);
            searchingList.Clear();
            this.listBox2.Items.Clear();
            foreach (Book b in buf)
            {
                searchingList.Add(b);
                this.listBox2.Items.Add(b);
            }
        }
        #endregion

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar);
        }

    }
}
