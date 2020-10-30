using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proyecto_Compiladores_2020.Data
{
    class TextValidation
    {
        private static TextValidation _instance = null;
        public static TextValidation Instance
        {
            get
            {
                if (_instance == null) _instance = new TextValidation();
                return _instance;
            }
        }
        public static Dictionary<string, string> Comentarios = new Dictionary<string, string>();
        public static Dictionary<string, string> Cadenas = new Dictionary<string, string>();
        public static Dictionary<string, string> Errores = new Dictionary<string, string>();


        private int Error_Index = 0;

        private int Comentarios_Index = 0;
        private int Str_Index = 0;
        public string ValidarComentarios(string ruta)
        {
            var compressedCode = "";
            //var Reservadas_Sustitucion = Data.Instance.DictionarySymbols();
            var fileCode = new StreamReader(ruta);
            var linea = fileCode.ReadLine();



            while (linea != null)
            {
                if (linea.Contains("//"))
                {
                    //comentario unilinea
                    var comented = linea.IndexOf("//");
                    Comentarios.Add("█" + $"{Comentarios_Index}".PadLeft(2, '0'), linea.Remove(0, comented));
                    linea = linea.Replace(linea.Remove(0, comented), "█" + $"{Comentarios_Index}".PadLeft(2, '0'));
                    compressedCode += $"{linea}\n";
                    Comentarios_Index++;
                }
                //cometarios multilinea
                else if (linea.Contains("/*"))
                {


                    if (linea.Contains("*/"))
                    {// el comentario termina en la misma linea
                        var actual = "";
                        var aux1 = linea.Remove(0, linea.IndexOf("/*"));
                        linea = linea.Replace(aux1, "█" + $"{Comentarios_Index}".PadLeft(2, '0') + "\n");
                        AgregarComentario(aux1);
                        actual += linea;
                        linea = "";
                    }
                    else
                    {// multi linea que no se cierre en la misma linea

                        var actual = "";
                        var aux1 = linea.Remove(0, linea.IndexOf("/*"));
                        linea = linea.Replace(aux1, "█" + $"{Comentarios_Index}".PadLeft(2, '0') + "\n");
                        AgregarComentario(aux1);
                        actual += linea;
                        linea = "";
                        //inicio de comentario multilinea
                        while (!linea.Contains("*/"))
                        {
                            linea = fileCode.ReadLine();
                            if (linea == null)
                            {
                                //EOF EN COMENTARIO
                                Errores.Add("¦" + $"{Error_Index}".PadLeft(2, '0'), "EOF en un comentario");
                                compressedCode += "¦" + $"{Error_Index}".PadLeft(2, '0');
                                Error_Index++;
                                break;
                            }
                            else
                            {


                                if (linea == "")
                                {
                                    actual += "\n";
                                }
                                else if (linea.Contains("*/"))
                                {
                                    //contiene final de comentario
                                    //*/  code......
                                    var aux = linea.Substring(0, linea.IndexOf("*/") + 2);
                                    linea = linea.Replace(aux, "█" + $"{Comentarios_Index}".PadLeft(2, '0'));
                                    AgregarComentario(aux);
                                    actual += linea;
                                    linea = actual;
                                    break;
                                }
                                else
                                {
                                    //Medio comentarios
                                    //agarrar toda la linea 
                                    var aux = linea;
                                    linea = linea.Replace(linea, "█" + $"{Comentarios_Index}".PadLeft(2, '0') + "\n");
                                    AgregarComentario(aux);
                                    actual += linea;
                                    linea = "";
                                }
                                if (linea == null)
                                {
                                    //error de comentario no cerrado
                                    break;
                                }
                            }
                        }

                    }

                    if (linea!=null)
                    {

                        while (linea.Contains("//"))
                        {
                            linea = parseComentarioUnilinea(linea);
                        }
                        compressedCode += $"{linea}";
                    }

                }
                else
                {
                    //inicio de comentario 
                    if (linea.Contains("*/"))
                    {
                        //cierre de comentario
                        var fixedLine = linea.Replace("*/", "┘" + $"{Error_Index}".PadLeft(2, '0'));
                        Errores.Add("┘" + $"{Error_Index}".PadLeft(2, '0'), "*/");
                        Error_Index++;
                        compressedCode += $"{fixedLine}\n";

                    }
                    else
                    {
                        // todo nitido
                        compressedCode += $"{linea}\n";
                    }
                }
                linea = fileCode.ReadLine();
            }
            fileCode.Close();

            var arrayPost = compressedCode.Split('\n');

            compressedCode = "";
            for (int i = 0; i < arrayPost.Length; i++)
            {
                if (arrayPost[i].Contains("*/"))
                {
                    arrayPost[i] = arrayPost[i].Replace("*/", "┘" + $"{Error_Index}".PadLeft(2, '0'));
                    Errores.Add("┘" + $"{Error_Index}".PadLeft(2, '0'),"*/");
                    Error_Index++;
                }
                compressedCode += $"{arrayPost[i]}\n";
            }
            return compressedCode;
        }



        public string ValidarStrings(string code)
        {
            var stringless = "";
            var splitedCode = code.Split('\n');



            foreach (var line in splitedCode)
            {
                if (line.Contains('"'))
                {



                    //PENDIENTE
                    //MIENTRAS LA LINEA NO CONTENGA MAS COMILLAS



                    //primera comilla
                    var PrimeraComilla = line.IndexOf('"') + 1;
                    var aux = line.Remove(0, PrimeraComilla);
                    if (aux.IndexOf('"')==-1)
                    {
                        var value = $"\"{aux}";
                        stringless += $"{line.Replace($"{value}", "┌" + $"{Error_Index}".PadLeft(2, '0'))}" + "\n"; //alt+988
                        Errores.Add("┌" + $"{Error_Index}".PadLeft(2, '0'), $"{value}");
                        Error_Index++;

                       
                    }
                    else
                    {
                        //segunda comilla
                        var value = aux.Substring(0, aux.IndexOf('"'));
                        stringless += $"{line.Replace($"{'"'}{value}{'"'}", "▄" + $"{Str_Index}".PadLeft(2, '0'))}" + "\n"; //alt+988
                        Cadenas.Add("▄" + $"{Str_Index}".PadLeft(2, '0'), $"\"{value}\"");
                        Str_Index++;

                    }

                   
                }
                else
                {
                    stringless += $"{line}\n";
                }
            }
            return stringless;
        }
        string parseComentarioUnilinea(string linea)
        {
            var comented = linea.IndexOf("//");
            //Comentarios.Add($"█{Comentarios_Index}", linea.Remove(0, comented));
            var aux = linea.Remove(0, comented);
            linea = linea.Replace(aux, "█" + $"{Comentarios_Index}".PadLeft(2, '0'));
            AgregarComentario(aux);



            return linea;
        }

        void AgregarComentario(string comentario)
        {
            Comentarios.Add("█" + $"{Comentarios_Index}".PadLeft(2, '0'), comentario);
            Comentarios_Index++;
        }

        public string GetError(string Code)
        {
            return Errores[Code];
        }

        public string GetComentario(string Code)
        {
            return Comentarios[Code];
        }
        public string GetString(string Code)
        {
            return Cadenas[Code];

        }
    }
}