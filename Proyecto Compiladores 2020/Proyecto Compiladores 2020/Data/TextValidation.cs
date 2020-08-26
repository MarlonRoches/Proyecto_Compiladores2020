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

        private int Comentarios_Index = 0;
        private int Str_Index = 0;
        public string ValidarComentarios(string ruta)
        {
            var compressedCode = "";
            var file = new StreamReader("Reservadas.txt");
            var Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();
            var fileCode = new StreamReader("TestCode.txt");
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
                else if (linea.Contains("/*"))
                {
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
                        if (linea=="")
                        {
                            actual += "\n";

                        }
                        else if (linea.Contains("*/"))
                        {
                            //contiene final de comentario
                            //*/  code......
                            var aux = linea.Substring(0, linea.IndexOf("*/")+2);
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
                            linea = linea.Replace(linea, "█"+$"{Comentarios_Index}".PadLeft(2, '0')+"\n");
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
                    //var comentarioMultilinea = linea.Remove(0, linea.IndexOf("/*"));
                    //comentarioMultilinea = comentarioMultilinea.Substring(0, comentarioMultilinea.IndexOf("*/") + 2);
                    //Comentarios.Add($"█{Comentarios_Index}", comentarioMultilinea);
                    ///linea = linea.Replace(comentarioMultilinea, $"█{Comentarios_Index}");
                    //Comentarios_Index++;
                    while (linea.Contains("//"))
                    {
                        linea = parseComentarioUnilinea(linea);
                    }
                    compressedCode += $"{linea}";
                }
                else
                {
                    //inicio de comentario 
                    if (linea.Contains("*/"))
                    {
                        //cierre de comentario
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
                    var PrimeraComilla = line.IndexOf('"')+1;
                    var aux = line.Remove(0,PrimeraComilla);
                    //segunda comilla
                    var value = aux.Substring(0, aux.IndexOf('"') );
                    stringless += $"{line.Replace($"{'"'}{value}{'"'}", "▄" + $"{Str_Index}".PadLeft(2, '0'))}" +"\n"; //alt+988
                    Cadenas.Add("▄"+$"{Str_Index}".PadLeft(2,'0'),value);
                    Str_Index++;
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
            Comentarios.Add("█"+$"{Comentarios_Index}".PadLeft(2, '0'), comentario);
            Comentarios_Index++;
        }

    }
}