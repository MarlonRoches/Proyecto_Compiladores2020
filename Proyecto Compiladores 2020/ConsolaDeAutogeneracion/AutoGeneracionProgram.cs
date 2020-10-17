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
            //
            var lol = nuevoDiccionario();
         

            Dictionary<string, string> nuevoDiccionario()
            {
                var salida = "";
                var campos = "ident↓;↓(↓)↓const↓class↓{↓}↓interface↓[]↓void↓,↓int↓double↓bool↓string↓:↓if↓while↓for↓break↓return↓System↓.↓out↓println↓else↓=↓!=↓||↓>↓>=↓-↓/↓%↓!↓this↓New↓intConstant↓doubleConstant↓boolConstant↓stringConstant↓null↓$↓Start↓Program↓Decl↓Type↓FRoot↓Formals↓StmtBlock↓CnsTp↓Heritage↓HeritageP↓FieldP↓Field↓Proto↓Prototype↓SBPV↓SBPC↓SBPS↓Stmt↓ElseStmt↓ExPrint↓Expr↓ExprOr↓ExprOrP↓ExprAnd↓ExprAndP↓ExprEquals↓ExprEqualsP↓ExprComp↓ExprCompP".Split('↓');
                var reader = new StreamReader("gramatica.txt");
                var linea = reader.ReadLine();
                for (int i = 0; i < 176; i++)
                {
                    salida += $"public bool Estado{i} (Stack<int> _Pila, string  _actual , string _lookahead  )\n";
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
                            if (acciones[k].Contains("d"))
                            {

                                salida += $"\t\t//desplazamiento a {acciones[k]}\n";
                                salida += $"\t\t\t\t//consume {campos[k]}\n";
                                    //StackDeEntrada
                                salida += $" //StackDeEntrada.Pop();\n";
                                salida += $" //StackDeConsumo.Push({acciones[k].Replace("d", "")});\n";
                                salida += $"\treturn Estado{acciones[k].Replace("d", "")}(null, null, null);\n";
                            }
                            else if (acciones[k].Contains("r"))
                            {
                                salida += $"\t\t//reduccion a {acciones[k]}\n";
                                salida += $"\treturn Estado{acciones[k].Replace("r", "")}(null, null, null);\n";

                            }
                            else
                            {
                                salida += $"\t\t//irA {acciones[k]}\n";
                                salida += $"\treturn Estado{acciones[k]}(null, null, null);\n";

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
                }


                reader.Close();
                //while ((linea = reader.ReadLine())!= null)
                //{
                //    //var acciones = linea.Replace('\t', '↓').Split('↓');
                //    //for (int k = 0; k < campos.Length; k++)
                //    //{
                //    //    if (acciones[k]!="")
                //    //    {
                //    //        salida += $"case \"{campos[k]}\":\n";
                //    //        if (acciones[k].Contains("d"))
                //    //        {

                //    //        salida += $"//desplazamiento a {acciones[k]}\n";
                //    //        }
                //    //        else if (acciones[k].Contains("r"))
                //    //        {

                //    //        salida += $"//reduccion a {acciones[k]}\n";
                //    //        }
                //    //        else
                //    //        {

                //    //        salida += $"//irA {acciones[k]}\n";
                //    //        }
                //    //        salida += $"break;\n";
                //    //    }
                //    //}
                //}
                //foreach (var item in campos)
                //{

                //}
                return null;
            }
        }
    }
}
