using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Интеграл
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IФормула подинтегральная;
        IФормула первообразная;
        Интегратор интегратор;

        private void button3_Click(object sender, EventArgs e)
        {
            double a, b;
            int k;
            a = double.Parse(textBox1.Text);
            b = double.Parse(textBox2.Text);
            k = int.Parse(textBox3.Text);
            if (radioButton1.Checked)
            {
                подинтегральная = new Формула1();
                первообразная = new Первообразная1();
            }
            if (radioButton2.Checked)
            {
                подинтегральная = new Формула2();
                первообразная = new Первообразная2();
            }
            
            интегратор = new Интегратор(a, b, k, подинтегральная,первообразная);
            
            button1.Enabled = true;
            button3.Enabled = false;
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double интеграл;
            интеграл = интегратор.ВычислитьПриближенно();
            textBox4.Text = String.Format("{0:f3}", интеграл);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double интеграл;
            интеграл = интегратор.ВычислитьТочно();
            textBox5.Text = String.Format("{0:f3}", интеграл);
            button2.Enabled = false;
            button3.Enabled = true;
        }
    }
}