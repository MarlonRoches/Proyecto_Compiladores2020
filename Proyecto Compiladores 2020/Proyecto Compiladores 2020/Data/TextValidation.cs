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
        private static Dictionary<string, string> Comentarios = new Dictionary<string, string>();
        private int Comentarios_Index = 0;
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
                    Comentarios.Add($"█{Comentarios_Index}", linea.Remove(0, comented));
                    linea = linea.Replace(linea.Remove(0, comented), $"█{Comentarios_Index}");
                    compressedCode += $"{linea}\n";
                    Comentarios_Index++;
                }
                else if (linea.Contains("/*"))
                {
                    var actual = "";
                    var aux1 = linea.Remove(0, linea.IndexOf("/*"));
                    linea = linea.Replace(aux1, $"█{Comentarios_Index}\n");
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
                            linea = linea.Replace(aux, $"█{Comentarios_Index}");
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
                            linea = linea.Replace(linea, $"█{Comentarios_Index}\n");
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


            return stringless;
        }
        string parseComentarioUnilinea(string linea)
        {
            var comented = linea.IndexOf("//");
            //Comentarios.Add($"█{Comentarios_Index}", linea.Remove(0, comented));
            var aux = linea.Remove(0, comented);
            linea = linea.Replace(aux, $"█{Comentarios_Index}");
            AgregarComentario(aux);

            return linea;
        }

        void AgregarComentario(string comentario)
        {
            Comentarios.Add($"█{Comentarios_Index}", comentario);
            Comentarios_Index++;
        }

    }
}