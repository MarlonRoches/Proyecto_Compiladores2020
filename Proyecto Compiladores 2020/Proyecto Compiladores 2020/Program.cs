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
            //Data.Data.Instance.Sustituir(Console.ReadLine());

            Dictionary<string, string> ldiccionariol = new Dictionary<string, string>();

            ldiccionariol.Add("void", "◙");
            ldiccionariol.Add("int","♂");
            ldiccionariol.Add("double","♀");
            ldiccionariol.Add("boolean","♪");
            ldiccionariol.Add("string", "♫");
            ldiccionariol.Add("class","☼");
            ldiccionariol.Add("const","►");
            ldiccionariol.Add("interface","◄");
            ldiccionariol.Add("null","↕");
            ldiccionariol.Add("this","‼");
            ldiccionariol.Add("extends","¶");
            ldiccionariol.Add("implements","§");
            ldiccionariol.Add("for","▬");
            ldiccionariol.Add("while","↨");
            ldiccionariol.Add("if","↑");
            ldiccionariol.Add("else","↓");
            ldiccionariol.Add("return","→");
            ldiccionariol.Add("break","←");
            ldiccionariol.Add("New","∟");
            ldiccionariol.Add("System","↔");
            ldiccionariol.Add("out","▲");
            ldiccionariol.Add("println","▼");

            var json5 = JsonConvert.SerializeObject(ldiccionariol);
        }
    }
}
