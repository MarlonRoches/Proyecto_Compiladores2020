using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;

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
            var asds = "";

            Regex Keywords = new Regex(@"^(void|int|double|boolean|string|class|const|interface|null|this|extends|implements|for|while|if|else|return|break|New|System|out|println)$");
            Regex Operadores = new Regex(@"^(\+|-|\*|/|%|<|<=|>|>=|=|==|!=|&&|\|\||!|;|,|\.|\[|\]|\(|\)|{|}|\[\]|\(\)|{})$");
            Regex Boolean = new Regex("true|false");
            Regex Digit = new Regex(@"^([0-9]+)*$");
            Regex Hexadecimal = new Regex(@"^(0[xX]).([0-9a-fA-F]+)$");
            Regex Double = new Regex(@"^(([0-9]+.[0-9]+|.[0-9]+)|([0-9]+.(E|e)(-|\+)?[0-9]+))$");
            Regex Identifier = new Regex(@"^([A-Za-z]+[0-9]*)$");

            var file = new StreamReader("Reservadas.txt");
            Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();

            var fileCode = new StreamReader("TestCode.txt");
            var rawCode = code;
            //var rawCode = fileCode.ReadToEnd();

            fileCode.Close();
            foreach (var item in Reservadas_Sustitucion.Keys)
            {
               
                    rawCode = rawCode.Replace($"{item}", $" {Reservadas_Sustitucion[item]} ");
                
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
            
            var CodeArray = rawCode.Split();
            foreach (var tokenActual in CodeArray)
            {
               
                    if (Keywords.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es una palabra reservada: " + tokenActual + LineAndColumns());
                        //Linea Lineaand + T_palara
                    }
                    else if (Operadores.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un operador: " + tokenActual);
                    }
                    else if (Boolean.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un booleando: " + tokenActual);
                    }
                    else if (Digit.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un digito: " + tokenActual);
                    }
                    else if (Hexadecimal.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un hexadecimal: " + tokenActual);
                    }
                    else if (Double.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un decimal: " + tokenActual);
                    }
                    else if (Identifier.IsMatch(tokenActual))
                    {
                        Console.WriteLine("Es un identificador: " + tokenActual);
                    }
                    else
                    {
                        // validar los errores junto a la linea y columna
                    }

                    //Console.WriteLine($"Token {tokenActual}: T_{tokenActual} -> {Reservadas_Sustitucion[tokenActual]}");
                
                //else
                //{
                //        Console.WriteLine("No es un token");
                //    //puede ser un id
                //    //tabla de ids validarsintaxis_Id(tokenActual)
                //    //puede tener error

                //}
                /*if (Reservadas_Sustitucion.ContainsKey(item))
               
                }*/
            }
            var linea = Console.ReadLine();
        }
        public string LineAndColumns()
        {
            StreamReader streamReader = new StreamReader("TestCode.txt");
            int line = 0;
            int colstart = 0;
            int colend = 0;

            while (!streamReader.EndOfStream)
            {
                string readline = streamReader.ReadLine();
                line++;
                for (int i = 0; i < readline.Length; i++)
                {
                    string[] validate = readline.Split('\n');


                }
                
            }

            return "";
        }


    }
}
