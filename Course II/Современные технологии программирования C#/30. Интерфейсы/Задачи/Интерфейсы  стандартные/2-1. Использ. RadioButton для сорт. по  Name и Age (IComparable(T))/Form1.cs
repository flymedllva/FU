/*
public void Sort()- Сортирует элементы во всем списке List<T> с помощью компаратора по умолчанию.
 
public void Sort(Comparison<T> comparison) - Сортирует элементы во всем списке List<T> с использованием указанного делегата System.Comparison<T>.

public void Sort(IComparer<T> comparer) - Сортирует элементы во всем списке List<T> с помощью указанного компаратора.
 
public void Sort(int index,int count, IComparer<T> comparer) - Сортирует элементы в диапазоне элементов списка List<T> с помощью указанного компаратора. 
  
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {

        List<Student> list;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
            list.Sort();
            studentBindingSource.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Student> 
            {
                new Student("Ким", 1992),
                new Student("Чабров", 1980),
                new Student("Шипова", 1994),
                new Student("Шилова", 1993),
                new Student("Карамышева", 1993),
                new Student("Афонасьев", 1989),
                new Student("Бурундуков", 1994),
                new Student("Анисимов", 1990)
            };


            studentBindingSource.DataSource = list;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Student.flag = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Student.flag = false;
        }
    }
}
