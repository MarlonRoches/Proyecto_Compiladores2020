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
                    Comentarios.Add($"æ{Comentarios_Index}", linea.Remove(0, comented));
                    linea = linea.Replace(linea.Remove(0, comented), $"æ{Comentarios_Index}");
                    compressedCode += $"{linea}\n";
                    Comentarios_Index++;
                }
                else if (linea.Contains("/*"))
                {
                    //inicio de comentario multilinea
                    var actual = linea;
                    while (!linea.Contains("*/"))
                    {
                        linea += $"{fileCode.ReadLine()}";

                        if (linea.Contains("/*"))
                        {
                            //contiene inicio de comentario
                            //code ........... /*
                            var aux = linea.Remove(0, linea.IndexOf("/*"));
                            linea = linea.Replace(aux, $"æ{Comentarios_Index}\n");
                            AgregarComentario(aux);
                        }
                        else if (linea.Contains("*/"))
                        {
                            //contiene final de comentario
                            //*/  code......
                            var aux = linea.Remove(linea.IndexOf("*/"), linea.Length - 1);

                        }
                        else
                        {
                            //Medio comentarios
                            //agarrar todos los del medio

                        }
                        if (linea == null)
                        {
                            //error de comentario no cerrado

                            break;
                        }
                    }
                    //var comentarioMultilinea = linea.Remove(0, linea.IndexOf("/*"));
                    //comentarioMultilinea = comentarioMultilinea.Substring(0, comentarioMultilinea.IndexOf("*/") + 2);
                    //Comentarios.Add($"æ{Comentarios_Index}", comentarioMultilinea);
                    //linea = linea.Replace(comentarioMultilinea, $"æ{Comentarios_Index}");
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
        string parseComentarioUnilinea(string linea)
        {
            var comented = linea.IndexOf("//");
            Comentarios.Add($"æ{Comentarios_Index}", linea.Remove(0, comented));
            linea = linea.Replace(linea.Remove(0, comented), $"æ{Comentarios_Index}");
            Comentarios_Index++;
            return linea;
        }

        void AgregarComentario(string comentario)
        {
            Comentarios.Add($"æ{Comentarios_Index}", comentario);
            Comentarios_Index++;
        }
        string CleanCode(string rawCode)
        {
            var file = new StreamReader("Reservadas.txt");
            var Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();

            foreach (var item in Reservadas_Sustitucion.Keys)
            {
                rawCode = rawCode.Replace($"{item}", $" {item} ");
            }
            rawCode = rawCode.Replace("\r\n", "  ").Replace("\t", "  ").Replace(";", " ; ");
            while (rawCode.Contains("  "))
            {
                rawCode = rawCode.Replace("  ", " ");
            }
            rawCode = rawCode.Trim();
            return rawCode;
        }

        public void Error()
        {
            StreamReader streamReader = new StreamReader("TestCode.txt");
            int line = 0;
            int col = 0;
            while (!streamReader.EndOfStream)
            {
                string readline = streamReader.ReadLine();
                line++;
                string[] validate = readline.Split();

                //si se hace un substring se le puede hacer un col++  para poder saber la columna y su error

            }

        }
    }
}