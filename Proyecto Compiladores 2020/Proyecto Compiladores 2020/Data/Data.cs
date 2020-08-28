using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
        private static Dictionary<string, string> DiccionarioInvertido = new Dictionary<string, string>();
        private static Regex Keywords = new Regex(@"^(void|int|double|boolean|string|class|const|interface|null|this|extends|implements|for|while|if|else|return|break|New|System|out|println)$");
        private static Regex Operadores = new Regex(@"^(\+|-|\*|/|%|<|<=|>|>=|=|==|!=|&&|\|\||!|;|,|\.|\[|\]|\(|\)|{|}|\[\]|\(\)|{})$");
        private static Regex Boolean = new Regex("true|false");
        private static Regex IntegerRegx = new Regex(@"^([0-9]+)*$");
        private static Regex Identifier = new Regex(@"^([A-Z]|[a-z]|[$])([A-Z]|[a-z]|[$]|[0-9])*$");
        private static Regex Number = new Regex(@"^([0-9])+$");
        private static Regex HexaRegx = new Regex(@"^([0][xX])([0-9a-fA-F]+)$");
        private static Regex DoubleRegx = new Regex(@"([0-9])+([.])([0-9]+)?((([e]|[E])([+]|[-])?)[0-9]+)?$");
 
       
        public void Sustituir(string code, string ruta)
        {
          
            Reservadas_Sustitucion = DictionarySymbols();
            var pathNew = $"{Path.GetDirectoryName(ruta)}\\{Path.GetFileNameWithoutExtension(ruta)}.out";
            var OutPut = new FileStream(pathNew, FileMode.Create);
            var writer = new StreamWriter(OutPut);
            code = code.TrimEnd();

            foreach (var item in Reservadas_Sustitucion.Keys)
            {
                code = code.Replace($"{item}", $"{Reservadas_Sustitucion[item]}"); //revisar esta parte
            }
            foreach (var invert in Reservadas_Sustitucion)
            {
                DiccionarioInvertido.Add(invert.Value, invert.Key);
            }

            //aqui split por enters
            var codigoArray = code.Split('\n');
            int line = 0;

            //aqui se hace la validación de tokens
            for (int i = 0; i < codigoArray.Length; i++)
            {
                if (codigoArray[i] != "")
                {
                    line = line + 1;
                }
                int colStart = 1;
                int ColEnd = 1;
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
                                    //palabra Clave
                                    int lenghtKey = DiccionarioInvertido[item.ToString()].Length;
                                    ColEnd = colStart + lenghtKey;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    writer.WriteLine($" {DiccionarioInvertido[item.ToString()]}         line {line} cols {colStart}-{ColEnd} is T_{DiccionarioInvertido[item.ToString()]}");
                                    ///Console.WriteLine($" {DiccionarioInvertido[item.ToString()]}    line {line} cols {colStart}-{ColEnd} is T_{DiccionarioInvertido[item.ToString()]}");
                                    colStart += lenghtKey;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }
                                else if (Operadores.IsMatch(DiccionarioInvertido[item.ToString()]))
                                {
                                    // 
                                    int lenghtOperator = DiccionarioInvertido[item.ToString()].Length;
                                    ColEnd = colStart + lenghtOperator;
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    writer.WriteLine($" {DiccionarioInvertido[item.ToString()]}         line {line} cols {colStart + 1}-{ColEnd} is {DiccionarioInvertido[item.ToString()]}");
                                    ///Console.WriteLine($" {DiccionarioInvertido[item.ToString()]}    line {line} cols {colStart+1}-{ColEnd} is {DiccionarioInvertido[item.ToString()]}");
                                    colStart += lenghtOperator;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;

                                    LineaActual = LineaActual.Remove(0, 1);
                                }

                            }
                            //comentarios y comentarios
                            else if (item.ToString() == "█" || item.ToString() == "▄" || item.ToString() == "┘" || item.ToString() == "┌" || item.ToString() == "¦")
                            {
                                //-------------------------- ERRORES -------------------------------


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
                                    ///Console.WriteLine($"{TextValidation.Instance.GetComentario(comentarios)}    line {line} cols {colStart}-{ColEnd} is  (value = {TextValidation.Instance.GetComentario(comentarios)}");
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
                                    writer.WriteLine($"{TextValidation.Instance.GetString(Cadena)}  line {line} cols {colStart}-{ColEnd} is (value = {TextValidation.Instance.GetString(Cadena)}");
                                    ///Console.WriteLine($"{TextValidation.Instance.GetString(Cadena)}  line {line} cols {colStart}-{ColEnd} is (value = {TextValidation.Instance.GetString(Cadena)}");
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
                                    Console.WriteLine($"Unmatched end of comment {comentarioSinabrir}");
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

                                    if (i== codigoArray.Length-1)
                                    {
                                        Console.WriteLine($"EOF ERROR DE CADENA SIN CERRAR");
                                    }
                                    else
                                    {

                                        Console.WriteLine($" ***line {line}.*** ERROR DE CADENA SIN CERRAR {stringSinCerrar}");
                                    }
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

                                        if (characterActual.ToString() == "ª")
                                            {
                                            if (IntegerRegx.IsMatch(idActual))
                                            {
                                                idActual += "ª";
                                                var lol = DoubleProces(idActual, LineaActual);
                                                var arr = lol.Split('^')[1];
                                                if (LineaActual == arr)
                                                {
                                                    var idActualaux = idActual.Substring(0, idActual.IndexOf('ª'));
                                                    LineaActual = $"ª{LineaActual.Replace(idActual,"")}";
                                                    idActual = idActualaux;
                                                }
                                                else
                                                {   
                                                idActual = lol.Split('^')[0];
                                                LineaActual = lol.Split('^')[1];
                                                }
                                            }
                                        }
                                        if (item.ToString() == "\t")
                                        {
                                            LineaActual = LineaActual.Remove(0, 1);
                                            colStart = colStart + 8;
                                        }
                                        else if (characterActual.ToString() == " ")
                                        {
                                           // LineaActual = LineaActual.Remove(0, 1);
                                            colStart++;

                                        }
                                        indexer++;
                                        //aqui ver lo de los raritos x0ajonadnjd
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
                                    writer.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Boolean");
                                    ///Console.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Boolean");
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
                                    ColEnd = colStart + lenghtIdentifier -1;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    if (idActual.Length>=31)
                                    {
                                        var trucado = idActual.Substring(0, 31);
                                    // MOSTRAR ERROR POR CARACTER MUY LARGO

                                    Console.BackgroundColor= ConsoleColor.White;
                                        writer.WriteLine();

                                        writer.WriteLine($" {trucado}          line {line} cols {colStart}-{ColEnd} is T_Identifier, ERR_ Legth > 31");
                                        ///Console.WriteLine($" {trucado}          line {line} cols {colStart}-{ColEnd} is T_Identifier, ERR_ Legth > 31");
                                    Console.BackgroundColor= ConsoleColor.Black;
                                    }
                                    else
                                    {
                                        writer.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Identifier");

                                        ///Console.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Identifier");

                                    }
                                    colStart += lenghtIdentifier;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0,idActual.Length);
                                    indexer = 0;
                                    break;
                                    // LineaActual = LineaActual.Remove(0, idActual.Length);
                                }
                               
                                else if (HexaRegx.IsMatch(idActual))
                                {
                                    int lenghtDoubleRegx = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtDoubleRegx;
                                    Console.ForegroundColor = ConsoleColor.Yellow;


                                    writer.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_HexConstant (value = {idActual}");
                                    //Console.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_HexConstant (value = {idActual}");
                                    colStart += lenghtDoubleRegx;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                }
                                else if (DoubleRegx.IsMatch(idActual))
                                {
                                    int lenghtDouble = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtDouble;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    writer.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Double ( value = {idActual})");

                                    ///Console.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_Double ( value = {idActual})");
                                    colStart += lenghtDouble;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    indexer = 0; break;

                                }
                                else if (IntegerRegx.IsMatch(idActual))
                                {
                                    int lenghtInteger = idActual.ToString().Length;
                                    ColEnd = colStart + lenghtInteger;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    writer.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");

                                    ///Console.WriteLine($" {idActual}         line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");
                                    colStart += lenghtInteger;
                                    ColEnd = 0;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    LineaActual = LineaActual.Remove(0, idActual.Length);
                                    indexer = 0; break;

                                    // LineaActual = LineaActual.Remove(0, idActual.Length-1);
                                }
                                else
                                {
                                    var validation = "";
                                    var aux = "";
                                    for (int j = 0; j < idActual.Length; j++)
                                    {
                                        validation += idActual[j];
                                        var fff = IntegerRegx.IsMatch(validation);
                                        if ( Identifier.IsMatch(validation[0].ToString()))
                                        {
                                            var fact = validation[0].ToString();
                                            var k = j+1;
                                            while (Identifier.IsMatch(fact))
                                            {
                                                fact += idActual[k];
                                                k++;
                                            }
                                            fact = fact.Substring(0, fact.Length - 1);
                                            LineaActual = LineaActual.Remove(0, fact.Length);
                                            idActual = fact;
                                            indexer = 0;
                                            //FACTORIADO en string

                                            writer.WriteLine($" {fact}         line {line} cols {colStart}-{ColEnd} is T_Identifier (value = {idActual})");
                                            ///Console.WriteLine($" {fact}         line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");

                                            break;
                                        }
                                        else if(IntegerRegx.IsMatch(validation[0].ToString()))
                                        {
                                            var fact = validation[0].ToString();
                                            var k = j + 1;
                                            while (IntegerRegx.IsMatch(fact))
                                            {
                                                fact += idActual[k];
                                                k++;
                                            }

                                            fact = fact.Substring(0, fact.Length - 1);
                                            LineaActual = LineaActual.Remove(0, fact.Length);
                                            indexer = 0;
                                            //FACTORIADO en string
                                            idActual = fact;

                                            writer.WriteLine($" {fact}         line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");
                                           /// Console.WriteLine($" {fact}         line {line} cols {colStart}-{ColEnd} is T_IntConstant (value = {idActual})");

                                            break;
                                        }
                                        else
                                        {
                                            //mostramos error
                                            aux = validation.Substring(0, validation.Length);
                                            Console.WriteLine($"*** line {line}.*** Unrecognized char: '{aux}'");
                                            idActual = aux;
                                            indexer = 0;
                                            LineaActual = LineaActual.Remove(0, idActual.Length);

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
            }
            
            writer.Close();
            OutPut.Close();
        }


        public Dictionary<string, string> DictionarySymbols()
        {
            Dictionary<string, string> Reservadas_Sustitución = new Dictionary<string, string>();
            Reservadas_Sustitución.Add("void", "◙");
            Reservadas_Sustitución.Add("println", "▼");
            Reservadas_Sustitución.Add("double", "♀");
            Reservadas_Sustitución.Add("boolean", "♪");
            Reservadas_Sustitución.Add("string", "♫");
            Reservadas_Sustitución.Add("class", "☼");
            Reservadas_Sustitución.Add("const", "►");
            Reservadas_Sustitución.Add("interface", "◄");
            Reservadas_Sustitución.Add("null", "↕");
            Reservadas_Sustitución.Add("this", "‼");
            Reservadas_Sustitución.Add("extends", "¶");
            Reservadas_Sustitución.Add("implements", "§");
            Reservadas_Sustitución.Add("for", "▬");
            Reservadas_Sustitución.Add("while", "↨");
            Reservadas_Sustitución.Add("if", "↑");
            Reservadas_Sustitución.Add("else", "↓");
            Reservadas_Sustitución.Add("return", "→");
            Reservadas_Sustitución.Add("break", "←");
            Reservadas_Sustitución.Add("New", "∟");
            Reservadas_Sustitución.Add("System", "↔");
            Reservadas_Sustitución.Add("out", "▲");
            Reservadas_Sustitución.Add("+", "Ç");
            Reservadas_Sustitución.Add("-", "ü");
            Reservadas_Sustitución.Add("*", "â");
            Reservadas_Sustitución.Add("/", "å");
            Reservadas_Sustitución.Add("%", "ë");
            Reservadas_Sustitución.Add("==", "ô");
            Reservadas_Sustitución.Add("!=", "û");
            Reservadas_Sustitución.Add("<=", "Å");
            Reservadas_Sustitución.Add(">=", "╜");
            Reservadas_Sustitución.Add("&&", "ÿ");
            Reservadas_Sustitución.Add("||", "Ö");
            Reservadas_Sustitución.Add("!", "¢");
            Reservadas_Sustitución.Add(";", "₧");
            Reservadas_Sustitución.Add(",", "ƒ");
            Reservadas_Sustitución.Add(".", "ª");
            Reservadas_Sustitución.Add("[]", "╣");
            Reservadas_Sustitución.Add("()", "╗");
            Reservadas_Sustitución.Add("{}", "╝");
            Reservadas_Sustitución.Add("int", "♂");
            Reservadas_Sustitución.Add("[", "⌐");
            Reservadas_Sustitución.Add("]", "½");
            Reservadas_Sustitución.Add("(", "¼");
            Reservadas_Sustitución.Add(")", "«");
            Reservadas_Sustitución.Add("{", "»");
            Reservadas_Sustitución.Add("}", "╕");
            Reservadas_Sustitución.Add(">", "æ");
            Reservadas_Sustitución.Add("<", "Ä");
            Reservadas_Sustitución.Add("=", "Æ");
            return Reservadas_Sustitución;
        }

        string DoubleProces(string actual, string resto)
            {
            var doubleStr = "";
            var traducida = TraducirLinea(resto);
            var PostE = "";

            if (traducida.IndexOf(".")!= -1)
            {
                doubleStr += traducida.Substring(0, traducida.IndexOf(".")+1);
                traducida = traducida.Replace(doubleStr, "");
                if (traducida.IndexOf("E+") != -1 || traducida.IndexOf("e+") != -1)
                {
                    if (traducida.IndexOf("E+") != -1)
                    {
                        doubleStr += traducida.Substring(0, traducida.IndexOf("E+") + 2);
                        traducida = traducida.Remove(0, (traducida.Substring(0, traducida.IndexOf("E+") + 2)).Length);

                    }
                    else 
                    {
                        doubleStr += traducida.Substring(0, traducida.IndexOf("e+") + 2);
                        traducida = traducida.Remove(0, (traducida.Substring(0, traducida.IndexOf("e+") + 2)).Length);

                    }

                    for (int i = 0; i < traducida.Length; i++)
                    {
                        var xd = traducida[i];
                        if (Reservadas_Sustitucion.ContainsKey(xd.ToString()) )
                        {
                            traducida = traducida.Remove(0, traducida.IndexOf(xd.ToString()));
                            doubleStr += PostE;
                            break;
                        }
                        else
                        {
                            PostE += xd;
                        }
                    }

                }
                else
                {
                    // no tiene potencia
                    for (int i = 0; i < traducida.Length; i++)
                    {
                        var xd = traducida[i];
                        if (Reservadas_Sustitucion.ContainsKey(xd.ToString()) || xd.ToString() == " " || xd.ToString() == "\t" || xd.ToString() == "\n" || xd.ToString() == "\r" || xd.ToString() == "\t" || xd.ToString() == "\n" || xd.ToString() == "█" || DiccionarioInvertido.ContainsKey(xd.ToString()) || xd.ToString() == "█" || xd.ToString() == "█" || xd.ToString() == "▄" || xd.ToString() == "┘" || xd.ToString() == "┌" || xd.ToString() == "¦")
                        {
                            traducida = traducida.Remove(0, traducida.IndexOf(xd.ToString()));
                            break;
                        }
                        else
                        {
                            doubleStr += xd;
                        }
                    }

                }

                
                if (DoubleRegx.IsMatch(doubleStr))
                {
                    actual = doubleStr;
                    resto = resto.Remove(0, resto.Length - traducida.Length);
                    return $"{actual}^{resto}";
                }
                else if(PostE =="")
                {
                    if (doubleStr.Contains("E"))
                    {
                    actual = doubleStr.Substring(0,doubleStr.IndexOf("E"));

                    }
                    else
                    {
                        actual = doubleStr.Substring(0,doubleStr.IndexOf("e"));

                    }

                    resto = resto.Remove(0, actual.Length);
                    return $"{actual}^{resto}";
             
                }
                else
                {
                    return $"{actual}^{resto}";

                }

            }
            else
            {
                    return $"{actual}^{resto}";
            }

        }

        private string TraducirLinea(string linea)
        {
            foreach (var item in DiccionarioInvertido)
            {
                if (linea.Contains(item.Key.ToString()))
                {
                linea = linea.Replace($"{item.Key}", DiccionarioInvertido[$"{item.Key}"]);
                }
            }
            return linea;
        }
    }
}
