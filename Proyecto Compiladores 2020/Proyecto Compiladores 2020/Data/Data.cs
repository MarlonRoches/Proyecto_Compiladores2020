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
            Regex HexaRegx = new Regex(@"^(0[xX]).([0-9a-fA-F]+)$");
            Regex Double = new Regex(@"^(([0-9]+.[0-9]+|.[0-9]+)|([0-9]+.(E|e)(-|\+)?[0-9]+))$");
            Regex Identifier = new Regex(@"^([A-Za-z]|[$])?.([A-Za-z]|[0-9]|[$])*$");
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
                rawCode = rawCode.Replace($"{item}", $"{Reservadas_Sustitucion[item]}"); //revisar esta parte

            }
            foreach (var invert in Reservadas_Sustitucion)
            {
                DiccionarioInvertido.Add(invert.Value, invert.Key);
            }

            //aqui split por enters

            var codigoArray = rawCode.Split('\n');
            //aqui se hace la validación de tokens
            for (int i = 0; i < codigoArray.Length; i++)
            {
                int line = i+1;
                int colStart = 0;
                int ColEnd = 0;
                var indexer = 0;
                var LineaActual = codigoArray[i].Replace("\r", "");
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
                                    ColEnd = colStart + lenghtKey;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($" {DiccionarioInvertido[item.ToString()]}    line {line} cols {colStart+1}-{ColEnd} is T_{DiccionarioInvertido[item.ToString()]}");
                                    colStart += lenghtKey;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }
                                else if (Operadores.IsMatch(DiccionarioInvertido[item.ToString()]))
                                {
                                    int lenghtOperator = DiccionarioInvertido[item.ToString()].Length;
                                    ColEnd = colStart + lenghtOperator;
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($" {DiccionarioInvertido[item.ToString()]}    line {line} cols {colStart+1}-{ColEnd} is {DiccionarioInvertido[item.ToString()]}");
                                    colStart += lenghtOperator;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }

                                //caracter especial
                                //el valor el largo etc etc
                                //aqui contas colmuns y filas etc ect



                            }
                            //comentarios y comentarios
                            else if (item.ToString() == "█" || item.ToString() == "▄" || item.ToString() == "┘" || item.ToString() == "┌" || item.ToString() == "¦")
                            {
                                //mandar a traer el comentarios
                                if (item.ToString() == "█")//alt +987
                                {
                                    //mandamos a traer comentarios
                                    //agarras los tres
                                    var comentarios = LineaActual.Substring(0, 3);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    int lenghtComent = TextValidation.Instance.GetComentario(comentarios).Length;
                                    ColEnd = colStart + lenghtComent;
                                    Console.WriteLine($"\"{TextValidation.Instance.GetComentario(comentarios)}\"    line {line} cols {colStart}-{ColEnd} is  (value = \"{TextValidation.Instance.GetComentario(comentarios)}\"");
                                    colStart += lenghtComent;
                                    ColEnd = 0;
                                    Console.BackgroundColor = ConsoleColor.Black;

                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 3);
                                    //al diccionario 
                                    //.length
                                    //mostrar
                                    break;
                                }
                                else if (item.ToString() == "▄")//▄ 988
                                {
                                    //mandamos a traer el string, medimos el largo 
                                    var Cadena = LineaActual.Substring(0, 3);
                                    LineaActual = LineaActual.Remove(0, 3);
                                    int lenghtCadena = TextValidation.Instance.GetString(Cadena).Length;
                                    ColEnd = colStart + lenghtCadena;
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.WriteLine($"\"{TextValidation.Instance.GetString(Cadena)}\"  line {line} cols {colStart}-{ColEnd} is (value = \"{TextValidation.Instance.GetString(Cadena)}\"");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    colStart += lenghtCadena;
                                    ColEnd = 0;
                                    //al diccionario 
                                    //.length
                                    //mostrar
                                    break;

                                }
                                else if (item.ToString() == "┘")//┘ 985 
                                {
                                    var Cadena = LineaActual.Substring(0, 3);
                                    LineaActual = LineaActual.Remove(0, 3);
                                    var comentarioSinabrir = TextValidation.Instance.GetError(Cadena);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"ERROR DE COMENTARIO SIN ABRIR {comentarioSinabrir}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;

                                }
                                else if (item.ToString() == "┌")//┌ 986
                                {
                                    var Cadena = LineaActual.Substring(0, 3);
                                    LineaActual = LineaActual.Remove(0, 3);
                                    var stringSinCerrar = TextValidation.Instance.GetError(Cadena);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"ERROR DE CADENA SIN CERRAR {stringSinCerrar}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else if (item.ToString() == "¦")//┌ 986
                                {
                                    var Cadena = LineaActual.Substring(0, 3);
                                    LineaActual = LineaActual.Remove(0, 3);
                                    var ErrorEOF = TextValidation.Instance.GetError(Cadena);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{ErrorEOF}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }

                            }
                            else
                            {

                                var auxiiar = LineaActual.Remove(0, indexer);
                                var idActual = "";
                                foreach (var characterActual in auxiiar)
                                {

                                    if (characterActual.ToString() == " " || characterActual.ToString() == "\t" || characterActual.ToString() == "\n" || characterActual.ToString() == "\r" || characterActual.ToString() == "\t" || characterActual.ToString() == "\n" || characterActual.ToString() == "█"|| DiccionarioInvertido.ContainsKey(characterActual.ToString()) || item.ToString() == "█" || item.ToString() == "█" || item.ToString() == "▄" || item.ToString() == "┘" || item.ToString() == "┌" || item.ToString() == "¦")
                                    {
                                        //saltamos
                                        ////sumas 1 si es espacio 8 si es \t
                                        if (item.ToString() == "\t")
                                        {
                                            LineaActual = LineaActual.Remove(0, 1);
                                            colStart = colStart + 8;
                                        }
                                        //else if (item.ToString() == "\r")
                                        //{
                                        //    LineaActual = LineaActual.Remove(0, 1);

                                        //}
                                        else if (characterActual.ToString() == " ")
                                        {
                                           // LineaActual = LineaActual.Remove(0, 1);
                                            colStart++;

                                        }
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
                                    int lenghtBoolean = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtBoolean;
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($" {idActual}     line {line} cols {colStart}-{ColEnd} is T_Boolean");
                                    colStart += lenghtBoolean;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length-1);
                                }
                                else if (Identifier.IsMatch(idActual))
                                {
                                    int lenghtIdentifier = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtIdentifier;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($" {idActual}     line {line} cols {colStart+1}-{ColEnd} is T_Identifier");
                                    colStart += lenghtIdentifier;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0,idActual.Length);
                                    indexer = 0;
                                    break;
                                    // LineaActual = LineaActual.Remove(0, idActual.Length);
                                }
                                else if (IntegerRegx.IsMatch(idActual))
                                {
                                    int lenghtInteger = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtInteger;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine($" {idActual}     line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");
                                    colStart += lenghtInteger;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length-1);
                                }
                                else if (HexaRegx.IsMatch(idActual))
                                {
                                    int lenghtDoubleRegx = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtDoubleRegx;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine($" {idActual}     line {line} cols {colStart}-{ColEnd} is T_{idActual}");
                                    colStart += lenghtDoubleRegx;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                }
                                else if (Double.IsMatch(idActual))
                                {
                                    int lenghtDouble = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtDouble;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine($" {idActual}     line {line} cols {colStart}-{ColEnd} is T_{idActual}");
                                    colStart += lenghtDouble;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                }
                                else
                                {
                                    var validation = "";
                                    var aux = "";
                                    for (int j = 0; j < idActual.Length; j++)
                                    {
                                        validation += idActual[j];
                                        if (!Identifier.IsMatch(validation))
                                        {
                                          
                                                //mostramos error
                                                aux = validation.Substring(0, validation.Length);
                                                Console.WriteLine($"El caracter {aux} no fue reconocido");
                                                idActual = aux;
                                                indexer = 0;
                                                LineaActual = LineaActual.Remove(0,idActual.Length);
                                                break;

                                        }
                                    }
                                    
                                    break;
                                }
                                    
                                //Console.ForegroundColor = ConsoleColor.DarkYellow;


                            }



                        }
                    }

                }

                Console.WriteLine($"");
            }

        }


    }
}
