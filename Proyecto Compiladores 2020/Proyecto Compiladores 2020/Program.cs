using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Compiladores_2020.Data;
using Newtonsoft.Json;

namespace Proyecto_Compiladores_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linea De Codigo Java");
            Data.Data.Instance.Sustituir("");
            
            Dictionary<string, string> ldiccionariol = new Dictionary<string, string>();
            
            ldiccionariol.Add("void"        ,"◙");
            ldiccionariol.Add("int"         ,"♂");
            ldiccionariol.Add("double"      ,"♀");
            ldiccionariol.Add("boolean"     ,"♪");
            ldiccionariol.Add("string"      , "♫");
            ldiccionariol.Add("class"       ,"☼");
            ldiccionariol.Add("const"       ,"►");
            ldiccionariol.Add("interface    ","◄");
            ldiccionariol.Add("null"        ,"↕");
            ldiccionariol.Add("this"        ,"‼");
            ldiccionariol.Add("extends"     ,"¶");
            ldiccionariol.Add("implements"  ,"§");
            ldiccionariol.Add("for"         ,"▬");
            ldiccionariol.Add("while"       ,"↨");
            ldiccionariol.Add("if"          ,"↑");
            ldiccionariol.Add("else"        ,"↓");
            ldiccionariol.Add("return"      ,"→");
            ldiccionariol.Add("break"       ,"←");
            ldiccionariol.Add("New"         ,"∟");
            ldiccionariol.Add("System"      ,"↔");
            ldiccionariol.Add("out"         ,"▲");
            ldiccionariol.Add("println"     ,"▼");
            ldiccionariol.Add("+"           ,"Ç");
            ldiccionariol.Add("-"           ,"ü");
            ldiccionariol.Add("*"           ,"â");
            ldiccionariol.Add("/"           ,"å");
            ldiccionariol.Add("%"           ,"ë");
            ldiccionariol.Add("<"           ,"Ä");
            ldiccionariol.Add("<="          ,"Å");
            ldiccionariol.Add(">"           ,"æ");
            ldiccionariol.Add("="           ,"Æ");
            ldiccionariol.Add("=="          ,"ô");
            ldiccionariol.Add("!="          ,"û");
            ldiccionariol.Add("&&"          ,"ÿ");
            ldiccionariol.Add("||"          ,"Ö");
            ldiccionariol.Add("!"           ,"¢");
            ldiccionariol.Add(";"           ,"₧");
            ldiccionariol.Add(","           ,"ƒ");
            ldiccionariol.Add("."           ,"ª");
            ldiccionariol.Add("["           ,"⌐");
            ldiccionariol.Add("]"           ,"½");
            ldiccionariol.Add("("           ,"¼");
            ldiccionariol.Add(")"           ,"«");
            ldiccionariol.Add("{"           ,"»");
            ldiccionariol.Add("}"           ,"╕");
            ldiccionariol.Add("[]"          ,"╣");
            ldiccionariol.Add("()"          ,"╗");
            ldiccionariol.Add("{}"          ,"╝");
            ldiccionariol.Add(">="          ,"╜");
            //{ } [] () {}
            var json5 = JsonConvert.SerializeObject(ldiccionariol);
            int numerooo = 126123;  

            //id		
            TOKEN 1 = LETRA.(LETRA|DIGITO)*
            json5
            //integer
            TOKEN 2 = DIGITO.DIGITO* 
                15654

            //string    
            TOKEN 3 = '"'.LETRA(LETRA|DIGITO)*.'"'
                "asdasdasd"
            //Bool   
            TOKEN 4=(TRUE|FALSE)
            true
                //double
            TOKEN 5 = DIGITO.DIGITO*.'.'DIGITO.DIGITO*
                5.21651

            //integer asignado
            TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' '*.DIGITO.DIGITO *.' '*.';'
                     int    numero                          =            1565;
            //string asignado
            TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' ' *.'"'.LETRA(LETRA|DIGITO)*.'"'.' '*.';'
                     int numero = 1565;

        }
    }
}
