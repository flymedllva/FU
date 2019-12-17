using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LibrarySort
{
    //--------------------------------------
    public interface IComparer
    {
      bool CompareTo (object o1, object o2);
    }



    //-------------------------------------------------------------------
    public class Sort
    {
        static public void BubbleSort(object[] sortArray, IComparer method)
        {
            for (int i = 0; i < sortArray.Length; i++)
                for (int j = i + 1; j < sortArray.Length; j++)
                    if (method.CompareTo(sortArray[i], sortArray[j]))
                    {
                        object temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
        }


        static public void BubbleSort(ArrayList sortArray, IComparer method)
        {
            for (int i = 0; i < sortArray.Count; i++)
                for (int j = i + 1; j < sortArray.Count; j++)
                    if (method.CompareTo(sortArray[i], sortArray[j]))
                    {
                        object temp = sortArray[i];
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
