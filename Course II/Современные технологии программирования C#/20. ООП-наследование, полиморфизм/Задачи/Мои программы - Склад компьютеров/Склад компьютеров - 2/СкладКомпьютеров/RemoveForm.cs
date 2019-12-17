using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace СкладКомпьютеров
{
    public partial class RemoveForm : Form
    {
        private Store store;
        public RemoveForm(Store store)
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
            bool check = false;
            for (int i = 0; i < store.storemas.Count; i++)
            {
                if (comboBox1.Text == ((Computer)store.storemas[i]).RegNumber)
                {
                    store.storemas.Remove(store.storemas[i]);
                    store.regnummas.Remove(store.regnummas[i]);
                    check = true;
                }
            }
             if (check == false)
            {
                MessageBox.Show("Компьютеров с таким регистрационным номером не обнаружено");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}