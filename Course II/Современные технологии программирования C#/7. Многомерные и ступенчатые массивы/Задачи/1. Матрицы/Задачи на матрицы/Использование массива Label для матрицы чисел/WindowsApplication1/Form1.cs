/*    Задача 1
Квадратная матрица символьного типа размером NxN заполняется от датчика 
случайных чисел по правилу: в строки с четными номерами заносятся 
прописные латинские буквы, а в строки с нечетными номерами – цифры. 
Нумерация строк выполняется с нуля. Номер 0 – четный. 
Значение N определяет пользователь. 
Сформировать строку символов путем копирования в нее символов на главной 
диагонали. Просмотр диагонали выполняется сверху вниз. 
A	M	W	Q	E
6	1	7	8	3
Q	Z	A	D	T
4	2	3	9	5
A	X	R	C	V
 
Для приведенного примера строка должна иметь вид: A1A9V. 
Матрицу и сформированную строку вывести на экран.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Label[,] table;      //массив для создания Label*ов
        Random rnd = new Random();
        string text;   //переменная для объявления размера массива
        string stroka;
      
        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(textBox1);  //удаление элементов управления
            Controls.Remove(button1);   //удаление элементов управления
            
            int n = int.Parse(textBox1.Text);
            
            table = new Label[n, n];
            
            for (int i = 0; i < n; i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (i % 2 == 0)
                    {
                        {
                            text = ((char)rnd.Next('A', 'Z')).ToString();  //для записи элемента на четной строке
                        }

                        table[i, j] = new Label();
                        table[i, j].AutoSize = true;
                        table[i, j].Location = new System.Drawing.Point(20 * j, 20+20 * i);
                        table[i, j].Name = "label";
                        table[i, j].TabIndex = 1;
                        table[i, j].Text = text;
                    }
                    else
                    {
                        {
                            text = (rnd.Next(0, 9)).ToString();  //для записи элемента на нечетной строке
                        }

                        table[i, j] = new Label();
                        table[i, j].AutoSize = true;
                        table[i, j].Location = new System.Drawing.Point(20 * j, 20+20 * i);
                        table[i, j].Name = "label";
                        table[i, j].TabIndex = 1;
                        table[i, j].Text = text;
                    }
                    
                    if (i == j || i == n - j-1)
                    {
                        
                        table[i,j].BackColor = System.Drawing.Color.Coral;   //изменение цвета у определенных элементов матрицы
                        
                    }
                    if (i == j)
                    {
                        stroka += table[i, j].Text+ " ";  //строка из элементов главной диагонали
                        label1.Location = new System.Drawing.Point(0, 0);
                        label1.Text = "искомая строка: " + stroka;
                    }
                    Controls.Add(table[i,j]);
                    
                }   
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //позволяет записывать в текстбокс только числовые данные
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
                e.KeyChar = '\0';
        }
    }
}