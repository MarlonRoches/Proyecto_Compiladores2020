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
            Regex Digit = new Regex(@"^([0-9]+)*$");
            Regex Hexadecimal = new Regex(@"^(0[xX]).([0-9a-fA-F]+)$");
            Regex Double = new Regex(@"^(([0-9]+.[0-9]+|.[0-9]+)|([0-9]+.(E|e)(-|\+)?[0-9]+))$");
            Regex Identifier = new Regex(@"^([A-Za-z]+[0-9]*)$");

            var file = new StreamReader("Reservadas.txt");
            Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
            file.Close();

            var fileCode = new StreamReader("TestCode.txt");
            var rawCode = code;
            var dictionaryinvert = new Dictionary<string, string>();
            //var rawCode = fileCode.ReadToEnd();

            fileCode.Close();
            foreach (var item in Reservadas_Sustitucion.Keys)
            {
               
                    rawCode = rawCode.Replace($"{item}", $" {Reservadas_Sustitucion[item]} ");
                
            }
            foreach (var invert in Reservadas_Sustitucion)
            {
                dictionaryinvert.Add(invert.Value,invert.Key);
            }

            //aqui split por enters
            int colStart = 1;
            int line = 0;
            int ColEnd = 0;
            string token = "";
            bool flag = true;
            var CodeArray = rawCode.Split('\n');
            //aqui se hace la validación de tokens
            foreach (var tokenActual in CodeArray)
            {
                line++;
                ColEnd = 0;
                colStart = 0;
                var indexer = 0;
                foreach (var item1 in tokenActual)
                {

                    if (Convert.ToString(item1) == " " || Convert.ToString(item1) == "\t"  || Convert.ToString(item1) == "\r")
                    {
                        if (Convert.ToString(item1) == " ")
                        {
                            colStart++;
                            indexer++;
                        }
                        else if (Convert.ToString(item1) == "\t")
                        {
                            colStart = colStart + 8;
                            indexer++;
                        }
                    }
                    else
                    {
                        if (dictionaryinvert.ContainsKey(item1.ToString()))
                        {
                            if (Keywords.IsMatch(token = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key))
                            {
                                int length = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key.Length;
                                ColEnd += colStart + length;
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " T_" + token);
                                colStart = 0;
                                indexer++;
                            }
                            else if (Operadores.IsMatch(token = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key))
                            {
                                int lenghtoperator = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key.Length;
                                ColEnd += colStart + lenghtoperator;
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " T_" + token);
                                colStart = 0;
                                indexer++;
                            }
                            else if (Boolean.IsMatch(token = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key))
                            {
                                int lenghtboolean = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key.Length;
                                ColEnd += colStart + lenghtboolean;
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " T_" + "Boolean");
                                colStart = 0;
                                indexer++;
                            }
                           
                        }
                        else
                        {
                            var prueba = tokenActual.Length;
                            var aux = tokenActual.Remove(0, indexer);
                            
                            var id = "";
                            
                            foreach (var actualCharacter in aux)
                            {

                                if (actualCharacter.ToString() == " " || actualCharacter.ToString() == "\t" || actualCharacter.ToString() == "\n" || actualCharacter.ToString() == "\r" || dictionaryinvert.ContainsKey(actualCharacter.ToString()))
                                {
                                    if (Convert.ToString(actualCharacter) == " ")
                                    {
                                        colStart++;
                                        indexer++;
                                        
                                    }
                                    else if (Convert.ToString(actualCharacter) == "\t")
                                    {
                                        colStart = colStart + 8;
                                        indexer++;
                                        
                                    }
                                    break;
                                }
                                else
                                {
                                    id += actualCharacter;
                                } 
                            }
                        }

                    }
                   
                }

            }
            
        }
       

    }
}
