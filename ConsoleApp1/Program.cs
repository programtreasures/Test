﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list1 = new List<int>() { 1, 2, 3 };

            List<int> list2 = new List<int>() { 4, 4, 6 };

            var result = list1.Concat(list2);

            Console.ReadLine();

        }
    }
}
