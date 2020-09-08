using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Compiladores_2020.Data;
using Newtonsoft.Json;


namespace Proyecto_Compiladores_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alexander Villatoro / Marlon Roches");
            Console.WriteLine("Compiladores 2020");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("MINI");
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("JAVA");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("\n");

            Console.WriteLine("Drag 'n Drop el Codigo de Mini Java");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"↓");
            Console.Write($" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"~");
            Console.ForegroundColor = ConsoleColor.White;

            var ruta =Console.ReadLine();
            Console.Clear();
            Data.Data.Instance.Sustituir(Data.TextValidation.Instance.ValidarStrings( Data.TextValidation.Instance.ValidarComentarios(ruta)), ruta);

            Console.WriteLine($"#   #   #   #   #   ERRORES    #   #   #   #   #");
            Console.WriteLine($"</-----------------------------------Final De Archivo-----------------------------------/>");
           // Console.ReadLine();

            Data.GrammarValidation.Instance.Lab1();
            //{ } [] () {}
            ////id		
            //TOKEN 1 = LETRA.(LETRA|DIGITO)*
            //json5
            ////integer
            //TOKEN 2 = DIGITO.DIGITO* 
            //    15654

            ////string    
            //TOKEN 3 = '"'.LETRA(LETRA|DIGITO)*.'"'
            //    "asdasdasd"
            ////Bool   
            //TOKEN 4=(TRUE|FALSE)
            //true
            //    //double
            //TOKEN 5 = DIGITO.DIGITO*.'.'DIGITO.DIGITO*
            //    5.21651

            ////integer asignado
            //TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' '*.DIGITO.DIGITO *.' '*.';'
            //         int    numero                          =            1565;
            ////string asignado
            //TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' ' *.'"'.LETRA(LETRA|DIGITO)*.'"'.' '*.';'
            //         int numero = 1565;

        }
    }
}
