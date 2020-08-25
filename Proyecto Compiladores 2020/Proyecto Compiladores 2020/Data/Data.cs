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
            //var rawCode = fileCode.ReadToEnd();

            fileCode.Close();
            foreach (var item in Reservadas_Sustitucion.Keys)
            {
               
                    rawCode = rawCode.Replace($"{item}", $" {Reservadas_Sustitucion[item]} ");
                
            }

            //aqui split por enters
            int colStart = 1;
            int line = 0;
            int ColEnd = 0;
            string token = "";
            var CodeArray = rawCode.Split('\n');
            //aqui se hace la validación de tokens
            foreach (var tokenActual in CodeArray)
            {
                line++;
                ColEnd = 0;
                colStart = 0;
                string id = "";
                foreach (var item1 in tokenActual)
                {

                    if (Convert.ToString(item1) != " " && Convert.ToString(item1) != "\t" || Identifier.IsMatch(Convert.ToString(item1)))
                    {
                        
                        if (Reservadas_Sustitucion.ContainsValue(Convert.ToString(item1)))
                        {
                            //se valida las palabras reservadas 
                            if (Keywords.IsMatch(token = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key))
                            {
                                int length = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key.Length;
                                ColEnd += colStart + length;
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " T_" + token);
                                colStart = 0;
                            }
                            //se valida los operadores
                            else if (Operadores.IsMatch(token = Reservadas_Sustitucion.Where(p => p.Value == Convert.ToString(item1)).FirstOrDefault().Key))
                            {
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " T_" + token);
                                colStart = 0;
                            }
                            
                        }
                        //se valida los digitos
                        else if (Digit.IsMatch(Convert.ToString(item1)))
                        {
                            id += item1;
                            if (!Digit.IsMatch(Convert.ToString(item1)))
                            {
                                Console.WriteLine(token + " line:" + line + " Columna: " + colStart + "-" + ColEnd + " is " + " T_" + "(value = " + token + ")");
                                colStart = 0;
                            }
                            
                        }
                        //se valida los double
                       
                        else if (Identifier.IsMatch(Convert.ToString(item1)))
                        {
                            id += item1;
                            if (!Identifier.IsMatch(Convert.ToString(id)))
                            {
                                //se valida los booleanos
                                if (Boolean.IsMatch(Convert.ToString(id)))
                                {
                                    Console.WriteLine(Convert.ToString(id) + " linea: " + line + " Columna: " + colStart + "-" + ColEnd + " T_" + "Boolean");
                                    colStart = 0;
                                    id = "";
                                }
                                //se valida los identificadores
                                else
                                {
                                    Console.WriteLine(Convert.ToString(id) + " linea: " + line + " Columna: " + colStart + "-" + ColEnd + " T_" + "identifier");
                                    colStart = 0;
                                    id = "";
                                }
                                
                            }
                        
                        }
                        //se valida los hexadecimales
                        else if (Convert.ToString(item1) == "0" || Convert.ToString(item1) == "x" || Convert.ToString(item1) == "X")
                        {
                            id += item1;
                            if (Convert.ToString(id) == "x" || Convert.ToString(id) == "x")
                            {
                                
                            }
                        }
                        
                    }
                    else if (Convert.ToString(item1) == "\t")
                    {
                        colStart = colStart + 8;  
                    }
                    else
                    {
                        colStart++;
                    }
                }
  

            }
            var linea = Console.ReadLine();
        }
       

    }
}
