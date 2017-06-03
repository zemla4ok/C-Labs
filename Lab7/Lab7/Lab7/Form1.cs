using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void button1_Click(object sender, EventArgs e)//добавление в datagrid
        {
            if (!Validator.ValidTextBoxes(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,
                this.textBox4.Text, this.textBox5.Text, this.comboBox1.Text, this.numericUpDown1.Value.ToString()))
                MessageBox.Show("Поля не могут быть пустыми");
            else if (!Validator.ValidRadio(this.radioButton1.Checked, this.radioButton2.Checked))
                MessageBox.Show("Выберите пол автора");
            else
            {
                Book book = new Book(this.textBox5.Text, Convert.ToInt32(this.numericUpDown1.Value), this.comboBox1.Text, this.monthCalendar1.SelectionStart.Date.ToString(),
                    new Author(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,
                    this.radioButton1.Checked == true ? this.radioButton1.Text : this.radioButton2.Text, this.textBox4.Text));
                list.Add(book);
                this.listBox1.Items.Add(book.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("ListBooks.xml", FileMode.OpenOrCreate))
            {
                    formatter.Serialize(fs, list);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Book> lst;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("ListBooks.xml", FileMode.OpenOrCreate))
            {
               lst  = (List<Book>)formatter.Deserialize(fs);
            }
            foreach(Book b in lst)
            {
                list.Add(b);
                this.listBox1.Items.Add(b.ToString());
            }
        }

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
    }
}
