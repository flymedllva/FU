using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace СортировкаМассиваОбъектов
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Аудитория[] база;
 
        private void Form1_Load(object sender, EventArgs e)
        {
            база = new  Аудитория[5];
            база[0] = new Аудитория(309, 12);
            база[1] = new Аудитория(308, 15);
            база[2] = new Аудитория(305, 13);
            база[3] = new Аудитория(311, 16);
            база[4] = new Аудитория(304, 11);
        }

        private void Вывод(Аудитория[] база, ListBox список)
        {
            список.Items.Clear();
            for (int i = 0; i < база.Length; i++)
            {
                список.Items.Add(база[i].Сообщить());
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Вывод(база, listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Вывод(база, listBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Аудитория.СортировкаПоНомеру сравнениеПоНомеру;
            сравнениеПоНомеру = new Аудитория.СортировкаПоНомеру();
            Array.Sort(база,сравнениеПоНомеру);
            MessageBox.Show("Отсортировано по номерам", "Сортировка методом класса Array");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Аудитория.СортировкаПоМестам сравнениеПоМестам;
            сравнениеПоМестам = new Аудитория.СортировкаПоМестам();
            Array.Sort(база, сравнениеПоМестам);
            MessageBox.Show("Отсортировано по местам", "Сортировка методом класса Array");
        }
    }
}