using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        int flag = 0; //объявляем переменные-показатели и счётчики
        int counter = -1;
        int counter2 = 0;
        Warehouse sklad = new Warehouse(); //объект класса Склад
        Computer comp; //Объект класса компьютер
        public Form1()
        {
            InitializeComponent();
        }

  

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                comp = new Computer(textBox1.Text, uint.Parse(textBox2.Text), textBox3.Text, uint.Parse(textBox4.Text), uint.Parse(textBox5.Text), uint.Parse(textBox6.Text), textBox7.Text, textBox8.Text, uint.Parse(textBox10.Text));
                sklad.Add(comp);
                label16.Text = (sklad.Очередь.Count).ToString();
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
                textBox8.Text = " ";
                textBox10.Text = " ";
                counter++;
            }
            catch 
            {
                MessageBox.Show("Проверьте корректность заполнения полей!");
            }
          

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == " " || textBox11.Text == "")
            {
                MessageBox.Show("Проверьте корректность ввода");
            }
            else if (textBox11.Text == "Мунтян Наталья Васильевна" || textBox11.Text=="имя забаненого пользоватлея") //Проверка на то, выдавать компьютер или нет
            {
                MessageBox.Show("Этому пользователю компьютер выдан быть не может.");
            }
            else
            {
                try
                {
                    sklad.Delete(textBox11.Text, (Computer)sklad.Массив[counter2]);
                    counter2++;                    
                    label17.Text = counter2.ToString(); 
                    label16.Text = (int.Parse(label16.Text) - 1).ToString();
                    textBox11.Text = "";
                }
                catch
                {
                    MessageBox.Show("Копмутеры кончились.");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < sklad.Массив.Count; i++)
            {
                dataGridView1.Rows.Add(sklad.Show((Computer)sklad.Массив[i])[0], sklad.Show((Computer)sklad.Массив[i])[2], sklad.Show((Computer)sklad.Массив[i])[1]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox13.Enabled = false;
            textBox12.Enabled = true;
            flag = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Enabled = false;
            textBox13.Enabled = true;
            flag = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            if (flag == 0)
            {
                MessageBox.Show("Выберtте критерий поиска.");
            }
            else
            {
                try
                {
                    if (flag == 1)
                    {
                        for (int n = 0; n < sklad.Массив.Count; n++)
                        {
                            if (textBox12.Text == ((Computer)sklad.Массив[n]).Пользователь)
                            {
                                textBox14.Text = ((Computer)sklad.Массив[n]).Print(((Computer)sklad.Массив[n]));
                            }
                        }
                    }
                    else if (flag == 2)
                    {
                        for (int n = 0; n < sklad.Массив.Count; n++)
                        {
                            if ((uint.Parse(textBox13.Text)) == ((Computer)sklad.Массив[n]).Reg)
                            {
                                textBox14.Text = ((Computer)sklad.Массив[n]).Print(((Computer)sklad.Массив[n]));
                            }
                        }
                    }
                    textBox12.Text = "";
                    textBox13.Text = "";
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность ввода");
                }
            }
        }

        private void обнулитьБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sklad.Массив.Clear();
            sklad.Очередь.Clear();
            label16.Text = "0";
            label17.Text = "0";
        }
    }

    //Класс Видео
    public class Video
    {
        private string monitor;
        private uint vmemory;
        public Video() //Конструкторы
        {
            monitor = "Тип монитора";
            vmemory = 128;
        }
        public Video(string mon, uint vm) 
        {
            monitor = mon;
            vmemory = vm;
        }
        public string Show1(Video v)//Метод вывода данных
        {
            string str;
            str = " Тип монитора: " + monitor + " Объём видеопамяти: " + vmemory.ToString();
            return str;
        }
    }

    //Класс основная часть
    public class mainpart
    {
        private string processortype;
        private uint frequency;
        private uint diskcapacity;
        private uint ram;
        public mainpart() //Конструкторы
        {
            processortype = "Тип процессора";
            frequency = 2;
            diskcapacity = 60;
            ram = 256;
        }
        public mainpart(string p, uint f, uint d, uint r) 
        {
            processortype = p;
            frequency = f;
            diskcapacity = d;
            ram = r;
        }
        public string Show2(mainpart m) //Метод вывода данных
        {
            string str;
            str = " Тип процессора: " + processortype + " Быстродействие: " + frequency.ToString() + " Объём диска: " + diskcapacity.ToString() + " Объём ОЗУ: " + ram.ToString();
            return str;
        }
    }

    //Класс Переферия
    public class Extra
    {
        private string keyboard;
        private string mouse;
        public Extra() //Конструкторы
        {
            keyboard = "Logitech";
            mouse = "Logitech";
        }
        public Extra(string k, string m) 
        {
            keyboard = k;
            mouse = m;
        }
        public string Show3(Extra e)//Метод вывода данных
        {
            string str;
            str = " Клавиатура: " + keyboard + " Мышь: " + mouse;
            return str;
        }
    }

    //Класс компьютер !Некоторые поля этого класса - объекты других классов!
    public class Computer
    {
        private string stat;
        private string name;
        private uint reg;
        private Video v0;
        private mainpart m0;
        private Extra e0;
        public uint Reg 
        {
            get 
            {
                return reg;
            }
        }
        public string Status 
        {
            get 
            {
                return stat;
            }
            set 
            {
                stat = value;
            }
        }
        public string Пользователь 
        {
            get
            {
                return name;
            }
            set 
            {
                
                    name = value;
                
            }
        }
        public Computer()   //Конструкторы
        {
            stat = "На складе";
            name = " ";
            reg = 00000;
            v0 = new Video();
            m0 = new mainpart();
            e0  = new Extra();
        }
        public Computer(string m, uint vm, string p, uint f, uint d, uint r, string k, string mouse, uint rn)
        {
            stat = "На складе";
            name = " ";
            reg = rn;
            v0 = new Video(m, vm);
            m0 = new mainpart(p, f, d, r);
            e0 = new Extra(k, mouse);
        }
        public string Print(Computer c)     //Метод вывода данных
        {
            string str;
            str = "Имя рользователя: " + name + " Рег.№: " + reg + v0.Show1(v0) + m0.Show2(m0) + e0.Show3(e0);
            return str;
        }
    }

    //Класс Склад
    public class Warehouse
    {
        protected string[] str = new string[3];     
        public ArrayList sent = new ArrayList();
        Queue got = new Queue();
        public Queue Очередь
        {
            get 
            {
                return got;
            }
        }
        public ArrayList Массив
        {
            get
            {
                return sent;
            }
        }
        
        public void Add(Computer comp)              //Метод добавления компьютера на склад
        {
            got.Enqueue(comp);
            sent.Add(comp);
        }
        public void Delete(string fam, Computer c) //Метод удаления компьютера со склада
        {
           
                got.Dequeue();
                c.Пользователь = fam;
                c.Status = "Выдан";
            
        }
       
        public string[] Show(Computer c) 
        {
            str[0] = c.Пользователь;
            str[1] = c.Status;
            str[2] = (c.Reg).ToString();
            return str;
        }
        
    }
}