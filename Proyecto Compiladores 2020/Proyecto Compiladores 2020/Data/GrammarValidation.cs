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
        private static List<KeyValuePair<string,string>> outPutTokens = new List<KeyValuePair<string, string>>();
        private static List<string> sintaxError = new List<string>();
        
        private static int contador = 0;
        private static string lookahead="";
        public void Lab1()
        {
            for (int i = 0; i < outPutTokens.Count; i++)
            {
                var lol = outPutTokens[i];
            }
        }

        private void MatchToken(string expectedToken)
        {
            try
            {
                if (lookahead == expectedToken)
                {
                    contador++;
                    lookahead = outPutTokens[contador].Item1;
                }
                else
                {
                    if (lookahead == "$")
                    {
                        errores.Add($"Error sintactico: se esperaba ' {expectedToken} ' y ya no se tenian tokens.");
                    }
                    else
                    {
                        errores.Add($"Error sintactico: se esperaba ' {expectedToken} ' y se tenia ' {lookahead} '. {ObtenerUbicacion(tokens[contador == 0 ? contador : contador - 1].Item2)}");
                    }

                }
            }
            catch (Exception)
            {
                // se terminaron los tokens a leer 
                throw;
            }
        }




        public void pushIntoList(string token)
        {
            outPutTokens.Add(token);
        }
    }

}
