using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySort;

namespace СортировкаМассиваСтудентов
{
    public class SortRating : IComparer
    {
        // Сортируем по убыванию рейтингов
        public bool CompareTo(object std1, object std2)
        {
            return (((Студент)std1).Рейтинг < ((Студент)std2).Рейтинг) ? true : false;
        }

    }
}
