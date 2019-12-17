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

        object подинтегральная;
        object первообразная;
        Интегратор интегратор;



        private void radioButton_Click(object sender, EventArgs e)
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
            else if (radioButton2.Checked)
            {
                подинтегральная = new Формула2();
                первообразная = new Первообразная2();
            }
            else
            {
                MessageBox.Show("Выберите подинтегральную функцию");
            }

            интегратор = new Интегратор(a, b, k, подинтегральная, первообразная);

            label8.Text = "";
            label9.Text = "";



            double интеграл;

            // Приближенное вычисление
            интеграл = интегратор.ВычислитьПриближенно();
            label8.Text = String.Format("{0:f3}", интеграл);

            // Точное вычисление
            интеграл = интегратор.ВычислитьТочно();
            label9.Text = String.Format("{0:f3}", интеграл);
        }

    }
}