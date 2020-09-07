using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data
{

    class GrammarValidation
    {
        private static GrammarValidation _instance = null;
        public static GrammarValidation Instance
        {
            get
            {
                if (_instance == null) _instance = new GrammarValidation();
                return _instance;
            }
        }
        private static List<string> outPutTokens = new List<string>();
        public void Lab1()
        {
            for (int i = 0; i < outPutTokens.Count; i++)
            {
                var lol = outPutTokens[i];
            }
        }


        public void pushIntoList(string token)
        {
            outPutTokens.Add(token);
        }
    }

}
