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
 
    //-------------------------------
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        //---------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            TableFuncClass tf = new TableFuncClass(0, 10, 1);

            F1 f1 = new F1();
            F2 f2 = new F2();

            float[,] xy = tf.TableFunc(f1);

            for (int i = 0; i < xy.Length / 2; i++)
                listBox1.Items.Add(xy[i, 0].ToString() + "\t" + xy[i, 1].ToString());


            float[,] xy2 = tf.TableFunc(f2);
            
            for (int i = 0; i < xy2.Length / 2; i++)
                listBox2.Items.Add(xy2[i, 0].ToString() + "\t" + xy2[i, 1].ToString());

        }
    }


    //-------------------------------
    class F1 : IFunction
    {
        public float F(float x)
        {
            return 4 * x - 5;
        }
    }

    //-------------------------------
    class F2 : IFunction
    {
        public float F(float x)
        {
            return -2 * x + 8;
        }
    }

}
