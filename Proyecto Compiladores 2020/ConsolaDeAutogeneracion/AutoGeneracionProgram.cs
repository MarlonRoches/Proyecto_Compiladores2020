﻿using System;
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
            var estados = new Dictionary<int, Dictionary<string,string> >();
            var lol = nuevoDiccionario();
            //numer de estado actual , (token con el que se va, accion)
            Dictionary<string, string> nuevoDiccionario()
            {
                //Con Expr
                #region Diccionario

                Reducciones.Add(0, "Start↓Program");
                Reducciones.Add(1, "Program↓Decl Program");
                Reducciones.Add(2, "Program↓Decl");
                Reducciones.Add(3, "Decl↓Type ident ;");
                Reducciones.Add(4, "Decl↓Type ident ( Formals ) StmtBlock");
                Reducciones.Add(5, "Decl↓void ident ( Formals ) StmtBlock");
                Reducciones.Add(6, "Decl↓static CnsTp ident ;");
                Reducciones.Add(7, "Decl↓class ident Heritage HeritageI {​​​​ FieldP }​​​​");
                Reducciones.Add(8, "Decl↓interface ident {​​​​ Proto }​​​​");
                Reducciones.Add(9, "Type↓CnsTp");
                Reducciones.Add(10, "Type↓ident");
                Reducciones.Add(11, "Type↓Type []");
                Reducciones.Add(12, "Formals↓Type ident , Formals");
                Reducciones.Add(13, "Formals↓Type ident");
                Reducciones.Add(14, "StmtBlock↓{​​​​ SBPV SBPC SBPS }​​​​");
                Reducciones.Add(15, "CnsTp↓int");
                Reducciones.Add(16, "CnsTp↓double");
                Reducciones.Add(17, "CnsTp↓boolean");
                Reducciones.Add(18, "CnsTp↓string");
                Reducciones.Add(19, "Heritage↓extends ident");
                Reducciones.Add(20, "Heritage↓''");
                Reducciones.Add(21, "HeritageI↓implements ident HeritageD");
                Reducciones.Add(22, "HeritageI↓''");
                Reducciones.Add(23, "HeritageD↓, ident HeritageD");
                Reducciones.Add(24, "HeritageD↓''");
                Reducciones.Add(25, "FieldP↓Field FieldP");
                Reducciones.Add(26, "FieldP↓''");
                Reducciones.Add(27, "Field↓Type ident ;");
                Reducciones.Add(28, "Field↓FRoot ident ( Formals ) StmtBlock");
                Reducciones.Add(29, "Field↓static CnsTp ident ;");
                Reducciones.Add(30, "Proto↓Prototype Proto");
                Reducciones.Add(31, "Proto↓''");
                Reducciones.Add(32, "Prototype↓FRoot ident ( Formals ) ;");
                Reducciones.Add(33, "SBPV↓Type ident ; SBPV");
                Reducciones.Add(34, "SBPV↓''");
                Reducciones.Add(35, "SBPC↓static CnsTp ident ; SBPC");
                Reducciones.Add(36, "SBPC↓''");
                Reducciones.Add(37, "SBPS↓Stmt SBPS");
                Reducciones.Add(38, "SBPS↓''");
                Reducciones.Add(39, "Stmt↓Expr ;");
                Reducciones.Add(40, "Stmt↓;");
                Reducciones.Add(41, "Stmt↓if ( Expr ) Stmt ElseStmt");
                Reducciones.Add(42, "Stmt↓while ( Expr ) Stmt");
                Reducciones.Add(43, "Stmt↓for ( Expr ; Expr ; Expr ) Stmt");
                Reducciones.Add(44, "Stmt↓break ;");
                Reducciones.Add(45, "Stmt↓return Expr ;");
                Reducciones.Add(46, "Stmt↓System . out . println ( Expr ExPrint ) ;");
                Reducciones.Add(47, "Stmt↓StmtBlock");
                Reducciones.Add(48, "ElseStmt↓else Stmt");
                Reducciones.Add(49, "ElseStmt↓''");
                Reducciones.Add(50, "ExPrint↓, Expr ExPrint");
                Reducciones.Add(51, "ExPrint↓''");
                Reducciones.Add(52, "Expr↓Expr - Expr");
                Reducciones.Add(53, "Expr↓Expr / Expr");
                Reducciones.Add(54, "Expr↓Expr % Expr");
                Reducciones.Add(55, "Expr↓- Expr");
                Reducciones.Add(56, "Expr↓Expr > Expr");
                Reducciones.Add(57, "Expr↓Expr >= Expr");
                Reducciones.Add(58, "Expr↓Expr != Expr");
                Reducciones.Add(59, "Expr↓Expr || Expr");
                Reducciones.Add(60, "Expr↓! Expr");
                Reducciones.Add(61, "Expr↓New ( ident )");
                Reducciones.Add(62, "Expr↓LValue");
                Reducciones.Add(63, "Expr↓LValue = Expr");
                Reducciones.Add(64, "Expr↓Constant");
                Reducciones.Add(65, "Expr↓this");
                Reducciones.Add(66, "Expr↓( Expr )");
                Reducciones.Add(67, "LValue↓Expr . ident");
                Reducciones.Add(68, "LValue↓ident");
                Reducciones.Add(69, "Constant↓intConstant");
                Reducciones.Add(70, "Constant↓doubleConstant");
                Reducciones.Add(71, "Constant↓boolConstant");
                Reducciones.Add(72, "Constant↓stringConstant");
                Reducciones.Add(73, "Constant↓null");
                var salida = "";
                #endregion
                //var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓=↓!=↓||↓>↓>=↓-↓/↓%↓!↓this↓New↓intConstant↓doubleConstant↓boolConstant↓stringConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓ExprOr↓ExprOrP↓ExprAnd↓ExprAndP↓ExprEquals↓ExprEqualsP↓ExprComp↓ExprCompP".Split('↓');
                var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓-↓/↓%↓>↓>=↓!=↓||↓!↓New↓=↓this↓intConstant↓stringConstant↓boolConstant↓doubleConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓LValue↓Constant".Split('↓');
                
                
                //var reader = new StreamReader("gramatica.txt");
                var reader = new StreamReader("Exprgramatica.txt");
                var linea = reader.ReadLine();
                var candidadDeConflictos = 0;
                //for (int i = 0; i < 180; i++)
                for (int i = 0; i < 171; i++)
                {
                   // salida += $"public bool Estado{i} (Stack<int> _Pila, string  _actual , string _lookahead  )\n";
                    //salida += $"public bool Estado{i} (string  _actual , string _lookahead  )\n";
                    salida += $"public bool Estado{i} (string _lookahead  )\n";
                    salida += "{\n";
                    var acciones = linea.Replace('\t', '↓').Split('↓');
                    //switch (lookahead)
                    salida += "switch (_lookahead) \n";
                    estados.Add(i,new Dictionary<string, string>());
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

                                estados[i].Add(campos[k], acciones[k].Split('/')[0].Trim().Replace("d", ""));
                                salida += $"StackDeEntrada.Pop();\n";
                                salida += $"StackDeConsumo.Push({acciones[k].Split('/')[0].Trim().Replace("d", "")});\n";
                                salida += "Simbolos += $\" { _lookahead} \";\n";
                                salida += "Simbolos = Simbolos.Trim();\n";

                                salida += $"\treturn Estado{acciones[k].Split('/')[0].Trim().Replace("d", "")}(StackDeEntrada.Peek());\n";
                                //salida += $"\treturn false;\n";
                                //salida += $"\tbreak;\n";
                                candidadDeConflictos++;
                            }
                            else
                            {
                                if (acciones[k].Contains("d"))
                                {//desplazamientos
                                    salida += $"\t\t//desplazamiento a {acciones[k]}\n";
                                    salida += $"\t\t\t\t//consume {campos[k]}\n";
                                    //StackDeEntrada
                                    estados[i].Add(campos[k],acciones[k].Replace("d", ""));

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

                                    estados[i].Add(campos[k], acciones[k].Replace("r", ""));
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
                                        //salida += $"Simbolos = Simbolos.Replace(reducido, reduccion);\n";

                                        salida += "//if (Simbolos.Contains(reducido.Trim()))";
                                        salida += "//{";
                                        salida += "    Simbolos = Simbolos.Replace(reducido, reduccion);";
                                        salida += "//}";
                                        salida += "//else";
                                        salida += "//{\n";
                                        salida += "SimbolosQueSeQuedan = Simbolos.Trim().Split(' ').Length - reducido.Trim().Split(' ').Length;\n";
                                        salida += " aux = \"\";\n";
                                        salida += "for (int i = 0; i < SimbolosQueSeQuedan; i++)\n";
                                        salida += "{\n";
                                        salida += "aux += $\" { Simbolos.Trim().Split(' ')[i]}\";\n";
                                        salida += "aux = aux.Trim();\n";
                                        salida += "}\n";
                                        salida += "aux += $\" { reduccion}\";\n";
                                        salida += "aux = aux.Trim();\n";
                                        salida += "Simbolos = aux;";
                                        salida += "//}\n";

                                        salida += $"unStack = reducido.Split(' ').Length;\n";
                                        salida += $"//quitando pasos de la stack;\n";
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
                var ax = Newtonsoft.Json.JsonConvert.SerializeObject(estados);

                var salidaDeIrA = "";
                //for (int i = 0; i < 180; i++)
                for (int i = 0; i < 171; i++)
                    
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
