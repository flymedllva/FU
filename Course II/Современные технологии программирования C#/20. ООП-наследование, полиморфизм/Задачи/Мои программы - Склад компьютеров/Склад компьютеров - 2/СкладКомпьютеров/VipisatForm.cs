using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace СкладКомпьютеров
{
    public partial class VipisatForm : Form
    {
        private Store store;
        public VipisatForm(Store store)
        {
            InitializeComponent();
            this.store = store;
            for (int i = 0; i < store.regnummas.Count; i++)
            {
                comboBox1.Items.Add(store.regnummas[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Computer comp = Store.SearchComputerNum(store, comboBox1.Text);
            if (comp != null)
            {
                comp.FIO = textBox1.Text;
            }
            else
            {
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}