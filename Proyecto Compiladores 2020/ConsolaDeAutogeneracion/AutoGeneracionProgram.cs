using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaDeAutogeneracion
{
    class AutoGeneracionProgram
    {

        static void Main(string[] args)
        {
         Dictionary<int, string> Reducciones = new Dictionary<int, string>();
            //
            var lol = nuevoDiccionario();
         

            Dictionary<string, string> nuevoDiccionario()
            {
                Reducciones.Add(0, "Start↓Program");
                Reducciones.Add(1, "Program↓Decl Program");
                Reducciones.Add(2, "Program↓Decl");
                Reducciones.Add(3, "Decl↓Type ident ;");
                Reducciones.Add(4, "Decl↓FRoot ident ( Formals ) StmtBlock");
                Reducciones.Add(5, "Decl↓static CnsTp ident ;");
                Reducciones.Add(6, "Decl↓class ident Heritage HeritageI {​​​​ FieldP }​​​​");
                Reducciones.Add(7, "Decl↓interface ident {​​​​ Proto }​​​​");
                Reducciones.Add(8, "Type↓CnsTp");
                Reducciones.Add(9, "Type↓ident");
                Reducciones.Add(10, "Type↓Type []");
                Reducciones.Add(11, "FRoot↓void");
                Reducciones.Add(12, "FRoot↓Type");
                Reducciones.Add(13, "Formals↓Type ident , Formals");
                Reducciones.Add(14, "Formals↓Type ident");
                Reducciones.Add(15, "StmtBlock↓{​​​​ SBPV SBPC SBPS }​​​​");
                Reducciones.Add(16, "CnsTp↓int");
                Reducciones.Add(17, "CnsTp↓double");
                Reducciones.Add(18, "CnsTp↓boolean");
                Reducciones.Add(19, "CnsTp↓string");
                Reducciones.Add(20, "Heritage↓extends ident");
                Reducciones.Add(21, "Heritage↓''");
                Reducciones.Add(22, "HeritageI↓implements ident HeritageD");
                Reducciones.Add(23, "HeritageI↓''");
                Reducciones.Add(24, "HeritageD↓, ident HeritageD");
                Reducciones.Add(25, "HeritageD↓''");
                Reducciones.Add(26, "FieldP↓Field FieldP");
                Reducciones.Add(27, "FieldP↓''");
                Reducciones.Add(28, "Field↓Type ident ;");
                Reducciones.Add(29, "Field↓FRoot ident ( Formals ) StmtBlock");
                Reducciones.Add(30, "Field↓static CnsTp ident ;");
                Reducciones.Add(31, "Proto↓Prototype Proto");
                Reducciones.Add(32, "Proto↓''");
                Reducciones.Add(33, "Prototype↓FRoot ident ( Formals ) ;");
                Reducciones.Add(34, "SBPV↓Type ident ; SBPV");
                Reducciones.Add(35, "SBPV↓''");
                Reducciones.Add(36, "SBPC↓static CnsTp ident ; SBPC");
                Reducciones.Add(37, "SBPC↓''");
                Reducciones.Add(38, "SBPS↓Stmt SBPS");
                Reducciones.Add(39, "SBPS↓''");
                Reducciones.Add(40, "Stmt↓Expr ;");
                Reducciones.Add(41, "Stmt↓;");
                Reducciones.Add(42, "Stmt↓if ( Expr ) Stmt ElseStmt");
                Reducciones.Add(43, "Stmt↓while ( Expr ) Stmt");
                Reducciones.Add(44, "Stmt↓for ( Expr ; Expr ; Expr ) Stmt");
                Reducciones.Add(45, "Stmt↓break ;");
                Reducciones.Add(46, "Stmt↓return Expr ;");
                Reducciones.Add(47, "Stmt↓System . out . println ( Expr ExPrint ) ;");
                Reducciones.Add(48, "Stmt↓StmtBlock");
                Reducciones.Add(49, "ElseStmt↓else Stmt");
                Reducciones.Add(50, "ElseStmt↓''");
                Reducciones.Add(51, "ExPrint↓, Expr ExPrint");
                Reducciones.Add(52, "ExPrint↓''");
                Reducciones.Add(53, "Expr↓ident = ExprOr");
                Reducciones.Add(54, "Expr↓ExprOr");
                Reducciones.Add(55, "ExprOr↓ExprOr != ExprOrP");
                Reducciones.Add(56, "ExprOr↓ExprOrP");
                Reducciones.Add(57, "ExprOrP↓ExprOrP || ExprAnd");
                Reducciones.Add(58, "ExprOrP↓ExprAnd");
                Reducciones.Add(59, "ExprAnd↓ExprAnd > ExprAndP");
                Reducciones.Add(60, "ExprAnd↓ExprAnd >= ExprAndP");
                Reducciones.Add(61, "ExprAnd↓ExprAndP");
                Reducciones.Add(62, "ExprAndP↓ExprAndP - ExprEquals");
                Reducciones.Add(63, "ExprAndP↓ExprEquals");
                Reducciones.Add(64, "ExprEquals↓ExprEquals / ExprEqualsP");
                Reducciones.Add(65, "ExprEquals↓ExprEquals % ExprEqualsP");
                Reducciones.Add(66, "ExprEquals↓ExprEqualsP");
                Reducciones.Add(67, "ExprEqualsP↓- ExprComp");
                Reducciones.Add(68, "ExprEqualsP↓! ExprComp");
                Reducciones.Add(69, "ExprEqualsP↓ExprComp");
                Reducciones.Add(70, "ExprComp↓ExprComp . ident = ExprCompP");
                Reducciones.Add(71, "ExprComp↓ExprComp . ident");
                Reducciones.Add(72, "ExprComp↓ExprCompP");
                Reducciones.Add(73, "ExprCompP↓( Expr )");
                Reducciones.Add(74, "ExprCompP↓this");
                Reducciones.Add(75, "ExprCompP↓ident");
                Reducciones.Add(76, "ExprCompP↓New ( ident )");
                Reducciones.Add(77, "ExprCompP↓intConstant");
                Reducciones.Add(78, "ExprCompP↓doubleConstant");
                Reducciones.Add(79, "ExprCompP↓boolConstant");
                Reducciones.Add(80, "ExprCompP↓stringConstant");
                Reducciones.Add(81, "ExprCompP↓null.Add");


                var salida = "";
                var campos = "ident↓;↓(↓)↓static↓class↓{↓}↓interface↓[]↓void↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓=↓!=↓||↓>↓>=↓-↓/↓%↓!↓this↓New↓intConstant↓doubleConstant↓boolConstant↓stringConstant↓null↓$↓Start↓Program↓Decl↓Type↓FRoot↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓ExprOr↓ExprOrP↓ExprAnd↓ExprAndP↓ExprEquals↓ExprEqualsP↓ExprComp↓ExprCompP".Split('↓');
                var reader = new StreamReader("gramatica.txt");
                var linea = reader.ReadLine();
                for (int i = 0; i < 180; i++)
                {
                   // salida += $"public bool Estado{i} (Stack<int> _Pila, string  _actual , string _lookahead  )\n";
                    //salida += $"public bool Estado{i} (string  _actual , string _lookahead  )\n";
                    salida += $"public bool Estado{i} (string _lookahead  )\n";
                    salida += "{\n";
                    var acciones = linea.Replace('\t', '↓').Split('↓');
                    //switch (lookahead)
                    salida += "switch (_lookahead) \n";

                    //{
                    salida += "{ \n";
                    for (int k = 0; k < campos.Length; k++)
                    {
                        
                        if (acciones[k] != "")
                        {
                            salida += $"\tcase \"{campos[k]}\":\n";
                            if (acciones[k].Contains("/"))
                            {
                                //CONFLICTO
                                //CONFLICTO

                                salida += $"\t\t// CONFLICTO a {acciones[k]}\n";

                                salida += $"\t\t//dConflicto desplazamiento  a {acciones[k].Split('/')[0].Trim()}\n";
                                salida += $"\t\t\t\t//consume {campos[k]}\n";
                                //StackDeEntrada
                                salida += $"StackDeEntrada.Pop();\n";
                                salida += $"StackDeConsumo.Push({acciones[k].Split('/')[0].Trim().Replace("d", "")});\n";
                                salida += "Simbolos += $\" { _lookahead} \";\n";
                                salida += "Simbolos = Simbolos.Trim();\n";

                                salida += $"\treturn Estado{acciones[k].Split('/')[0].Trim().Replace("d", "")}(StackDeEntrada.Peek());\n";
                                //salida += $"\treturn false;\n";
                                //salida += $"\tbreak;\n";
                            }
                            else
                            {
                                if (acciones[k].Contains("d"))
                                {

                                    salida += $"\t\t//desplazamiento a {acciones[k]}\n";
                                    salida += $"\t\t\t\t//consume {campos[k]}\n";
                                    //StackDeEntrada
                                    salida += $"StackDeEntrada.Pop();\n";
                                    salida += $"StackDeConsumo.Push({acciones[k].Replace("d", "")});\n";
                                    salida += "Simbolos += $\" { _lookahead} \";\n";
                                    salida += "Simbolos = Simbolos.Trim();\n";

                                    salida += $"\treturn Estado{acciones[k].Replace("d", "")}(StackDeEntrada.Peek());\n";
                                }
                                else if (acciones[k].Contains("r"))
                                {
                                    //reducciones
                                    salida += $"\t\t//reduccion a {acciones[k]}\n";
                                    salida += $"reduccion = Reducciones[{acciones[k].Replace("r","")}].Split('↓')[0].Trim();\n";
                                    salida += $" reducido = Reducciones[{acciones[k].Replace("r", "")}].Split('↓')[1].Trim();\n";
                                    if (Reducciones[int.Parse(acciones[k].Replace("r", ""))].Split('↓')[1]== "\'\'")
                                    {
                                        salida += $"\t\t//reduccion LAMBDA a {acciones[k]}\n";

                                        salida += "if (reducido == \"''\")";
                                        salida += "{";
                                        salida += "    Simbolos += $\" {reduccion}\";";
                                        salida += "}";
                                    }
                                    else
                                    {
                                        salida += $"Simbolos = Simbolos.Replace(reducido, reduccion);\n";
                                        salida += $"unStack = reducido.Split(' ').Length;\n";
                                        salida += $"for (int i = 0; i < unStack; i++)\n";
                                        salida += "{\n";
                                        salida += $"    StackDeConsumo.Pop();\n";
                                        salida += "}\n";
                                    }
                                    salida += $"return IrA(StackDeConsumo.Peek(), reduccion);\n";


                                }
                                else
                                {//irA
                                    salida += $"\t\t//irA {acciones[k]}\n";
                                    salida += $"\t\tStackDeConsumo.Push({acciones[k]});\n";
                                    salida += $"\treturn Estado{acciones[k]}(StackDeEntrada.Peek());\n";

                                }
                            }
                           
                            //salida += $"//\tbreak;\n\n";
                        }
                    }
                    salida += "default:\n";
                    salida += "Err();";
                    //
                    salida += "return false;\n";
                    //salida += "break;\n";
                    salida += "}\n";
                    salida += "}\n";
                    linea = reader.ReadLine();
                }

                reader.Close();


                var salidaDeIrA = "";
                for (int i = 0; i < 180; i++)
                {
                    salidaDeIrA +=$"case {i}:\n";
                    salidaDeIrA += $"//IrA Estado {i}\n";
                    salidaDeIrA += $"return Estado{i}( _lookahead);\n";
                    //salidaDeIrA +=$"break;\n";
                }
                return null;
            }
        }
    }
}
