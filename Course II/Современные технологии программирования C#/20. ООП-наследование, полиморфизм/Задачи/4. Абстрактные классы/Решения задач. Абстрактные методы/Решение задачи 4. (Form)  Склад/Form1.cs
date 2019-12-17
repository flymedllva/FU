// Коллекция BindingSource привязана к классу Склад. 
// DataGridView привязяна к BindingSource, 
// поэтому все колонки создаются автоматически, данные высвечиваюся
// так же автоматически. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Склады
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        string[] Назначения = new string[] {"Москва", "Сочи", "Владивосток" };
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Забиваем значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            // Создаем пассажирские вагоны и поезда с помощью датчика с.ч.
            for (int i = 1; i < 10; i++)
            {
                // Создаем вагоны
                ТоварСпецСклада[] пасВагонов = new ТоварСпецСклада[r.Next(5,20)];  // массив вагонов
                for (int j = 0; j < пасВагонов.Length; j++ )
                    // Свободных мест должно быть не больше общего количества
                    пасВагонов[j] = new ТоварСпецСклада(r.Next(0, ТоварСпецСклада.МаксимумМест + 1));
 
                // Создаем поезд
                СпецСклад пасПоезд = new СпецСклад(i, Назначения[r.Next(0,Назначения.Length)], пасВагонов);

                // Добавляем поезд в коллекцию BindingSource
                bndingSource.Add(пасПоезд);
            }




            // Создаем грузовые вагоны и поезда с помощью датчика с.ч.
            for (int i = 1; i < 10; i++)
            {
                // Создаем вагоны
                ТоварУниСклада[] грузВагоны = new ТоварУниСклада[r.Next(15, 30)];
                for (int j = 0; j < грузВагоны.Length; j++)
                {                   
                    // Загружено должно быть не больше грузоподъемности
                    double m = r.Next(100,200);
                    грузВагоны[j] = new ТоварУниСклада(m, r.Next(0, (int)m+1));
                }
                
                // Создаем поезд
                УниверСклад грузПоезд = new УниверСклад(i, Назначения[r.Next(0, Назначения.Length)], грузВагоны);

                // Добавляем поезд в коллекцию BindingSource
                bndingSource.Add(грузПоезд);
            }
        }

        /// <summary>
        /// Показываем список вагонов в поезде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Склад п = (Склад)bndingSource[e.RowIndex];
            ListBox.Items.Clear();
            foreach (Товар в in п.Товары)
                ListBox.Items.Add(в.ПараметрыТовара());
        }

        /// <summary>
        /// Сохраняем список в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Склад п in bndingSource)
                {
                    sw.WriteLine("Поезд №{0}, назначение {1}", п.Лицензия, п.Фирма);
                    foreach (Товар в in п.Товары)
                        sw.WriteLine("\t {0}", в.ПараметрыТовара());
                }
            }
        }
    }
}