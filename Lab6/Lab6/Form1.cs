using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        Double buf;
        Sign sign;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button14_Click(object sender, EventArgs e)//plus
        {
            this.getBuf();
            this.sign = Sign.Plus;
        }
        private void button13_Click(object sender, EventArgs e)//minus
        {
            this.getBuf();
            this.sign = Sign.Minus;
        }
        private void button12_Click(object sender, EventArgs e)//*
        {
            this.getBuf();
            this.sign = Sign.Star;
        }
        private void button11_Click(object sender, EventArgs e)//mod
        {
            this.getBuf();
            this.sign = Sign.Mod;
        }

        private void button16_Click(object sender, EventArgs e)//equal
        {
            textBox2.Text = textBox1.Text;            
            try
            {
                double z;
                z = Convert.ToDouble(textBox1.Text);           
            switch(sign)
            {
                case Sign.Plus:
                    z += this.buf;
                    break;
                case Sign.Minus:
                    z -= this.buf;
                    break;
                case Sign.Mod:
                    z /= this.buf;
                    break;
                case Sign.Star:
                    z *= this.buf;
                    break;
            }
            textBox1.Text = Convert.ToString(z);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
                
        private void button17_Click(object sender, EventArgs e)//sin
        {
            this.getBuf();
            textBox1.Text = Convert.ToString(Math.Sin(buf));
        }
        private void button18_Click(object sender, EventArgs e)
        {
            this.getBuf();
            textBox1.Text = Convert.ToString(Math.Cos(buf));
        }
        private void button19_Click(object sender, EventArgs e)
        {
            this.getBuf();
            textBox1.Text = Convert.ToString(Math.Sqrt(buf));
        }

        private void button20_Click(object sender, EventArgs e)//memory
        {
            textBox3.Text = textBox1.Text;
            textBox1.Text = null;
        }
        private void button21_Click(object sender, EventArgs e)//memory to TExtBox1
        {
            textBox1.Text = textBox3.Text;
        }

        private void getBuf()
        {
            try
            {
            string bufStr = textBox1.Text;
            buf = Convert.ToDouble(bufStr);
            textBox2.Text = bufStr;
            textBox1.Text = null;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }        
    }
    enum Sign
    {
        Minus, Plus, Star, Mod
    }
}