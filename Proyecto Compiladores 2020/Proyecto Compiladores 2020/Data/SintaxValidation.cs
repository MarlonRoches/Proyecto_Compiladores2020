using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data
{
	class SintaxValidation
	{
		private static SintaxValidation _instance = null;
		public static SintaxValidation Instance
		{
			get
			{
				if (_instance == null) _instance = new SintaxValidation();
				return _instance;
			}
		}
		//programar cada estado de la tabla
		// obtener la pila 
		int pasos = 0;
		static Stack<int> StackDeConsumo = new Stack<int>();
		string Simbolos = "";
		Dictionary<int, string> Reducciones = new Dictionary<int, string>();
		static Stack<string> StackDeEntrada = new Stack<string>();
		static List<string> Pasos = new List<string>();
		static List<KeyValuePair<string, string>> Entrada;
		string reduccion = "";
		string reducido = "";
		int unStack = 0;
		// calcular lookahead
		// 
		// obtener lista de tokens
		// error: leer hasta ; y seguir
		// des stackear estados


		public void Parser(List<KeyValuePair<string, string>> _Aceptados)
		{

			StackDeConsumo.Push(0);
			Entrada = _Aceptados;
			StackDeEntrada.Push("$");
			for (int i = _Aceptados.Count - 1; i >= 0; i--)
			{
				StackDeEntrada.Push(_Aceptados[i].Key);
			}
			var actual = StackDeEntrada.Peek();
			CargarDiccionario();
			var resultado = Estado0(actual);

			var xdd = 0;
		}


		public bool Err()
		{
			//consumr hasta encontrar un ; o un } en la stack de entrada
			//consumir la de consumo hasta encontrar un ; o un { de reversa y quitar los n pasos
			//
			return false;
		}

		void CargarDiccionario()
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
		}
		bool IrA(int numEstado, string _lookahead)
		{
			switch (numEstado)
			{


				
				default:
					return Err();
			}
		}
		bool Conflictos()
		{
			return false;
		}
		#region Estados

		public bool Estado0(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "static":
					//desplazamiento a d5
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(5);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado5(StackDeEntrada.Peek());
				case "class":
					//desplazamiento a d6
					//consume class
					StackDeEntrada.Pop();
					StackDeConsumo.Push(6);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado6(StackDeEntrada.Peek());
				case "interface":
					//desplazamiento a d7
					//consume interface
					StackDeEntrada.Pop();
					StackDeConsumo.Push(7);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado7(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Program":
					//irA 1
					StackDeConsumo.Push(1);
					return Estado1(StackDeEntrada.Peek());
				case "Decl":
					//irA 2
					StackDeConsumo.Push(2);
					return Estado2(StackDeEntrada.Peek());
				case "Type":
					//irA 3
					StackDeConsumo.Push(3);
					return Estado3(StackDeEntrada.Peek());
				case "FRoot":
					//irA 4
					StackDeConsumo.Push(4);
					return Estado4(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado1(string _lookahead)
		{
			switch (_lookahead)
			{
				case "$":
					//irA acc
					//StackDeConsumo.Push(acc);
					//return Estadoacc(StackDeEntrada.Peek());
					return true;
				default:
					Err(); return false;
			}
		}
		public bool Estado2(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "static":
					//desplazamiento a d5
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(5);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado5(StackDeEntrada.Peek());
				case "class":
					//desplazamiento a d6
					//consume class
					StackDeEntrada.Pop();
					StackDeConsumo.Push(6);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado6(StackDeEntrada.Peek());
				case "interface":
					//desplazamiento a d7
					//consume interface
					StackDeEntrada.Pop();
					StackDeConsumo.Push(7);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado7(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "$":
					//reduccion a r2
					reduccion = Reducciones[2].Split('↓')[0].Trim();
					reducido = Reducciones[2].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "Program":
					//irA 15
					StackDeConsumo.Push(15);
					return Estado15(StackDeEntrada.Peek());
				case "Decl":
					//irA 2
					StackDeConsumo.Push(2);
					return Estado2(StackDeEntrada.Peek());
				case "Type":
					//irA 3
					StackDeConsumo.Push(3);
					return Estado3(StackDeEntrada.Peek());
				case "FRoot":
					//irA 4
					StackDeConsumo.Push(4);
					return Estado4(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado3(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					// CONFLICTO a d16 / r12
					//desplazamiento a d16
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(16);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado16(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado4(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d18
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(18);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado18(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado5(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 19
					StackDeConsumo.Push(19);
					return Estado19(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado6(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d20
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(20);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado20(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado7(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d21
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(21);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado21(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado8(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r8
					reduccion = Reducciones[8].Split('↓')[0].Trim();
					reducido = Reducciones[8].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r8
					reduccion = Reducciones[8].Split('↓')[0].Trim();
					reducido = Reducciones[8].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado9(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r9
					reduccion = Reducciones[9].Split('↓')[0].Trim();
					reducido = Reducciones[9].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r9
					reduccion = Reducciones[9].Split('↓')[0].Trim();
					reducido = Reducciones[9].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado10(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r11
					reduccion = Reducciones[11].Split('↓')[0].Trim();
					reducido = Reducciones[11].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado11(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r16
					reduccion = Reducciones[16].Split('↓')[0].Trim();
					reducido = Reducciones[16].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r16
					reduccion = Reducciones[16].Split('↓')[0].Trim();
					reducido = Reducciones[16].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado12(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r17
					reduccion = Reducciones[17].Split('↓')[0].Trim();
					reducido = Reducciones[17].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r17
					reduccion = Reducciones[17].Split('↓')[0].Trim();
					reducido = Reducciones[17].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado13(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r18
					reduccion = Reducciones[18].Split('↓')[0].Trim();
					reducido = Reducciones[18].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r18
					reduccion = Reducciones[18].Split('↓')[0].Trim();
					reducido = Reducciones[18].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado14(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r19
					reduccion = Reducciones[19].Split('↓')[0].Trim();
					reducido = Reducciones[19].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r19
					reduccion = Reducciones[19].Split('↓')[0].Trim();
					reducido = Reducciones[19].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado15(string _lookahead)
		{
			switch (_lookahead)
			{
				case "$":
					//reduccion a r1
					reduccion = Reducciones[1].Split('↓')[0].Trim();
					reducido = Reducciones[1].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado16(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d22
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(22);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado22(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado17(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r10
					reduccion = Reducciones[10].Split('↓')[0].Trim();
					reducido = Reducciones[10].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//reduccion a r10
					reduccion = Reducciones[10].Split('↓')[0].Trim();
					reducido = Reducciones[10].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado18(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d23
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(23);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado23(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado19(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d24
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(24);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado24(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado20(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "extends":
					//desplazamiento a d26
					//consume extends
					StackDeEntrada.Pop();
					StackDeConsumo.Push(26);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado26(StackDeEntrada.Peek());
				case "implements":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r21
					reduccion = Reducciones[21].Split('↓')[0].Trim();
					reducido = Reducciones[21].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "Heritage":
					//irA 25
					StackDeConsumo.Push(25);
					return Estado25(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado21(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d27
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(27);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado27(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado22(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r3
					reduccion = Reducciones[3].Split('↓')[0].Trim();
					reducido = Reducciones[3].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado23(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					StackDeConsumo.Push(29);
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 28
					StackDeConsumo.Push(28);
					return Estado28(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado24(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d30
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(30);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado30(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado25(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r23
					reduccion = Reducciones[23].Split('↓')[0].Trim();
					reducido = Reducciones[23].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "implements":
					//desplazamiento a d32
					//consume implements
					StackDeEntrada.Pop();
					StackDeConsumo.Push(32);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado32(StackDeEntrada.Peek());
				case "HeritageI":
					//irA 31
					StackDeConsumo.Push(31);
					return Estado31(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado26(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d33
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(33);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado33(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado27(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "}":
					//reduccion a r32
					reduccion = Reducciones[32].Split('↓')[0].Trim();
					reducido = Reducciones[32].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 37
					StackDeConsumo.Push(37);
					return Estado37(StackDeEntrada.Peek());
				case "FRoot":
					//irA 36
					StackDeConsumo.Push(36);
					return Estado36(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "Proto":
					//irA 34
					StackDeConsumo.Push(34);
					return Estado34(StackDeEntrada.Peek());
				case "Prototype":
					//irA 35
					StackDeConsumo.Push(35);
					return Estado35(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado28(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d38
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(38);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado38(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado29(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d39
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(39);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado39(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado30(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r5
					reduccion = Reducciones[5].Split('↓')[0].Trim();
					reducido = Reducciones[5].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado31(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d40
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(40);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado40(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado32(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d41
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(41);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado41(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado33(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "implements":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r20
					reduccion = Reducciones[20].Split('↓')[0].Trim();
					reducido = Reducciones[20].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado34(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d42
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(42);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado42(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado35(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "}":
					//reduccion a r32
					reduccion = Reducciones[32].Split('↓')[0].Trim();
					reducido = Reducciones[32].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 37
					StackDeConsumo.Push(37);
					return Estado37(StackDeEntrada.Peek());
				case "FRoot":
					//irA 36
					StackDeConsumo.Push(36);
					return Estado36(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "Proto":
					//irA 43
					StackDeConsumo.Push(43);
					return Estado43(StackDeEntrada.Peek());
				case "Prototype":
					//irA 35
					StackDeConsumo.Push(35);
					return Estado35(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado36(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d44
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(44);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado44(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado37(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r12
					reduccion = Reducciones[12].Split('↓')[0].Trim();
					reducido = Reducciones[12].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado38(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 45
					StackDeConsumo.Push(45);
					return Estado45(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado39(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r14
					reduccion = Reducciones[14].Split('↓')[0].Trim();
					reducido = Reducciones[14].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//desplazamiento a d47
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(47);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado47(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado40(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "static":
					//desplazamiento a d52
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(52);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado52(StackDeEntrada.Peek());
				case "}":
					//reduccion a r27
					reduccion = Reducciones[27].Split('↓')[0].Trim();
					reducido = Reducciones[27].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 50
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "FRoot":
					//irA 51
					StackDeConsumo.Push(51);
					return Estado51(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "FieldP":
					//irA 48
					StackDeConsumo.Push(48);
					return Estado48(StackDeEntrada.Peek());
				case "Field":
					//irA 49
					StackDeConsumo.Push(49);
					return Estado49(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado41(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r25
					reduccion = Reducciones[25].Split('↓')[0].Trim();
					reducido = Reducciones[25].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//desplazamiento a d54
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(54);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado54(StackDeEntrada.Peek());
				case "HeritageD":
					//irA 53
					StackDeConsumo.Push(53);
					return Estado53(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado42(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r7
					reduccion = Reducciones[7].Split('↓')[0].Trim();
					reducido = Reducciones[7].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado43(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r31
					reduccion = Reducciones[31].Split('↓')[0].Trim();
					reducido = Reducciones[31].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado44(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d55
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(55);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado55(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado45(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r4
					reduccion = Reducciones[4].Split('↓')[0].Trim();
					reducido = Reducciones[4].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado46(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					// CONFLICTO a d9 / r35
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case ";":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					// CONFLICTO a d11 / r35
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					// CONFLICTO a d12 / r35
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					// CONFLICTO a d13 / r35
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					// CONFLICTO a d14 / r35
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "if":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "Type":
					//irA 57
					StackDeConsumo.Push(57);
					return Estado57(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "SBPV":
					//irA 56
					StackDeConsumo.Push(56);
					return Estado56(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado47(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					StackDeConsumo.Push(29);
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 58
					StackDeConsumo.Push(58);
					return Estado58(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado48(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d59
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(59);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado59(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado49(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "static":
					//desplazamiento a d52
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(52);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado52(StackDeEntrada.Peek());
				case "}":
					//reduccion a r27
					reduccion = Reducciones[27].Split('↓')[0].Trim();
					reducido = Reducciones[27].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 50
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "FRoot":
					//irA 51
					StackDeConsumo.Push(51);
					return Estado51(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "FieldP":
					//irA 60
					StackDeConsumo.Push(60);
					return Estado60(StackDeEntrada.Peek());
				case "Field":
					//irA 49
					StackDeConsumo.Push(49);
					return Estado49(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado50(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					// CONFLICTO a d61 / r12
					//desplazamiento a d61
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(61);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado61(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado51(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d62
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(62);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado62(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado52(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 63
					StackDeConsumo.Push(63);
					return Estado63(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado53(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r22
					reduccion = Reducciones[22].Split('↓')[0].Trim();
					reducido = Reducciones[22].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado54(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d64
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(64);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado64(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado55(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					StackDeConsumo.Push(29);
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 65
					StackDeConsumo.Push(65);
					return Estado65(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado56(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					// CONFLICTO a d67 / r37
					//desplazamiento a d67
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(67);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado67(StackDeEntrada.Peek());
				case "class":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "SBPC":
					//irA 66
					StackDeConsumo.Push(66);
					return Estado66(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado57(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d68
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(68);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado68(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado58(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r13
					reduccion = Reducciones[13].Split('↓')[0].Trim();
					reducido = Reducciones[13].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado59(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r6
					reduccion = Reducciones[6].Split('↓')[0].Trim();
					reducido = Reducciones[6].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado60(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r26
					reduccion = Reducciones[26].Split('↓')[0].Trim();
					reducido = Reducciones[26].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado61(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d69
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(69);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado69(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado62(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d70
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(70);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado70(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado63(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d71
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(71);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado71(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado64(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r25
					reduccion = Reducciones[25].Split('↓')[0].Trim();
					reducido = Reducciones[25].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//desplazamiento a d54
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(54);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado54(StackDeEntrada.Peek());
				case "HeritageD":
					//irA 72
					StackDeConsumo.Push(72);
					return Estado72(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado65(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d73
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(73);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado73(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado66(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "}":
					//reduccion a r39
					reduccion = Reducciones[39].Split('↓')[0].Trim();
					reducido = Reducciones[39].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "SBPS":
					//irA 74
					StackDeConsumo.Push(74);
					return Estado74(StackDeEntrada.Peek());
				case "Stmt":
					//irA 75
					StackDeConsumo.Push(75);
					return Estado75(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado67(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 104
					StackDeConsumo.Push(104);
					return Estado104(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado68(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d105
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(105);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado105(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado69(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r28
					reduccion = Reducciones[28].Split('↓')[0].Trim();
					reducido = Reducciones[28].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado70(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					StackDeConsumo.Push(29);
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 106
					StackDeConsumo.Push(106);
					return Estado106(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado71(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d107
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(107);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado107(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado72(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r24
					reduccion = Reducciones[24].Split('↓')[0].Trim();
					reducido = Reducciones[24].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado73(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d108
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(108);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado108(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado74(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d109
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(109);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado109(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado75(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "}":
					//reduccion a r39
					reduccion = Reducciones[39].Split('↓')[0].Trim();
					reducido = Reducciones[39].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "SBPS":
					//irA 110
					StackDeConsumo.Push(110);
					return Estado110(StackDeEntrada.Peek());
				case "Stmt":
					//irA 75
					StackDeConsumo.Push(75);
					return Estado75(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado76(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d111
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(111);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado111(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado77(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r41
					reduccion = Reducciones[41].Split('↓')[0].Trim();
					reducido = Reducciones[41].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado78(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d112
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(112);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado112(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado79(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d113
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(113);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado113(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado80(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d114
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(114);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado114(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado81(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d115
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(115);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado115(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado82(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 116
					StackDeConsumo.Push(116);
					return Estado116(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado83(string _lookahead)
		{
			switch (_lookahead)
			{
				case ".":
					//desplazamiento a d117
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(117);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado117(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado84(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r48
					reduccion = Reducciones[48].Split('↓')[0].Trim();
					reducido = Reducciones[48].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado85(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "=":
					//desplazamiento a d118
					//consume =
					StackDeEntrada.Pop();
					StackDeConsumo.Push(118);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado118(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado86(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//desplazamiento a d119
					//consume !=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(119);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado119(StackDeEntrada.Peek());
				case "-":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r54
					reduccion = Reducciones[54].Split('↓')[0].Trim();
					reducido = Reducciones[54].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado87(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//desplazamiento a d120
					//consume ||
					StackDeEntrada.Pop();
					StackDeConsumo.Push(120);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado120(StackDeEntrada.Peek());
				case "-":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r56
					reduccion = Reducciones[56].Split('↓')[0].Trim();
					reducido = Reducciones[56].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado88(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//desplazamiento a d121
					//consume >
					StackDeEntrada.Pop();
					StackDeConsumo.Push(121);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado121(StackDeEntrada.Peek());
				case ">=":
					//desplazamiento a d122
					//consume >=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(122);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado122(StackDeEntrada.Peek());
				case "-":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r58
					reduccion = Reducciones[58].Split('↓')[0].Trim();
					reducido = Reducciones[58].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado89(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					// CONFLICTO a d123 / r61
					//desplazamiento a d123
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(123);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado123(StackDeEntrada.Peek());
				case "!":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r61
					reduccion = Reducciones[61].Split('↓')[0].Trim();
					reducido = Reducciones[61].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado90(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//desplazamiento a d124
					//consume /
					StackDeEntrada.Pop();
					StackDeConsumo.Push(124);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado124(StackDeEntrada.Peek());
				case "%":
					//desplazamiento a d125
					//consume %
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado125(StackDeEntrada.Peek());
				case "!":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r63
					reduccion = Reducciones[63].Split('↓')[0].Trim();
					reducido = Reducciones[63].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado91(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r66
					reduccion = Reducciones[66].Split('↓')[0].Trim();
					reducido = Reducciones[66].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado92(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 126
					StackDeConsumo.Push(126);
					return Estado126(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado93(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 128
					StackDeConsumo.Push(128);
					return Estado128(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado94(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//desplazamiento a d129
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(129);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado129(StackDeEntrada.Peek());
				case "else":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r69
					reduccion = Reducciones[69].Split('↓')[0].Trim();
					reducido = Reducciones[69].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado95(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r72
					reduccion = Reducciones[72].Split('↓')[0].Trim();
					reducido = Reducciones[72].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado96(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 130
					StackDeConsumo.Push(130);
					return Estado130(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado97(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r74
					reduccion = Reducciones[74].Split('↓')[0].Trim();
					reducido = Reducciones[74].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado98(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d131
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(131);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado131(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado99(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r77
					reduccion = Reducciones[77].Split('↓')[0].Trim();
					reducido = Reducciones[77].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado100(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r78
					reduccion = Reducciones[78].Split('↓')[0].Trim();
					reducido = Reducciones[78].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado101(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r79
					reduccion = Reducciones[79].Split('↓')[0].Trim();
					reducido = Reducciones[79].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado102(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r80
					reduccion = Reducciones[80].Split('↓')[0].Trim();
					reducido = Reducciones[80].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado103(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r81
					reduccion = Reducciones[81].Split('↓')[0].Trim();
					reducido = Reducciones[81].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado104(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d132
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(132);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado132(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado105(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					// CONFLICTO a d9 / r35
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado9(StackDeEntrada.Peek());
				case ";":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					// CONFLICTO a d11 / r35
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado11(StackDeEntrada.Peek());
				case "double":
					// CONFLICTO a d12 / r35
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado12(StackDeEntrada.Peek());
				case "boolean":
					// CONFLICTO a d13 / r35
					//desplazamiento a d13
					//consume boolean
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado13(StackDeEntrada.Peek());
				case "string":
					// CONFLICTO a d14 / r35
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado14(StackDeEntrada.Peek());
				case "if":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r35
					reduccion = Reducciones[35].Split('↓')[0].Trim();
					reducido = Reducciones[35].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "Type":
					//irA 57
					StackDeConsumo.Push(57);
					return Estado57(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					StackDeConsumo.Push(8);
					return Estado8(StackDeEntrada.Peek());
				case "SBPV":
					//irA 133
					StackDeConsumo.Push(133);
					return Estado133(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado106(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d134
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(134);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado134(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado107(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r30
					reduccion = Reducciones[30].Split('↓')[0].Trim();
					reducido = Reducciones[30].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado108(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r33
					reduccion = Reducciones[33].Split('↓')[0].Trim();
					reducido = Reducciones[33].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado109(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r15
					reduccion = Reducciones[15].Split('↓')[0].Trim();
					reducido = Reducciones[15].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado110(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r38
					reduccion = Reducciones[38].Split('↓')[0].Trim();
					reducido = Reducciones[38].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado111(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r40
					reduccion = Reducciones[40].Split('↓')[0].Trim();
					reducido = Reducciones[40].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado112(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 135
					StackDeConsumo.Push(135);
					return Estado135(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado113(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 136
					StackDeConsumo.Push(136);
					return Estado136(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado114(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 137
					StackDeConsumo.Push(137);
					return Estado137(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado115(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r45
					reduccion = Reducciones[45].Split('↓')[0].Trim();
					reducido = Reducciones[45].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado116(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d138
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(138);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado138(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado117(string _lookahead)
		{
			switch (_lookahead)
			{
				case "out":
					//desplazamiento a d139
					//consume out
					StackDeEntrada.Pop();
					StackDeConsumo.Push(139);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado139(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado118(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 140
					StackDeConsumo.Push(140);
					return Estado140(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado119(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 141
					StackDeConsumo.Push(141);
					return Estado141(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado120(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 142
					StackDeConsumo.Push(142);
					return Estado142(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado121(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 143
					StackDeConsumo.Push(143);
					return Estado143(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado122(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 144
					StackDeConsumo.Push(144);
					return Estado144(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado123(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 145
					StackDeConsumo.Push(145);
					return Estado145(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado124(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 146
					StackDeConsumo.Push(146);
					return Estado146(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado125(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 147
					StackDeConsumo.Push(147);
					return Estado147(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado126(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//desplazamiento a d129
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(129);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado129(StackDeEntrada.Peek());
				case "else":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r67
					reduccion = Reducciones[67].Split('↓')[0].Trim();
					reducido = Reducciones[67].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado127(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r75
					reduccion = Reducciones[75].Split('↓')[0].Trim();
					reducido = Reducciones[75].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado128(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//desplazamiento a d129
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(129);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado129(StackDeEntrada.Peek());
				case "else":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r68
					reduccion = Reducciones[68].Split('↓')[0].Trim();
					reducido = Reducciones[68].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado129(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d148
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(148);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado148(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado130(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d149
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(149);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado149(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado131(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d150
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(150);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado150(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado132(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d151
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(151);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado151(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado133(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r34
					reduccion = Reducciones[34].Split('↓')[0].Trim();
					reducido = Reducciones[34].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado134(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 152
					StackDeConsumo.Push(152);
					return Estado152(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado135(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d153
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(153);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado153(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado136(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d154
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(154);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado154(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado137(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d155
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(155);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado155(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado138(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r46
					reduccion = Reducciones[46].Split('↓')[0].Trim();
					reducido = Reducciones[46].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado139(string _lookahead)
		{
			switch (_lookahead)
			{
				case ".":
					//desplazamiento a d156
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(156);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado156(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado140(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//desplazamiento a d119
					//consume !=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(119);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado119(StackDeEntrada.Peek());
				case "-":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r53
					reduccion = Reducciones[53].Split('↓')[0].Trim();
					reducido = Reducciones[53].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado141(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//desplazamiento a d120
					//consume ||
					StackDeEntrada.Pop();
					StackDeConsumo.Push(120);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado120(StackDeEntrada.Peek());
				case "-":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r55
					reduccion = Reducciones[55].Split('↓')[0].Trim();
					reducido = Reducciones[55].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado142(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//desplazamiento a d121
					//consume >
					StackDeEntrada.Pop();
					StackDeConsumo.Push(121);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado121(StackDeEntrada.Peek());
				case ">=":
					//desplazamiento a d122
					//consume >=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(122);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado122(StackDeEntrada.Peek());
				case "-":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r57
					reduccion = Reducciones[57].Split('↓')[0].Trim();
					reducido = Reducciones[57].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado143(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					// CONFLICTO a d123 / r59
					//desplazamiento a d123
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(123);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado123(StackDeEntrada.Peek());
				case "!":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r59
					reduccion = Reducciones[59].Split('↓')[0].Trim();
					reducido = Reducciones[59].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado144(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					// CONFLICTO a d123 / r60
					//desplazamiento a d123
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(123);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado123(StackDeEntrada.Peek());
				case "!":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r60
					reduccion = Reducciones[60].Split('↓')[0].Trim();
					reducido = Reducciones[60].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado145(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//desplazamiento a d124
					//consume /
					StackDeEntrada.Pop();
					StackDeConsumo.Push(124);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado124(StackDeEntrada.Peek());
				case "%":
					//desplazamiento a d125
					//consume %
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado125(StackDeEntrada.Peek());
				case "!":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r62
					reduccion = Reducciones[62].Split('↓')[0].Trim();
					reducido = Reducciones[62].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado146(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r64
					reduccion = Reducciones[64].Split('↓')[0].Trim();
					reducido = Reducciones[64].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado147(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r65
					reduccion = Reducciones[65].Split('↓')[0].Trim();
					reducido = Reducciones[65].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado148(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "=":
					//desplazamiento a d157
					//consume =
					StackDeEntrada.Pop();
					StackDeConsumo.Push(157);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado157(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r71
					reduccion = Reducciones[71].Split('↓')[0].Trim();
					reducido = Reducciones[71].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado149(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r73
					reduccion = Reducciones[73].Split('↓')[0].Trim();
					reducido = Reducciones[73].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado150(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d158
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(158);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado158(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado151(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					// CONFLICTO a d67 / r37
					//desplazamiento a d67
					//consume static
					StackDeEntrada.Pop();
					StackDeConsumo.Push(67);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado67(StackDeEntrada.Peek());
				case "class":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r37
					reduccion = Reducciones[37].Split('↓')[0].Trim();
					reducido = Reducciones[37].Split('↓')[1].Trim();
					if (reducido == "\'\'")
					{
						Simbolos += $" {reduccion}";
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "SBPC":
					//irA 159
					StackDeConsumo.Push(159);
					return Estado159(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado152(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r29
					reduccion = Reducciones[29].Split('↓')[0].Trim();
					reducido = Reducciones[29].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado153(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "Stmt":
					//irA 160
					StackDeConsumo.Push(160);
					return Estado160(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado154(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "Stmt":
					//irA 161
					StackDeConsumo.Push(161);
					return Estado161(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado155(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 162
					StackDeConsumo.Push(162);
					return Estado162(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado156(string _lookahead)
		{
			switch (_lookahead)
			{
				case "println":
					//desplazamiento a d163
					//consume println
					StackDeEntrada.Pop();
					StackDeConsumo.Push(163);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado163(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado157(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d127
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado127(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 164
					StackDeConsumo.Push(164);
					return Estado164(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado158(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r76
					reduccion = Reducciones[76].Split('↓')[0].Trim();
					reducido = Reducciones[76].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado159(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "static":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "class":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "interface":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "void":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "int":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "double":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolean":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "string":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "$":
					//reduccion a r36
					reduccion = Reducciones[36].Split('↓')[0].Trim();
					reducido = Reducciones[36].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado160(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					// CONFLICTO a d166 / r50
					//desplazamiento a d166
					//consume else
					StackDeEntrada.Pop();
					StackDeConsumo.Push(166);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado166(StackDeEntrada.Peek());
				case "-":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r50
					reduccion = Reducciones[50].Split('↓')[0].Trim();
					reducido = Reducciones[50].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "ElseStmt":
					//irA 165
					StackDeConsumo.Push(165);
					return Estado165(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado161(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r43
					reduccion = Reducciones[43].Split('↓')[0].Trim();
					reducido = Reducciones[43].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado162(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d167
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(167);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado167(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado163(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d168
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(168);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado168(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado164(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ")":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ".":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!=":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "||":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ">=":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "/":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "%":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r70
					reduccion = Reducciones[70].Split('↓')[0].Trim();
					reducido = Reducciones[70].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado165(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r42
					reduccion = Reducciones[42].Split('↓')[0].Trim();
					reducido = Reducciones[42].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado166(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "Stmt":
					//irA 169
					StackDeConsumo.Push(169);
					return Estado169(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado167(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 170
					StackDeConsumo.Push(170);
					return Estado170(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado168(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 171
					StackDeConsumo.Push(171);
					return Estado171(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado169(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r49
					reduccion = Reducciones[49].Split('↓')[0].Trim();
					reducido = Reducciones[49].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado170(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d172
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(172);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado172(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado171(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r52
					reduccion = Reducciones[52].Split('↓')[0].Trim();
					reducido = Reducciones[52].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//desplazamiento a d174
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(174);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado174(StackDeEntrada.Peek());
				case "ExPrint":
					//irA 173
					StackDeConsumo.Push(173);
					return Estado173(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado172(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d77
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d46
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado46(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d78
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d79
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d80
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado80(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d81
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado81(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d82
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado82(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d83
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(83);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado83(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 84
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "Stmt":
					//irA 175
					StackDeConsumo.Push(175);
					return Estado175(StackDeEntrada.Peek());
				case "Expr":
					//irA 76
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado173(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d176
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(176);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado176(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado174(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d85
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(85);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado85(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d96
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado96(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d92
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado92(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d93
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(93);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado93(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d97
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado97(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d98
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado98(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d99
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado99(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d100
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado100(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d101
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado101(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d102
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado102(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d103
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(103);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado103(StackDeEntrada.Peek());
				case "Expr":
					//irA 177
					StackDeConsumo.Push(177);
					return Estado177(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 86
					StackDeConsumo.Push(86);
					return Estado86(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 87
					StackDeConsumo.Push(87);
					return Estado87(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 88
					StackDeConsumo.Push(88);
					return Estado88(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 89
					StackDeConsumo.Push(89);
					return Estado89(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 90
					StackDeConsumo.Push(90);
					return Estado90(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 91
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 94
					StackDeConsumo.Push(94);
					return Estado94(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 95
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado175(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r44
					reduccion = Reducciones[44].Split('↓')[0].Trim();
					reducido = Reducciones[44].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado176(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d178
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(178);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado178(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado177(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r52
					reduccion = Reducciones[52].Split('↓')[0].Trim();
					reducido = Reducciones[52].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ",":
					//desplazamiento a d174
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(174);
					Simbolos += $" { _lookahead} ";
					Simbolos = Simbolos.Trim();
					return Estado174(StackDeEntrada.Peek());
				case "ExPrint":
					//irA 179
					StackDeConsumo.Push(179);
					return Estado179(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado178(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case ";":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "(":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "{":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "}":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "if":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "while":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "for":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "break":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "return":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "System":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "else":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "-":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "!":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "this":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "New":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "intConstant":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "doubleConstant":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "boolConstant":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "stringConstant":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				case "null":
					//reduccion a r47
					reduccion = Reducciones[47].Split('↓')[0].Trim();
					reducido = Reducciones[47].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}
		public bool Estado179(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r51
					reduccion = Reducciones[51].Split('↓')[0].Trim();
					reducido = Reducciones[51].Split('↓')[1].Trim();
					Simbolos = Simbolos.Replace(reducido, reduccion);
					unStack = reducido.Split(' ').Length;
					for (int i = 0; i < unStack; i++)
					{
						StackDeConsumo.Pop();
					}
					return IrA(StackDeConsumo.Peek(), reduccion);
				default:
					Err(); return false;
			}
		}

		#endregion

	}
}
