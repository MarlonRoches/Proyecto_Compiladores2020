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
        private static List<KeyValuePair<string, string>> tokenList = new List<KeyValuePair<string, string>>();
        private static List<string> sintaxError = new List<string>();
        private int IndexerAux = 0;
        private bool backExpr = false;
        private static int Indexer = 0;
        private static string Actual_LookAhead = "";

        public void LabA_Parser()
        {
            tokenList.Add(new KeyValuePair<string, string>("$", ""));
            Actual_LookAhead = tokenList[Indexer].Key;
            Program_();
        }
        private void MatchToken(string expectedToken)
        {
            try
            {
                if (Actual_LookAhead == expectedToken)
                {
                    Indexer++;
                    Actual_LookAhead = tokenList[Indexer].Key;
                }
                else
                {
                    if (Actual_LookAhead == "$")
                    {
                        Console.WriteLine($"* Se esperaba ' {expectedToken} '.");
                    }
                    else
                    {
                        Console.WriteLine($"* Se esperaba ' {expectedToken} ' y tenemos ' {Actual_LookAhead} '.");
                    }

                }
            }
            catch (Exception)
            {
                // final 
                throw;
            }
        }
        private bool Program_()
        {

            return Decl() && Program_Prime();

        }
       
    }
}
