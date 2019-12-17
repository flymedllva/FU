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
    public partial class Form1 : Form, IFunction
    //                                 =========
    {
        public Form1()
        {
            InitializeComponent();
        }

        public float F(float x)
        {
            return 4 * x - 5; 
        }

        //----------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            TableFuncClass tf = new TableFuncClass(this);
            //                                    ======
            float[,] xy = tf.TableFunc(0, 10, 1);

            for (int i = 0; i < xy.Length / 2; i++)
                listBox1.Items.Add(xy[i, 0].ToString() + "\t" + xy[i, 1].ToString());

        }
    }
}
