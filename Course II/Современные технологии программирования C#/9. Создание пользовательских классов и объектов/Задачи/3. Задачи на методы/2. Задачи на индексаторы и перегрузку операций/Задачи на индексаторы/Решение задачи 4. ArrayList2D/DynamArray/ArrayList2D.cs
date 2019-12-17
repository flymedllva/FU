using System;
using System.Collections;
using System.Windows.Forms;

namespace DynamArray
{
    class ArrayList2D
    {
        ArrayList list;
        int n;              // Количество столбцов (объектов в строке)



        //---------------------------------------------
        public int Count
        {
            get { return list.Count; }
        }

        //---------------------------------------------
        public int CountRow
        {
            get { return list.Count / n; }
        }

        //---------------------------------------------
        public int CountColumn
        {
            get { return n; }
        }

        //---------------------------------------------
        public ArrayList GetArrayList
        {
            get { return list; }
        }

        //---------------------------------------------
        public ArrayList2D(int N)
        {
            n = N;
            list = new ArrayList();
        }


        //---------------------------------------------
        public int GetLength(int u)
        {
            if (u == 0) return CountRow;
            if (u == 1) return n;
            MessageBox.Show("Параметр метода GetLength может быть равен либо 0, либо 1");
            return 0;
        }


        // Очистка матрицы
        //---------------------------------------------
        public void Clear()
        {
            list.Clear();
        }


        // Добавление строки 
        //---------------------------------------------
        public bool AddRow(params object[] ob)
        {
            if (ob.Length != n)
            {
                MessageBox.Show("Добавляется строка: количество объектов д.б. = " + n);
                return false;
            }
            else
                for (int i = 0; i < n; i++)
                    list.Add(ob[i]);

            return true;
        }

        // Вставка строки 
        //---------------------------------------------
        public bool InsertRow(int ind, params object[] ob)
        {
            if (ob.Length != n)
            {
                MessageBox.Show("Добавляется строка: количество объектов д.б. = " + n);
                return false;
            }
            else
                for (int i = 0; i < n; i++)
                    list.Insert(ind * n + i, ob[i]);

            return true;
        }


        // Удаление строки k
        //---------------------------------------------
        public bool RemoveRow(int k)
        {
            if (k < 0 || k >= CountRow)
            {
                MessageBox.Show("Строки с номером " + k + " не существует ");
                return false;
            }
            else
                list.RemoveRange(n * k, n);

            return true;
        }


        // Индексатор
        //---------------------------------------------
        public object this[int i, int j]
        {
            get
            {
                if (i >= CountRow || j >= n)
                {
                    MessageBox.Show("Не правильно задан один или оба индекса!");
                    return null;
                }

                return list[i * n + j];
            }
            set
            {
                if (i >= CountRow || j >= n)
                {
                    MessageBox.Show("Не правильно задан один или оба индекса!");
                    return;
                }

                list[i * n + j] = value;
            }
        }


        // Слияние матриц
        //-------------------------------------------------------------------
        public static ArrayList2D operator +(ArrayList2D ob1, ArrayList2D ob2)
        {
            if (ob1.CountColumn != ob2.CountColumn)
            {
                MessageBox.Show("Операция + задана для массивов с разным количеством столбцов.");
                return null;
            }

            ArrayList2D t2D = new ArrayList2D(ob1.CountColumn);
            
            for (int i = 0; i < ob1.Count; i++)
                t2D.GetArrayList.Add(ob1.GetArrayList[i]);

            for (int i = 0; i < ob2.Count; i++)
                t2D.GetArrayList.Add(ob2.GetArrayList[i]);

            return t2D;
        }


        // Копирование динамической матрицы в обычный массив 
        //------------------------------------------
        public object[,] CopyToArray()
        {
            object[,] t = new object[CountRow, n];

            for (int i = 0; i < CountRow; i++)
                for (int j = 0; j < n; j++)
                    t[i, j] = list[i * n + j];

            return t;
        }

        // Сортировка матрицы 
        //---------------------------------------------
        public void Sort(Object comparer)
        {
            if (!(comparer is IComparer))
            {
                MessageBox.Show("Вы забыли реализовать интерфейс IComparer");
                return;
            }
            list.Sort((IComparer)comparer);
        }

    }
}
