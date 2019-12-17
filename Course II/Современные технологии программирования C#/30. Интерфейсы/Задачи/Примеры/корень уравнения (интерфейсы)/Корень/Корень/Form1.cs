using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Корень
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IФормула уравнение;
        Вычислитель вычислитель;
        double левая, правая, приближение;

        private void button3_Click(object sender, EventArgs e)
        {
            левая = double.Parse(textBox1.Text);
            правая = double.Parse(textBox2.Text);
            приближение = double.Parse(textBox3.Text);
            if (radioButton1.Checked)
            {
                уравнение = new Формула1();
            }
            if (radioButton2.Checked)
            {
                уравнение = new Формула2();
            }

            вычислитель = new Вычислитель(левая, правая, приближение, уравнение);
            button3.Enabled = false;
            textBox4.Text = "";
            textBox5.Text = "";
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            вычислитель.ВычислитьКорень();
            textBox4.Text = String.Format("{0:f3}",вычислитель.КореньУравнения);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double корень;
            корень = вычислитель.КореньУравнения;
            textBox5.Text = String.Format("{0:f5}", вычислитель.ЗначениеУравнения(корень));
            button2.Enabled = false;
            button3.Enabled = true;
        }
    }
}