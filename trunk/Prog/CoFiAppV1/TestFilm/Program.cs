﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace TestFilm
{
    class Program
    {
        static void Main(string[] args)
        {
            Film f = new Film("2001", 1989, null, "Test1 Test2");
            Console.WriteLine(f);
        }
    }
}