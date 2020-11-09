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

            var lector = new StreamReader("D:\\Proyecto_Compiladores2020\\Gramatica.txt");
            var lineaee = lector.ReadLine();
            var diccinoarioGramatica = "";
            var contador = 0;
            while ((lineaee = lector.ReadLine())!=null)
            {

                diccinoarioGramatica += $"Reducciones.Add({contador},\"{lineaee.Replace("->","↓")}\");\n";
                contador++;
            }
            Dictionary<int, string> Reducciones = new Dictionary<int, string>();
            //
            var estados = new Dictionary<int, Dictionary<string, string>>();
            var lol = nuevoDiccionario();
            //numer de estado actual , (token con el que se va, accion)
            Dictionary<string, string> nuevoDiccionario()
            {
                //Con Expr
                #region Dicciionario
                Reducciones.Add(0, "Start↓Program");
                Reducciones.Add(1, "Program↓Decl Program");
                Reducciones.Add(2, "Program↓Decl");
                Reducciones.Add(3, "Decl↓Type ident ;");
                Reducciones.Add(4, "Decl↓Type ident ( Formals ) StmtBlock");
                Reducciones.Add(5, "Decl↓void ident ( Formals ) StmtBlock");
                Reducciones.Add(6, "Decl↓static CnsTp ident ;");
                Reducciones.Add(7, "Decl↓class ident Heritage HeritageI { FieldP }");
                Reducciones.Add(8, "Decl↓interface ident { Proto }");
                Reducciones.Add(9, "Type↓CnsTp");
                Reducciones.Add(10, "Type↓ident");
                Reducciones.Add(11, "Type↓Type []");
                Reducciones.Add(12, "Formals↓Type ident , Formals");
                Reducciones.Add(13, "Formals↓Type ident");
                Reducciones.Add(14, "StmtBlock↓{ COMBINACION }");
                Reducciones.Add(15, "COMBINACION↓Type ident ; COMBINACION");
                Reducciones.Add(16, "COMBINACION↓''");
                Reducciones.Add(17, "COMBINACION↓static CnsTp ident ; COMBINACION");
                Reducciones.Add(18, "COMBINACION↓''");
                Reducciones.Add(19, "COMBINACION↓Stmt COMBINACION");
                Reducciones.Add(20, "COMBINACION↓''");
                Reducciones.Add(21, "CnsTp↓int");
                Reducciones.Add(22, "CnsTp↓double");
                Reducciones.Add(23, "CnsTp↓boolean");
                Reducciones.Add(24, "CnsTp↓string");
                Reducciones.Add(25, "Heritage↓extends ident");
                Reducciones.Add(26, "Heritage↓''");
                Reducciones.Add(27, "HeritageI↓implements ident HeritageD");
                Reducciones.Add(28, "HeritageI↓''");
                Reducciones.Add(29, "HeritageD↓, ident HeritageD");
                Reducciones.Add(30, "HeritageD↓''");
                Reducciones.Add(31, "FieldP↓Field FieldP");
                Reducciones.Add(32, "FieldP↓''");
                Reducciones.Add(33, "Field↓Type ident ;");
                Reducciones.Add(34, "Field↓Type ident ( Formals ) StmtBlock");
                Reducciones.Add(35, "Field↓void ident ( Formals ) StmtBlock");
                Reducciones.Add(36, "Field↓static CnsTp ident ;");
                Reducciones.Add(37, "Proto↓Prototype Proto");
                Reducciones.Add(38, "Proto↓''");
                Reducciones.Add(39, "Prototype↓Type ident ( Formals ) ;");
                Reducciones.Add(40, "Prototype↓void ident ( Formals ) ;");
                Reducciones.Add(41, "Stmt↓Expr ;");
                Reducciones.Add(42, "Stmt↓;");
                Reducciones.Add(43, "Stmt↓if ( Expr ) Stmt ElseStmt");
                Reducciones.Add(44, "Stmt↓while ( Expr ) Stmt");
                Reducciones.Add(45, "Stmt↓for ( Expr ; Expr ; Expr ) Stmt");
                Reducciones.Add(46, "Stmt↓break ;");
                Reducciones.Add(47, "Stmt↓return Expr ;");
                Reducciones.Add(48, "Stmt↓System . out . println ( Expr ExPrint ) ;");
                Reducciones.Add(49, "Stmt↓StmtBlock");
                Reducciones.Add(50, "Stmt↓CallStmt");
                Reducciones.Add(51, "CallStmt↓ident ( Actuals )");
                Reducciones.Add(52, "CallStmt↓ident . ident ( Actuals )");
                Reducciones.Add(53, "Actuals↓Expr , Actuals");
                Reducciones.Add(54, "Actuals↓Expr");
                Reducciones.Add(55, "ElseStmt↓else Stmt");
                Reducciones.Add(56, "ElseStmt↓''");
                Reducciones.Add(57, "ExPrint↓, Expr ExPrint");
                Reducciones.Add(58, "ExPrint↓''");
                Reducciones.Add(59, "Expr↓Expr - Expr");
                Reducciones.Add(60, "Expr↓Expr / Expr");
                Reducciones.Add(61, "Expr↓Expr % Expr");
                Reducciones.Add(62, "Expr↓- Expr");
                Reducciones.Add(63, "Expr↓Expr > Expr");
                Reducciones.Add(64, "Expr↓Expr >= Expr");
                Reducciones.Add(65, "Expr↓Expr != Expr");
                Reducciones.Add(66, "Expr↓Expr || Expr");
                Reducciones.Add(67, "Expr↓! Expr");
                Reducciones.Add(68, "Expr↓New ( ident )");
                Reducciones.Add(69, "Expr↓Expr . ident");
                Reducciones.Add(70, "Expr↓ident");
                Reducciones.Add(71, "Expr↓Expr . ident = Expr");
                Reducciones.Add(72, "Expr↓ident = Expr");
                Reducciones.Add(73, "Expr↓Constant");
                Reducciones.Add(74, "Expr↓this");
                Reducciones.Add(75, "Expr↓( Expr )");
                Reducciones.Add(76, "Constant↓intConstant");
                Reducciones.Add(77, "Constant↓stringConstant");
                Reducciones.Add(78, "Constant↓boolConstant");
                Reducciones.Add(79, "Constant↓doubleConstant");
                Reducciones.Add(80, "Constant↓null");

                #endregion

                var salida = "";
                //var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓=↓!=↓||↓>↓>=↓-↓/↓%↓!↓this↓New↓intConstant↓doubleConstant↓boolConstant↓stringConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓ExprOr↓ExprOrP↓ExprAnd↓ExprAndP↓ExprEquals↓ExprEqualsP↓ExprComp↓ExprCompP".Split('↓');
                //var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓-↓/↓%↓>↓>=↓!=↓||↓!↓New↓=↓this↓intConstant↓stringConstant↓boolConstant↓doubleConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓CallStmt↓Actuals↓ElseStmt↓ExPrint↓Expr↓LValue↓Constant".Split('↓');
                //var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓-↓/↓%↓>↓>=↓!=↓||↓!↓New↓=↓this↓intConstant↓stringConstant↓boolConstant↓doubleConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓COMBINACION↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓Stmt↓CallStmt↓Actuals↓ElseStmt↓ExPrint↓Expr↓LValue↓Constant".Split('↓');
                //var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓-↓/↓%↓>↓>=↓!=↓||↓!↓New↓=↓this↓intConstant↓stringConstant↓boolConstant↓doubleConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓COMBINACION↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓Stmt↓CallStmt↓Actuals↓ElseStmt↓ExPrint↓Expr↓Constant".Split('↓');
                var campos = "ident↓;↓(↓)↓void↓static↓class↓{↓}↓interface↓[]↓,↓int↓double↓boolean↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓-↓/↓%↓>↓>=↓!=↓||↓!↓New↓=↓this↓intConstant↓stringConstant↓boolConstant↓doubleConstant↓null↓$↓Start↓Program↓Decl↓Type↓Formals↓StmtBlock↓COMBINACION↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓Stmt↓CallStmt↓Actuals↓ElseStmt↓ExPrint↓Expr↓Constant".Split('↓');

                var numEstados = 196;
                //var reader = new StreamReader("gramatica.txt");
                var reader = new StreamReader("Exprgramatica.txt");
                var linea = reader.ReadLine();
                var candidadDeConflictos = 0;
                //for (int i = 0; i < 180; i++)
                for (int i = 0; i < numEstados; i++)
                {
                    // salida += $"public bool Estado{i} (Stack<int> _Pila, string  _actual , string _lookahead  )\n";
                    //salida += $"public bool Estado{i} (string  _actual , string _lookahead  )\n";
                    salida += $"public void Estado{i} (string _lookahead  )\n";
                    salida += "{\n";
                    var acciones = linea.Replace('\t', '↓').Split('↓');
                    //switch (lookahead)
                    salida += "switch (_lookahead) \n";
                    estados.Add(i, new Dictionary<string, string>());
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

                                salida += $"\t\t//Conflicto desplazamiento  a {acciones[k].Split('/')[0].Trim()}\n";
                                salida += $"\t\t\t\t//consume {campos[k]}\n";
                                //StackDeEntrada
                                estados[i].Add(campos[k], acciones[k].Split('/')[0].Trim().Replace("d", ""));
                                salida += $"tokensAceptados.Add(StackDeEntrada.Pop());\n";
                                salida += $"StackDeConsumo.Push({acciones[k].Split('/')[0].Trim().Replace("d", "")});\n";
                                salida += "Simbolos += $\" { _lookahead} \";\n";
                                salida += "Simbolos = Simbolos.Trim();\n";
                                salida += "StackDeLineasYColumnas.Pop();";

                                //salida += $"\tbreak;\n";
                                candidadDeConflictos++;
                            }
                            else
                            {
                                if (acciones[k].Contains("d"))
                                {//desplazamientos
                                    salida += $"\t\t\t\t//desplazamientoconsume {campos[k]}\n";
                                    //StackDeEntrada
                                    estados[i].Add(campos[k], acciones[k].Replace("d", ""));

                                    salida += $"tokensAceptados.Add(StackDeEntrada.Pop());\n";
                                    salida += $"StackDeConsumo.Push({acciones[k].Replace("d", "")});\n";
                                    salida += "Simbolos += $\" { _lookahead} \";\n";
                                    salida += "Simbolos = Simbolos.Trim();\n";
                                    salida += "StackDeLineasYColumnas.Pop();";

                                }
                                else if (acciones[k].Contains("r"))
                                {

                                    //reducciones
                                    salida += $"\t\t//reduccion a {acciones[k]}\n";
                                    salida += $"reduccion = Reducciones[{acciones[k].Replace("r", "")}].Split('↓')[0].Trim();\n";
                                    salida += $" reducido = Reducciones[{acciones[k].Replace("r", "")}].Split('↓')[1].Trim();\n";

                                    estados[i].Add(campos[k], acciones[k].Replace("r", ""));
                                    if (Reducciones[int.Parse(acciones[k].Replace("r", ""))].Split('↓')[1] == "\'\'")
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

                                        salida += $"unStack = reducido.Split(' ').Length;\n";

                                        salida += $"for (int i = 0; i < unStack; i++)\n";
                                        salida += "{\n";
                                        salida += $"    StackDeConsumo.Pop();\n";
                                        salida += "}\n";
                                    }
                                    //var aux = int.Parse(acciones[k].Replace("r", ""));
                                    //if (aux == 3 || aux == 4 || aux == 5 || aux == 6 || aux == 7 || aux == 8)
                                    //{

                                    //    salida += "return ;\n";

                                    //}
                                    //else
                                    //{
                                        salida += $"IrA(StackDeConsumo.Peek(), reduccion);\n";
                                    //}
                                }
                                else
                                {//irA
                                    salida += $"\t\tStackDeConsumo.Push({acciones[k]});\n";

                                }
                            }

                            salida += $"\tbreak;\n\n";
                        }
                    }
                    salida += "default:\n";
                    salida += "Err();";
                    //
                    salida += "break;\n";
                    salida += "}\n";
                    salida += "}\n";
                    linea = reader.ReadLine();
                }

                reader.Close();
                var ax = Newtonsoft.Json.JsonConvert.SerializeObject(estados);

                var diccionarioString = "";
                for (int i = 0; i < estados.Count; i++)
                {
                    diccionarioString += $"EstadoDeError.Add({i}, new Dictionary<string, string>());\n";
                    foreach (var item in estados[i])
                    {
                        diccionarioString += $"EstadoDeError[{i}].Add(\"{item.Key}\",\"{item.Value}\");\n";
                    }
                }
                var salidaDeIrA = "";
                //for (int i = 0; i < 180; i++)
                for (int i = 0; i < numEstados; i++)

                {
                    salidaDeIrA += $"case {i}:\n";
                    salidaDeIrA += $"Estado{i}( _lookahead);\n";
                    salidaDeIrA +=$"break;\n";
                }
                return null;
            }
        }
    }
}
