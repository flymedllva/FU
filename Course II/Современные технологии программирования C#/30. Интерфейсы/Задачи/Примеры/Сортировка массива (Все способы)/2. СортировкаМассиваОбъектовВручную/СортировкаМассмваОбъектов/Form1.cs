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

        private void Сортировать(Аудитория[] база)
        {
            Аудитория перваяВПаре, втораяВПаре;
            int количествоПар =  база.Length;
            int номер;
            bool признакНеУпорядоченности = true;
            while (признакНеУпорядоченности)
            {
                количествоПар--;
                признакНеУпорядоченности = false;
                for (номер = 0; номер < количествоПар; номер++)
                {
                    перваяВПаре = база[номер];
                    втораяВПаре = база[номер + 1];
                    if (перваяВПаре.СравнитьСАудиторией(втораяВПаре) > 0)
                    {
                        база[номер] = втораяВПаре;
                        база[номер + 1] = перваяВПаре;
                        признакНеУпорядоченности = true;
                    }
                }
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
            Сортировать(база);
            MessageBox.Show("Отсортировано", "Сортировка методом стандартного обмена");
        }
    }
}