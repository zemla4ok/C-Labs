using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_2
{

    public partial class Form1 : Form
    {
        List<MyClass> col = new List<MyClass>();
        bool isCol = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
        }

        private void button1_Click(object sender, EventArgs e)//generation
        {
            if (!isCol)
            {
                this.generateCollection();
                isCol = true;
            }
            else
            {
                col.Clear();
                this.generateCollection();
            }
            this.printCollection();
        }
        private void generateCollection()
        {
            try
            {
                Random rand = new Random();
                int amount = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < amount; i++)
                {
                    col.Add(new MyClass(rand.Next() % 1000000));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void printCollection()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < col.Count; i++)
            {
                listBox1.Items.Add(col.ElementAt(i).myIntVal);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lessSort = from i in col
                           orderby i.myIntVal descending
                           select i;
            listBox1.Items.Clear();
            foreach (MyClass i in lessSort)
            {
                listBox1.Items.Add(i.myIntVal);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var lessSort = from i in col
                           orderby i.myIntVal 
                           select i;
            listBox1.Items.Clear();
            foreach (MyClass i in lessSort)
            {
                listBox1.Items.Add(i.myIntVal);
            }
        }

        delegate bool CountInt(MyClass mc, int num);
        CountInt ci = (mc, num) =>
        {
            if (mc.myIntVal == num)
                return true;
            else
                return false;
        };
        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("*************************");
            int i = Convert.ToInt32(textBox2.Text);
            int counter = 0;
            for (int j = 0; j < col.Count; j++)
            {
                if (ci(col[j], i))
                {
                    listBox2.Items.Add(col[j].myIntVal);
                    counter++;
                }
            }
            listBox2.Items.Add("---------");
            listBox2.Items.Add(counter);
        }

        delegate bool CountFromDiap(MyClass mc, int s, int e);
        CountFromDiap cfi = (mc, s, e) =>
        {
            if (mc.myIntVal >= s && mc.myIntVal <= e)
                return true;
            else
                return false;
        };
        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("*************************");
            int a = Convert.ToInt32(textBox3.Text);
            int b = Convert.ToInt32(textBox4.Text);
            int counter = 0;
            for (int i = 0; i < col.Count; i++)
            {
                if (cfi(col[i], a, b))
                {
                    listBox2.Items.Add(col[i].myIntVal);
                    counter++;
                }
            }
            listBox2.Items.Add("---------");
            listBox2.Items.Add(counter);
        }
    }
}

///TODO: Форма должна содержать
//кнопки для выполнения запросов и
//окна вывода результатов.