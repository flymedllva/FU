/* В проекте показана привязка DGV к списку, 
 * содержащему объекты разных классов с виртуальным свойством.
 * Добавляется свободный столбец типа CheckBox. 
 * Определяется наличие строки для добавления новой записи.
 * Исследуется процесс добавления новых записей. 
 * Они добавляются как объекты базового типа.
 * Показано, что содержимое таблицы и источника данных не совпадают. 
 * Это связяно с тем, что таблица высвечивает только заданные открытые свойства, 
 * обращаясь к методу get, а источник данных хранит значения 
 * закрытых полей, которые присвоил конструктор.
 * Для демонстрации этого явления свойство РазмерКредита класса 
 * Клиент всегда возвращает 111, в то время как в источнике данных 
 * поле размерКредита имеет совсем другие значения.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DGV_VirtualMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Клиент> listКлиент;
        private void Form1_Load(object sender, EventArgs e)
        {
            listКлиент = new List<Клиент>();
            listКлиент.Add(new ФизЛицо("Иванов", "Не возвратный", 1000000, 2015));
            listКлиент.Add(new ФизЛицо("Петров", "Квартира в залог", 500000, 2018));
            listКлиент.Add(new ЮридЛицо("ГазПром", "Беспроцентный", 99000000, 2020));
            listКлиент.Add(new ФизЛицо("Сидоров", "До конца жизни", 1000000, 2015));
            listКлиент.Add(new ЮридЛицо("Лукойл", "Льготный", 33000000, 2020));

            клиентBindingSource.DataSource = listКлиент;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow) 
                    continue;
                if (listКлиент[i] is ЮридЛицо)
                    dataGridView1["Организация", i].Value = true;
            }
            ОтобразитьИсточникДанных();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ОтобразитьИсточникДанных();

        }

        private void ОтобразитьИсточникДанных()
        {
            textBox1.Text = "";
            for (int i = 0; i < listКлиент.Count; i++)
                textBox1.Text += listКлиент[i].Атрибуты + " \t" 
                    + listКлиент[i].Условия + " \t" 
                    + listКлиент[i].размерКредита + " \t"
                    + listКлиент[i].срокКредита + " \r\n";
        }



    }
}
