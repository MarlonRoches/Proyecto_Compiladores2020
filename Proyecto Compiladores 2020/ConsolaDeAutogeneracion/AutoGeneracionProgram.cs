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
                var salida = "";
                var campos = "ident↓;↓(↓)↓static↓class↓{↓}↓interface↓[]↓void↓,↓int↓double↓bool↓string↓extends↓implements↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓#ERROR!↓!=↓||↓>↓>=↓-↓/↓%↓!↓this↓New↓intConstant↓doubleConstant↓boolConstant↓stringConstant↓null↓$↓Start↓Program↓Decl↓Type↓FRoot↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageI↓HeritageD↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓ExprOr↓ExprOrP↓ExprAnd↓ExprAndP↓ExprEquals↓ExprEqualsP↓ExprComp↓ExprCompP".Split('↓');
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
                                //salida += $"\t\t\t\t//consume {campos[k]}\n";
                                //StackDeEntrada
                                //salida += $" //StackDeEntrada.Pop();\n";
                                //salida += $" //StackDeConsumo.Push({acciones[k].Replace("d", "")});\n";
                                //salida += $"\treturn Estado{acciones[k].Replace("d", "")}(null, null, null);\n";
                                salida += $"\treturn false;\n";
                                salida += $"\tbreak;\n";
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
                                    salida += $"\t\t//reduccion a {acciones[k]}\n";
                                    salida += $"reduccion = Reducciones[{acciones[k].Replace("r","")}].Split('↓')[0].Trim();\n";
                                    salida += $" reducido = Reducciones[{acciones[k].Replace("r", "")}].Split('↓')[1].Trim();\n";
                                    salida += $"Simbolos = Simbolos.Replace(reducido, reduccion);\n";
                                    salida += $"unStack = reducido.Split(' ').Length;\n";
                                    salida += $"for (int i = 0; i < unStack; i++)\n";
                                    salida += "{\n";
                                    salida += $"    StackDeConsumo.Pop();\n";
                                    salida += "}\n";
                                    salida += $"return IrA(StackDeConsumo.Peek(), reduccion);\n";

                                }
                                else
                                {
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
                var gramaticas = new StreamReader("producciones.txt");
                var num = 0;
                while ((linea= gramaticas.ReadLine()) != null)
                {
                    Reducciones.Add(num,linea );
                    num++;
                }
                gramaticas.Close();
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
