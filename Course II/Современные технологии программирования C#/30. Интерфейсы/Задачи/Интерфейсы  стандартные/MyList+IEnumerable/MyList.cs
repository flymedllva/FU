/*  Создается однонаправленный список. 
 * Для узла создается класс Node.
 * Общие поля (Start, Finish и Count) создаются один раз, 
 * в объекте класса MyList.
 * Это более профессионально реализованный список. 
 */




using System;
using System.Collections.Generic;
using System.Collections;
//using System.Linq;
using System.Text;

namespace MyListObject
{
    public class MyList : IEnumerable
    {
        public Node Start = null;
        private Node Finish = null;
        private int  count = 0;

        public int Count { get { return count; } }

        //-------------------------------------------------------
        public class Node
        {
            public Student Obj;
            public Node Next;
        }


        //-------------------------------------------------------
        public void Add(Student objAdd)
        {
            Node newNode = new Node();

            count++;
            newNode.Obj = objAdd;

            if (Finish == null)
            {
                Start = newNode;
                Finish = newNode;
            }
            else
            {
                Finish.Next = newNode;
                Finish = newNode;
            }
        }

        //-------------------------------------------------------
        public Student this[int ind]
        {
            get
            {
                if (ind >= Count || ind < 0)
                {
                    throw new Exception(string.Format("Индекс списка вне диапазона: Count={0}, ind={1}",
                        count, ind));
                }

                Node node = Start;
                for (int i = 1; i <= ind; i++)
                {
                    node = node.Next;
                }

                return node.Obj;
            }

        }
        //-------------------------------------------------------
        public IEnumerator GetEnumerator()
        {
            return new NumeratorStud(this);
        }


        //-------------------------------------------------------
        public void Sort()
        {
            if (Start == null)
                return;

            if (!(Start.Next.Obj is IMyComparable))
                throw new Exception("Не реализован интерфейс IMyComparable " +
                         "для сравнения объектов!");

            bool p = false;
            Node nodeJ0 = null, nodeJ1, nodeJ2;

            for (int i = 0; i < count - 1; i++)
            {
                p = false;   // Признак отсутствия  обменов 
                nodeJ1 = Start;
                nodeJ2 = Start.Next;

                for (int j = 0; j < count - 1 - i; j++)
                {
                    if (((IMyComparable)(nodeJ1.Obj)).CompareTo(nodeJ2.Obj) == 1)
                    {
                        // Обмен
                        if (j == 0)
                        {
                            Start.Next = nodeJ2.Next;
                            nodeJ2.Next = Start;
                            Start = nodeJ2;
                        }
                        else
                        {
                            nodeJ0.Next = nodeJ2;
                            nodeJ1.Next = nodeJ2.Next;
                            nodeJ2.Next = nodeJ1;
                        }

                        if (j == count - 2) Finish = nodeJ1;

                        p = true;  		// был обмен 

                        nodeJ0 = nodeJ2;
                        //nodeJ1 ;
                        nodeJ2 = nodeJ1.Next;
                    }
                    else   // Нет обмена
                    {
                        nodeJ0 = nodeJ1;
                        nodeJ1 = nodeJ2;
                        nodeJ2 = nodeJ2.Next;
                    }
                }
            }

            if (p == false) return; // Если обменов не было, то сортировка выполнена
        }
    }
}



