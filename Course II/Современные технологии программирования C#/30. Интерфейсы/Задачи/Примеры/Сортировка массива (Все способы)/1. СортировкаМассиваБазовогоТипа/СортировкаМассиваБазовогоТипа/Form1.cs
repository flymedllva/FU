using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace СортировкаМассиваБазовогоТипа
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] фамилия;

        private void Form1_Load(object sender, EventArgs e)
        {
            фамилия = new string[5];
            фамилия[0] = "СИДОРОВ";
            фамилия[1] = "ПЕТРОВ";
            фамилия[2] = "ВАСИЛЬЕВ";
            фамилия[3] = "ВАСЬКИН";
            фамилия[4] = "АЛЕКСЕЕВ";
        }

        private void Вывод(string[] база, ListBox список)
        {
            список.Items.Clear();
            for (int i = 0; i < база.Length; i++)
            {
                список.Items.Add(база[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Вывод(фамилия,listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Array.Sort(фамилия);
            MessageBox.Show("Отсортировано","Сортировка методом класса Array");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Вывод(фамилия, listBox2);
        }
    }
}