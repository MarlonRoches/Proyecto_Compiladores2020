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
        #region Pre hechas

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
        #endregion




        //propias
        private bool Stmt()
        {
            if (Stmt_Prime())
            {
                Stmt();
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool Stmt_Prime()
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
            MatchToken("while");
            MatchToken("(");

            if (Expr())
            {
                MatchToken(")");
                Stmt();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ifStatement()
        {
            MatchToken("if");
            MatchToken("(");
            if (Expr())
            {
                MatchToken(")");
                if (Stmt())
                {
                    IfStmt();
                }
                return true;
            }
            return false;
        }

        private bool IfStmt()
        {
            MatchToken("else");
            if (Stmt())
            {
                return true;
            }
            return true;
        }

        private bool Expr()
        {
            //Expr 			-> B Expr'

            if (B())
            {
                Expr_Prime();

                return true;
            }
            else
            {
                return false;
            }

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
        }
        //tiene recursividad infinita con Lvalue y con Expr
        #region Expr Prop
        private bool Expr_Prime()
        {
            //Expr'			-> || B Expr' | ϵ
            MatchToken("||");
            if (B())
            {
                Expr_Prime();
                return Expr_Prime();
            }
            else { return true; }
        }
        private bool B()
        {//B				-> C B'
            if (C())
            {
                return B_Prime();
            }
            else
            {
                return false;

            }
        }
        private bool B_Prime()
        { //B'				-> && C | ϵ
            MatchToken("&&");
            if (C())
            {
                return true;
            }
            else
            {

                return true;
            }
        }

        private bool C()
        {
            if (D())
            {
                return C_Prime();
            }
            else
            {
                return false;

            }
        }
        private bool C_Prime()
        {
            //C'-> == D C' | != D C' | ϵ
            if (Actual_LookAhead == "==")
            {
                MatchToken("==");
                if (D())
                {
                    return C_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == "!=")
            {
                MatchToken("!=");
                if (D())
                {
                    return C_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool D()
        {
            if (E())
            {
                return D_Prime();
            }
            else
            {
                return false;

            }
        }
        private bool D_Prime()
        {
            //D'-> < E D' | <= E D' | > E D' | >= E D' | ϵ  
            if (Actual_LookAhead == "<")
            {
                MatchToken("<");
                if (E())
                {
                    return D_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == "<=")
            {
                MatchToken("<=");
                if (E())
                {
                    return D_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == ">")
            {
                MatchToken(">");
                if (E())
                {
                    return D_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == ">=")
            {
                MatchToken(">=");
                if (E())
                {
                    return D_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool E()
        {
            if (F())
            {
                return E_Prime();
            }
            else
            {
                return false;

            }
        }
        private bool E_Prime()
        {
            //E'-> +F E' | -F E' | ϵ 
            if (Actual_LookAhead == "+")
            {
                MatchToken("+");
                if (F())
                {
                    return E_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == "-")
            {
                MatchToken("-");
                if (F())
                {
                    return E_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool F()
        {
            if (G())
            {
                return F_Prime();
            }
            else
            {
                return false;

            }
            return false;
        }
        private bool F_Prime()
        {
            //F'-> *G F' | /G F' | %G F' | ϵ  
            if (Actual_LookAhead == "*")
            {
                MatchToken("*");
                if (G())
                {
                    return F_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == "/")
            {
                MatchToken("/");
                if (G())
                {
                    return F_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == "%")
            {
                MatchToken("%");
                if (G())
                {
                    return F_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool G()
        {
            if (Actual_LookAhead == "!")
            {
                MatchToken("!");
                return Expr();
            }
            else if (Actual_LookAhead == "-")
            {
                MatchToken("-");
                return Expr();
            }
            else
            {
                return H();
            }
        }
        private bool H()
        {
            if (I())
            {
                return H_Prime();
            }
            else
            {
                return false;

            }
        }
        private bool H_Prime()
        {
            //H'-> [Expr] Igual' H' | . ident Igual' H' | ϵ
            if (Actual_LookAhead == "[")
            {
                MatchToken("[");
                if (Igual_Prime())
                {
                    return H_Prime();
                }
                else
                {
                    return true;
                }
            }
            else if (Actual_LookAhead == ".")
            {
                MatchToken(".");
                MatchToken("ident");
                if (Igual_Prime())
                {
                    return H_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return H();
            }
        }
        private bool I()
        {
            if (Actual_LookAhead == "(")
            {
                if (Expr())
                {
                    MatchToken(")");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Actual_LookAhead == "New")
            {
                MatchToken("New");
                MatchToken("(");
                MatchToken("ident");
                MatchToken(")");
                return true;
            }
            else if (Constant())
            {
                return Constant();
            }
            else if (Actual_LookAhead == "ident")
            {
                MatchToken("ident");
                if (Igual_Prime())
                {
                    return Igual_Prime();
                }
                else
                {
                    return false;
                }
            }
            else if (Actual_LookAhead == "this")
            {
                MatchToken("this");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Igual_Prime()
        {
            if (Actual_LookAhead == "=")
            {
                return Expr();
            }
            else
            {
                return true;
            }

        }
        #endregion
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
