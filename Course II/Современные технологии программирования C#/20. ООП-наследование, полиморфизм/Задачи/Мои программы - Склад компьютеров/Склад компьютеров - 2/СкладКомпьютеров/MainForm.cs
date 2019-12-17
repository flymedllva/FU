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
    public partial class MainForm : Form
    {
        private Store store;
        private Computer compsearch;
        private int N=2,RegNumber=1;
        public Store Store
        {
            get
            {
                return store;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            store = new Store();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Computer comp = new Computer(textBox1.Text, textBox2.Text, textBox3.Text, uint.Parse(textBox4.Text), textBox5.Text, uint.Parse(textBox6.Text), uint.Parse(textBox7.Text), uint.Parse(textBox8.Text), uint.Parse(textBox9.Text), uint.Parse(textBox10.Text), textBox11.Text);
            store.storemas.Add(comp);
            comp.RegNumber = RegNumber.ToString();
            store.regnummas.Add(comp.RegNumber);
            RegNumber++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VipisatForm vipisatform= new VipisatForm(Store);
            vipisatform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for(int n=0;n<store.storemas.Count;n++)
            {  //((Computer)store.storemas[n]).Video.MonitorType, (((Computer)store.storemas[n]).Video.VideoMemory).ToString(), ((Computer)store.storemas[n]).CenterBlock.ProcessorType, (((Computer)store.storemas[n]).CenterBlock.Speed).ToString(), (((Computer)store.storemas[n]).CenterBlock.DiskSpace).ToString(), (((Computer)store.storemas[n]).CenterBlock.RAMCap).ToString(), (((Computer)store.storemas[n]).Perepherals.KeyboardButtons).ToString(), (((Computer)store.storemas[n]).Perepherals.MouseButtons).ToString(), ((Computer)store.storemas[n]).Perepherals.PrinterType
                dataGridView1.Rows.Add((((Computer)store.storemas[n]).RegNumber).ToString(), ((Computer)store.storemas[n]).Brand, ((Computer)store.storemas[n]).Type, ((Computer)store.storemas[n]).FIO,((Computer)store.storemas[n]).Video.MonitorType, (((Computer)store.storemas[n]).Video.VideoMemory).ToString(), ((Computer)store.storemas[n]).CenterBlock.ProcessorType, (((Computer)store.storemas[n]).CenterBlock.Speed).ToString(), (((Computer)store.storemas[n]).CenterBlock.DiskSpace).ToString(), (((Computer)store.storemas[n]).CenterBlock.RAMCap).ToString(), (((Computer)store.storemas[n]).Perepherals.KeyboardButtons).ToString(), (((Computer)store.storemas[n]).Perepherals.MouseButtons).ToString(), ((Computer)store.storemas[n]).Perepherals.PrinterType);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (N)
            {
                case 0:
                    {
                        compsearch = Store.SearchComputerNum(store, textBox12.Text);
                        if (compsearch == null)
                        {
                            return;
                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView1.Rows.Add((compsearch.RegNumber).ToString(), compsearch.Brand, compsearch.Type, compsearch.FIO, compsearch.Video.MonitorType, (compsearch.Video.VideoMemory).ToString(), compsearch.CenterBlock.ProcessorType, (compsearch.CenterBlock.Speed).ToString(), (compsearch.CenterBlock.DiskSpace).ToString(), (compsearch.CenterBlock.RAMCap).ToString(), (compsearch.Perepherals.KeyboardButtons).ToString(), (compsearch.Perepherals.MouseButtons).ToString(), compsearch.Perepherals.PrinterType);
                        }
                        return;
                    }
                case 1:
                    {
                        ArrayList mas = Store.SearchComputerName(store, textBox12.Text);
                        if (mas == null)
                        {
                            return;
                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < mas.Count; i++)
                            {
                                compsearch = (Computer)mas[i];
                                dataGridView1.Rows.Add((compsearch.RegNumber).ToString(), compsearch.Brand, compsearch.Type, compsearch.FIO, compsearch.Video.MonitorType, (compsearch.Video.VideoMemory).ToString(), compsearch.CenterBlock.ProcessorType, (compsearch.CenterBlock.Speed).ToString(), (compsearch.CenterBlock.DiskSpace).ToString(), (compsearch.CenterBlock.RAMCap).ToString(), (compsearch.Perepherals.KeyboardButtons).ToString(), (compsearch.Perepherals.MouseButtons).ToString(), compsearch.Perepherals.PrinterType);
                            }
                        }
                        return;
                    }
                default:
                    MessageBox.Show("Не указано условие поиска.");
                    return;

            }
        }
            
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            N = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            N = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveForm removeform = new RemoveForm(Store);
            removeform.Show();

        }

    }
}