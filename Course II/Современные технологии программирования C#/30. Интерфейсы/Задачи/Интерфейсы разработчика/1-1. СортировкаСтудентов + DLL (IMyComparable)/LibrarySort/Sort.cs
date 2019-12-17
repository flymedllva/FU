using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LibrarySort
{

    public interface IMyComparable
    {
      bool Comparer (object o1);
    }



    //----------------------------------------------------------
    public class Sort
    {
        static public void BubbleSort(IMyComparable[] sortArray)
        {
            for (int i = 0; i < sortArray.Length; i++)
                for (int j = i + 1; j < sortArray.Length; j++)
                    if (sortArray[i].Comparer(sortArray[j]))
                    {
                        IMyComparable temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
        }




        static public void QuickSort(object[] sortArray, IComparer method)
        {
            MessageBox.Show("Еще не реализован");
            
        }

    }
}
