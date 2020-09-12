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
        private bool MatchToken(string expectedToken)
        {
            try
            {
                if (Actual_LookAhead == expectedToken)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Token: {Actual_LookAhead} ta nitido                         {tokenList[Indexer].Value}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Indexer++;
                    Actual_LookAhead = tokenList[Indexer].Key;
                    return true;
                }
                else
                {
                    if (Actual_LookAhead == "$")
                    {
                        //aqui se acabaron los tokens pero sigue esperando
                        Console.Write($"*** Err -.- Se esperaba ' ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{expectedToken}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" ' y tenemos ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"EOF");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($".\n");
                        return false;

                    }
                    else
                    {
                        Console.Write($"*** Err -.- Se esperaba ' ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{expectedToken}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" ' y tenemos ' ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{Actual_LookAhead}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" '.\n");
                        //amonos al siguiente ->->->
                        Indexer++;
                        Actual_LookAhead = tokenList[Indexer].Key;

                        return false;
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
                return Program_();
            }
            else
            {
                //#line 70
                return true;
            }
        }
        private bool Decl()
        {

            var flag1 = VariableDecl();
            var flag2 = true;
            if (flag1)
            {
                //la gramatica fué aceptada
                flag2 = false;
            }
            else if (flag1 == false)
            {//no pertenece, hacer el backtracking
                //backtrackin'
                Console.Clear();
                Indexer = 0;
                Actual_LookAhead = tokenList[Indexer].Key;
                flag2 = FunctionDecl();
            }
            //si alguna de las dos, da true, fue aceptada
            return flag1 || flag2;
        }
        private bool VariableDecl()
        {
            if (Variable())
            {

                return MatchToken(";");
            }
            else
            {
                //No pertenece a esta VariableDecl
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
            else if (Actual_LookAhead == "boolean")
            {
                MatchToken("boolean");
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

                //de Aqui
                MatchToken("ident");
                if (Actual_LookAhead == "()")
                {
                    MatchToken("()");
                    Stmt(); //ver más adelante
                    return true;
                }
                else
                {

                    MatchToken("(");
                    if (Formals())
                    {
                        MatchToken(")");
                        Stmt(); //ver más adelante
                        return true;
                    }
                }

                MatchToken(")");
                Stmt();
                return true;

            }
            else if (Actual_LookAhead == "void")
            {
                MatchToken("void");
                MatchToken("ident");
                if (Actual_LookAhead == "()")
                {
                    MatchToken("()");
                    if (Formals())
                    {
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
                    MatchToken("(");

                    if (Formals())
                    {
                        MatchToken(")");
                        Stmt(); //ver más adelante
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

                if (Actual_LookAhead != ")")
                {
                    // MatchToken(",");

                }

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
            //Stmt			-> Stmt' Stmt |ϵ fixear
            if (Stmt_Prime())
            {
                if (Actual_LookAhead == "$")
                {
                    return true;

                }
                else
                {
                    return Stmt();

                }
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
                //while
                return WhileStement();
            }
            else if (Actual_LookAhead == "if")
            {
                //if
                return ifStatement();
            }
            else if (Expr())
            {
                // falta expr

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
            //aqui  es donde se procseasa
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
            if (Actual_LookAhead == "else")
            {

                MatchToken("else");
                if (Stmt())
                {
                    return true;
                }
            }
            return true;
        }

        private bool Expr()
        {
            var lola = B();
            var lolo = Expr_Prime();
            //Expr  -> B Expr'
            return lola || lolo;

        }
        //tiene recursividad infinita con Lvalue y con Expr
        #region Expr Prop
        private bool Expr_Prime()
        {
            if (Actual_LookAhead == "||")
            {

                //Expr'			-> || B Expr' | ϵ
                MatchToken("||");
                if (B())
                {
                    return Expr_Prime();
                }
                else { return true; }
            }
            else
            {
                return B_Prime();
            }
        }
        private bool B()
        {//B				-> C B'
            return C() || B_Prime();

        }
        private bool B_Prime()
        { //B'				-> && C | ϵ

            if (Actual_LookAhead == "&&")
            {

                //Expr'			-> || B Expr' | ϵ
                MatchToken("&&");
                if (C())
                {

                    return Expr_Prime();
                }
                else { return true; }
            }
            else
            {
                return C_Prime();
            }

        }

        private bool C()
        {
            return D() || C_Prime();

        }
        private bool C_Prime()
        {
            //C'-> == D C' | != D C' | ϵ
            if (Actual_LookAhead == "==")
            {

                MatchToken("==");
                if (D())
                {

                    return Expr_Prime();
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

                    return Expr_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return D_Prime();
            }
        }
        private bool D()
        {
            return E() || D_Prime();

        }
        private bool D_Prime()
        {
            //D'-> < E D' | <= E D' | > E D' | >= E D' | ϵ  
            if (Actual_LookAhead == "<")
            {
                MatchToken("<");
                if (E())
                {

                    return Expr_Prime();
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

                    return Expr_Prime();
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

                    return Expr_Prime();
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

                    return Expr_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return E_Prime();
            }
        }
        private bool E()
        {
            return F() || E_Prime();

        }
        private bool E_Prime()
        {
            //E'-> +F E' | -F E' | ϵ 
            if (Actual_LookAhead == "+")
            {
                MatchToken("+");
                if (F())
                {
                    return Expr_Prime();
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
                    return Expr_Prime();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return F_Prime();
            }
        }
        private bool F()
        {
            return G() || F_Prime();
        }
        private bool F_Prime()
        {
            //F'-> *G F' | /G F' | %G F' | ϵ  
            if (Actual_LookAhead == "*")
            {
                MatchToken("*");
                if (G())
                {
                    return Expr_Prime();
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
                    return Expr_Prime();
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
                    return Expr_Prime();
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
            return I() || H_Prime();

        }
        private bool H_Prime()
        {
            //H'-> [Expr] Igual' H' | . ident Igual' H' | ϵ
            if (Actual_LookAhead == "[")
            {
                MatchToken("[");
                if (Igual_Prime())
                {
                    return Expr_Prime();
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
                    return Expr_Prime();
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
                return true;
            }
            else if (Actual_LookAhead == "ident")
            {
                MatchToken("ident");
                if (Igual_Prime())
                {
                    return true;
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
