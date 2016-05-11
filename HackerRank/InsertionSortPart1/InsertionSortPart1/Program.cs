using System;
using System.Collections.Generic;
  class Solution
  {


 static void insertionSort(int[] ar)
 {
   int key = 0;
     for (int i = 1; i < ar.Length; i++)
       {
         if (ar[i] < ar[i - 1])
         {
           key = ar[i];
           ar[i] = ar[i - 1];
         }

       }


   for (int i = 0; i < ar.Length; i++)
   {
     Console.Write($"{ar[i]} ");
   }

  }

    static void Main(string[] args)
    {
      if (args.Length > 0)
      {
        Console.SetIn(System.IO.File.OpenText(args[0]));
      }
      int _ar_size;
     _ar_size = Convert.ToInt32(Console.ReadLine());
     int [] _ar =new int [_ar_size];
     String elements = Console.ReadLine();
     String[] split_elements = elements.Split(' ');
     for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
     }

     insertionSort(_ar);
    }
  }



