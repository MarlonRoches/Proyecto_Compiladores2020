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
            ruta = ruta.Replace("\"", "").Trim();
            Console.Clear();
            Console.WriteLine($"#   #   #   #   #   ERRORES Fase 1   #   #   #   #   #");
            Data.Data.Instance.Sustituir(Data.TextValidation.Instance.ValidarStrings( Data.TextValidation.Instance.ValidarComentarios(ruta)), ruta);

            Console.WriteLine($"</-----------------------------------Final De Archivo-----------------------------------/>");
           // Console.ReadLine();
            Console.WriteLine("");



            SintaxValidation.Instance.Parser(GrammarValidation.tokenList);
            // Lab A 
            //Data.GrammarValidation.Instance.LabA_Parser(ruta);
            Console.WriteLine($"Presione 3 veces Enter Para Salir...");
            Console.ReadLine();
            Console.WriteLine($"Presione 2 veces Enter Para Salir...");
            Console.ReadLine();
            Console.WriteLine($"Presione 1 veces Enter Para Salir...");
            Console.ReadLine();

        }
    }
}
