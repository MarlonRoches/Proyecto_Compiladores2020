using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Compiladores_2020.Data;

namespace Proyecto_Compiladores_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linea De Codigo");
            Data.Data.Instance.Sustituir(Console.ReadLine());
        }
    }
}
