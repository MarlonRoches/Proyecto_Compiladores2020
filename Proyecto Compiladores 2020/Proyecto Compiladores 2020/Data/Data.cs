using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.CompilerServices;

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
        Dictionary<string, string> Comentarios = TextValidation.Comentarios;
        Dictionary<string, string> Cadenas = TextValidation.Cadenas;

        public void Sustituir(string code)
        {
            var asds = "";

            Regex Keywords = new Regex(@"^(void|int|double|boolean|string|class|const|interface|null|this|extends|implements|for|while|if|else|return|break|New|System|out|println)$");
            Regex Operadores = new Regex(@"^(\+|-|\*|/|%|<|<=|>|>=|=|==|!=|&&|\|\||!|;|,|\.|\[|\]|\(|\)|{|}|\[\]|\(\)|{})$");
            Regex Boolean = new Regex("true|false");
            Regex IntegerRegx = new Regex(@"^([0-9]+)*$");
            Regex DoubleRegx = new Regex(@"^(0[xX]).([0-9a-fA-F]+)$");
            Regex Double = new Regex(@"^(([0-9]+.[0-9]+|.[0-9]+)|([0-9]+.(E|e)(-|\+)?[0-9]+))$");
            Regex Identifier = new Regex(@"^([A-Za-z]+[0-9]*)$");

            var file = new StreamReader("Reservadas.txt");
            Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();

            var fileCode = new StreamReader("TestCode.txt");
            var rawCode = code;
            var DiccionarioInvertido = new Dictionary<string, string>();
            //var rawCode = fileCode.ReadToEnd();

            fileCode.Close();
            foreach (var item in Reservadas_Sustitucion.Keys)
            {

                rawCode = rawCode.Replace($"{item}", $" {Reservadas_Sustitucion[item]} ");

            }
            foreach (var invert in Reservadas_Sustitucion)
            {
                DiccionarioInvertido.Add(invert.Value, invert.Key);
            }

            //aqui split por enters
            int colStart = 0;
            
            int ColEnd = 0;
            string token = "";
            bool flag = true;
            var codigoArray = rawCode.Split('\n');
            //aqui se hace la validación de tokens
            for (int i = 0; i < codigoArray.Length; i++)
            {
                int line = i+1;

                var indexer = 0;
                var LineaActual = codigoArray[i].Replace("\r", "");
                var sobras = "";
                while (LineaActual != "")
                {
                    //se rompe hasta que no tenga nada o encuentre un id
                    foreach (var item in LineaActual)
                    {
                        if (item.ToString() == " " || item.ToString() == "\t" || item.ToString() == "\n" || item.ToString() == "\r")
                        {
                            //saltamos
                            //sumas 1 si es espacio 8 si es \t
                            if (item.ToString() == "\t")
                            {
                                LineaActual = LineaActual.Remove(0, 1);
                                colStart = colStart + 8;

                            }
                            else if (item.ToString() == "\r")
                            {
                                LineaActual = LineaActual.Remove(0, 1);

                            }
                            else
                            {
                                LineaActual = LineaActual.Remove(0, 1);
                                colStart++;

                            }
                            //indexer++;
                        }
                        else
                        {
                            if (DiccionarioInvertido.ContainsKey(item.ToString()))
                            {
                                if (Keywords.IsMatch(DiccionarioInvertido[item.ToString()]))
                                {
                                    int lenghtKey = DiccionarioInvertido[item.ToString()].Length;
                                    ColEnd = ColEnd + lenghtKey;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"    {DiccionarioInvertido[item.ToString()]} line {line} cols {colStart}-{ColEnd} T_{DiccionarioInvertido[item.ToString()]}");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }
                                else if (Operadores.IsMatch(DiccionarioInvertido[item.ToString()]))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($"    {DiccionarioInvertido[item.ToString()]} - >     T-Operador_{DiccionarioInvertido[item.ToString()]}");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }

                                //caracter especial
                                //el valor el largo etc etc
                                //aqui contas colmuns y filas etc ect



                            }
                            //comentarios y comentarios
                            else if (item.ToString() == "█" || item.ToString() == "▄")
                            {
                                //mandar a traer el comentarios
                                if (item.ToString() == "█")//alt +987
                                {
                                    //mandamos a traer comentarios
                                    //agarras los tres
                                    var comentarios = LineaActual.Substring(0, 3);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.BackgroundColor = ConsoleColor.White;

                                    Console.WriteLine($"{TextValidation.Instance.GetComentario(comentarios)}- >     T-Comentario{comentarios}");
                                    Console.BackgroundColor = ConsoleColor.Black;

                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 3);
                                    //al diccionario 
                                    //.length
                                    //mostrar
                                    break;
                                }
                                else //▄ 988
                                {
                                    //mandamos a traer el string, medimos el largo 
                                    var Cadena = LineaActual.Substring(0, 3);
                                    LineaActual = LineaActual.Remove(0, 3);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.WriteLine($"{TextValidation.Instance.GetString(Cadena)} - >     T-Stringr_{Cadena}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //al diccionario 
                                    //.length
                                    //mostrar
                                    break;

                                }
                            }
                            else
                            {

                                var auxiiar = LineaActual.Remove(0, indexer);
                                var idActual = "";
                                foreach (var characterActual in auxiiar)
                                {

                                    if (characterActual.ToString() == " " || characterActual.ToString() == "\t" || characterActual.ToString() == "\n" || characterActual.ToString() == "\r" || DiccionarioInvertido.ContainsKey(characterActual.ToString()) || characterActual.ToString() == "█" || characterActual.ToString() == "▄")
                                    {
                                        //saltamos
                                        //sumas 1 si es espacio 8 si es \t
                                        indexer++;
                                        break;
                                    }
                                    else
                                    {
                                        idActual += characterActual;
                                    }
                                }
                                //el id {idActual} colmna tal y row tal
                                // sub cadena la mandas a ER
                                //explresiones regulares irian aqui

                                if (Boolean.IsMatch(idActual))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"    {idActual} - >     T-Boolean_{idActual}");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length-1);
                                }
                                else if (Identifier.IsMatch(idActual))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"    {idActual} - >     T-Id_{idActual}");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length);
                                }
                                else if (IntegerRegx.IsMatch(idActual))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine($"    {idActual} - >     T-Integer_{idActual}");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length-1);
                                }
                                else if (DoubleRegx.IsMatch(idActual))
                                {

                                }


                                //Console.ForegroundColor = ConsoleColor.DarkYellow;
                                LineaActual = LineaActual.Remove(0, (indexer + idActual.Length) - 1);
                                indexer = 0;
                                break;
                            }



                        }
                        var lol = 2;
                    }

                }

                Console.WriteLine($"");
            }

        }


    }
}
