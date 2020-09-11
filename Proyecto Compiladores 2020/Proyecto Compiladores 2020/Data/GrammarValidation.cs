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
        private bool Program_Prime()
        {
            if (Actual_LookAhead != "$")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Decl()
        {
            return VariableDecl() || FunctionDecl();
        }
        private bool VariableDecl()
        {
            if (Variable())
            {
                MatchToken(";");
                return true;
            }
            else
            {
                //Error no cumple con la gramatica
                return false;
            }


        }
        private bool Variable()
        {
            if (Type())
            {
                MatchToken("ident");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Type()
        {
            if (Actual_LookAhead == "int")
            {
                MatchToken("int");
                return Type_Prime();

            }
            else if (Actual_LookAhead == "double")
            {
                MatchToken("double");
                return Type_Prime();
            }
            else if (Actual_LookAhead == "string")
            {
                MatchToken("string");
                return Type_Prime();
            }
            else if (Actual_LookAhead == "ident")
            {
                MatchToken("ident");
                return Type_Prime();

            }
            else
            {
                return false;
            }
        }
        private bool Type_Prime()
        {
            if (Actual_LookAhead == "[]")
            {
                MatchToken("[]");
                Type_Prime();

                return true;
            }
            return true;
        }
        private bool FunctionDecl()
        {
            if (Type())
            {
                MatchToken("ident");
                MatchToken("(");
                if (Formals())
                {
                    MatchToken(")");
                    Stmt(); //ver más adelante
                    return true;
                }

                MatchToken(")");
                Stmt();
                return true;

            }
            else if (Actual_LookAhead == "void")
            {
                MatchToken("void");
                MatchToken("ident");
                MatchToken("(");
                if (Formals())
                {

                    //MatchToken("ident");
                    //MatchToken("(");
                    //if (Actual_LookAhead != ")")
                    //{
                    //    Formals();
                    //}

                    //MatchToken(")");
                    //Stmt();
                    //return true;
                    MatchToken(")");
                    Stmt(); //ver más adelante
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        private bool Formals()
        {
            if (Variable())
            {
                Variable_Prime();
                MatchToken(",");
                return true;
            }
            else
            {//eps
                return true;
            }

        }
        private bool Variable_Prime()
        {
            if (Actual_LookAhead == ",")
            {
                MatchToken(",");
                if (Variable())
                {
                    Variable_Prime();
                    return true;
                }
            }
            else
            {
                return true;
            }

            return true;
        }
        private bool Stmt()
        {
            if (Stmt_Options())
            {
                Stmt();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool Stmt_Options()
        {
            if (Actual_LookAhead == "while")
            {
                //if
                return WhileStement();
            }
            else if (Actual_LookAhead == "if")
            {
                //while
                return ifStatement();
            }
            else if (Expr())
            {
                // falta expr
                Expr();
                MatchToken(";");
                return true;

            }
            else
            {
                return false;

            }
        }
        private bool WhileStement()
        {
            MatchToken("for");
            MatchToken("(");

            if (ExprP())
            {
                MatchToken(";");
            }
            else { MatchToken(";"); }
            if (Expr())
            {
                MatchToken(";");
            }
            else { MatchToken(";"); }
            if (ExprP())
            {
                MatchToken(";");
            }
            else { MatchToken(";"); }
            MatchToken(")");
            if (Stmt())
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        private bool ifStatement()
        {
            MatchToken("return");
            if (ExprP())
            {
                MatchToken(";");
                return true;
            }
            else
            {
                MatchToken(";");
                return true;
            }
        }

        private bool ExprP()
        {
            //if (Expr())
            //{
            //    return true;
            //}
            //else { return false; }
            return true;
        }
        private bool Expr()
        {
            // para hacer backtraking
            //IndexerAux = Indexer;

            //if (Lvalue())
            //{
            //    if (Actual_LookAhead == "=")
            //    {
            //        MatchToken("=");
            //        if (P())
            //        {
            //            return true;
            //        }
            //        else { return false; }
            //    }
            //    else
            //    {
            //        Indexer = IndexerAux;
            //        return P();

            //    }

            //}
            //else
            //{
            //    return P();
            //}
            return true;
        }
        //tiene recursividad infinita con Lvalue y con Expr
        #region Expr Prop
        private bool P()
        {
            return T() && P();
        }
        private bool PP()
        {
            if (Actual_LookAhead == "||")
            {
                MatchToken("||");
                return T() && PP();
            }
            else
            {
                return true;
            }
        }
        private bool T()
        {
            return H() && TP();
        }
        private bool TP()
        {
            if (Actual_LookAhead == "&&")
            {
                MatchToken("&&");
                return H() && TP();
            }
            else
            {
                return true;
            }
        }
        private bool H()
        {
            return F() && HP();
        }
        private bool HP()
        {
            if (Actual_LookAhead == "==")
            {
                MatchToken("==");
                F();
                HP();
                return true;
            }
            else if (Actual_LookAhead == "!=")
            {
                MatchToken("!=");
                F();
                HP();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool F()
        {
            return L() && FP();
        }
        private bool FP()
        {
            if (Actual_LookAhead == "<")
            {
                MatchToken("<");
                FP();
                return true;
            }
            else if (Actual_LookAhead == ">")
            {
                MatchToken(">");
                FP();
                return true;

            }
            else if (Actual_LookAhead == "<=")
            {
                MatchToken("<=");
                FP();
                return true;
            }
            else if (Actual_LookAhead == ">=")
            {
                MatchToken(">=");
                FP();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool L()
        {
            return M() && LP();
        }
        private bool LP()
        {
            if (Actual_LookAhead == "+")
            {
                MatchToken("+");
                LP();
                return true;
            }
            else if (Actual_LookAhead == "-")
            {
                MatchToken("-");
                LP();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool M()
        {
            return N() && MP();
        }
        private bool MP()
        {
            if (Actual_LookAhead == "*")
            {
                MatchToken("*");
                MP();
                return true;
            }
            else if (Actual_LookAhead == "/")
            {
                MatchToken("/");
                MP();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool N()
        {
            if (Actual_LookAhead == "-")
            {
                MatchToken("-");
                // duda si el return se podria poner expre
                Expr();
                return true;
            }
            else if (Actual_LookAhead == "!")
            {
                MatchToken("!");
                // duda si el return se podria poner expre
                Expr();
                return true;
            }
            else
            {
                return G();
            }
        }
        private bool G()
        {

            if (Actual_LookAhead == "(")
            {
                MatchToken("(");
                Expr();
                MatchToken(")");
                return true;
            }
            else if (Actual_LookAhead == "this")
            {
                MatchToken("this");
                return true;
            }
            else if (Actual_LookAhead == "New")
            {
                // duad sobre si se haria backtraking
                MatchToken("New");
                MatchToken("(");
                MatchToken("ident");
                MatchToken(")");
                return true;
            }
            else
            {
                return Constant();
            }
        }
        #endregion
        private bool Constant()
        {
            if (Actual_LookAhead == "intCostant")
            {
                MatchToken("intCostant");
                return true;
            }
            else if (Actual_LookAhead == "boolConstant")
            {
                MatchToken("boolConstant");
                return true;
            }
            else if (Actual_LookAhead == "doubleConstant")
            {
                MatchToken("doubleConstant");
                return true;
            }
            else if (Actual_LookAhead == "stringConstant")
            {
                MatchToken("stringConstant");
                return true;
            }
            else if (Actual_LookAhead == "null")
            {
                MatchToken("null");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void pushIntoList(string type, string dato)
        {
            tokenList.Add(new KeyValuePair<string, string>(type, dato));
        }




        //private bool Lvalue()
        //{
        //    if (Actual_LookAhead == "ident")
        //    {
        //        MatchToken("ident");

        //        return true;
        //    }
        //    else
        //    {
        //        if (Expr())
        //        {
        //            if (Actual_LookAhead == ".")
        //            {
        //                MatchToken(".");
        //                MatchToken("ident");
        //                return true;
        //            }
        //            else if (Actual_LookAhead == "[")
        //            {
        //                MatchToken("[");
        //                if (Expr())
        //                {
        //                    if (Actual_LookAhead == "]")
        //                    {
        //                        MatchToken("]");
        //                        return true;
        //                    }
        //                    else { return false; }
        //                }
        //                else { return false; }
        //            }
        //            else { return false; }
        //        }
        //        else { return false; }
        //    }
        //}
    }
}
