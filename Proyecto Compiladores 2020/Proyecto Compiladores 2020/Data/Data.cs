using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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
        
        public void Sustituir(string code)
        {

            var file= new StreamReader("Reservadas.txt");
            Reservadas_Sustitucion = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());

            var CodeArray = code.Split();

            foreach (var item in CodeArray)
            {
                if (Reservadas_Sustitucion.ContainsKey(item))
                {

                }
            }
        }

    }
}
