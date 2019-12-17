

        static void ShowVector<T>(T[] v, string r)
        {
            foreach (var a in v)
                Console.Write(a + r);
        }

  

        //----------------------------------------------
        static void ShowVector<T>(params T[] v) 
        {
            foreach (var a in v)
                Console.Write(a + "  ");
        }



   