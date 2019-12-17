using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MyListObject
{
    class NumeratorStud : IEnumerator
    {
        MyList list;
        MyList.Node curNode = null;

        //----------------------------
        public NumeratorStud(MyList myList)
        {
            list = myList;
        }

        //----------------------------
        public bool MoveNext()
        {

            if (curNode == null)
                curNode=list.Start;
            else
                curNode = curNode.Next;


            if (curNode == null)
                return false;
            else
                return true;
        }

        //----------------------------
        public object Current
        {
            get
            {  return curNode.Obj;  }
        }

        //----------------------------
        public void Reset()
        {
            curNode = null;
        }


    }
}
