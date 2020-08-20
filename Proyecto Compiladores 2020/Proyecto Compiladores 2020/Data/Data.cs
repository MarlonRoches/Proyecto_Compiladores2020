using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Proyecto_Compiladores_2020.Data
{
    class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }
        private static Dictionary<string, string> Reservadas_Sustitucion = new Dictionary<string, string>();
        //void int double boolean string class const interface null this extends implements for while if else return break New System out printl
        private static Dictionary<string, string> Variables_Sustitucion = new Dictionary<string, string>();

        public void Sustituir(string code)
        {

            var file = new StreamReader("Reservadas.txt");
            Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();

            var fileCode = new StreamReader("TestCode.txt");
            var rawCode = fileCode.ReadToEnd();
            fileCode.Close();

            foreach (var item in Reservadas_Sustitucion.Keys)
            {
            rawCode = rawCode.Replace($"{item}", $" {item} ");

            }
            rawCode = rawCode.Replace("\r\n", " ").Replace("\t", " ").Replace(";", " ; ");
            var espacios = "  ";
            for (int i = 2; i <= 10; i++)
            {
                rawCode = rawCode.Replace(espacios, " ");
                espacios += " ";
            }
            rawCode = rawCode.Trim();
            string cadenaAux = "";
             espacios = " ";
            for (int i = 2; i <= 100; i++)
            {
                rawCode = rawCode.Replace(espacios, " ");
                espacios += " ";
            }
            /**/
            var CodeArray = rawCode.Split();
            foreach (var tokenActual in CodeArray)
            {
                if (Reservadas_Sustitucion.ContainsKey(tokenActual))
                {

                    Console.WriteLine($"Token {tokenActual}: T_{tokenActual} -> {Reservadas_Sustitucion[tokenActual]}");

                }
                else
                {
                    //puede ser un id
                    //tabla de ids validarsintaxis_Id(tokenActual)
                    //puede tener error

                }
                /*if (Reservadas_Sustitucion.ContainsKey(item))
                

                }*/
            }
           var linea=  Console.ReadLine();
        }

    }
}
