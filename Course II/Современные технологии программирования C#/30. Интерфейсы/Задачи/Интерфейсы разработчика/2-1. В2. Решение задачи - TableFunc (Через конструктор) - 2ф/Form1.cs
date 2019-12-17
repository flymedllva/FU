using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableFunc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //----------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("--- Первая функция ---");
            A a = new A();          //!!!!!!!
            TableFuncClass tf = new TableFuncClass(a);
            //                                   ======
            double[,] xy = tf.TableFunc(0.0, 10.0, 0.5);

            for (int i = 0; i < xy.Length / 2; i++)
                listBox1.Items.Add(xy[i, 0].ToString() + "\t" + xy[i, 1].ToString());



            listBox1.Items.Add("--- Вторая функция ---");
            B b = new B();          //!!!!!!!
            tf = new TableFuncClass(b);
            //                    =====
            xy = tf.TableFunc(-10.0, 10.0, 1.0);
            for (int i = 0; i < xy.Length / 2; i++)
                listBox1.Items.Add(xy[i, 0].ToString() + "\t" + xy[i, 1].ToString("0.00"));
        }
    }

    public class A : IFunction
    //                       =========
    {
        public double F(double x)
        {
            return 4 * x - 5;
        }
    }

    public class B : IFunction
    //                       =========
    {
        public double F(double x)
        {
            return Math.Sin(x);
        }
    }
}
