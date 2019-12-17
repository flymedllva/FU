using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySort; 

namespace СортировкаМассиваСтудентов
{
    public class SortFam : IComparer
    {
        // Сортируем по возрастанию фамилий
        public bool CompareTo(object std1, object std2)
        {
            int i = ((Студент)std1).Фамилия.CompareTo(((Студент)std2).Фамилия);  // -1 std1<std2; 0 ==; +1 >

            return i == 1 ? true : false;

        }

    }
}
