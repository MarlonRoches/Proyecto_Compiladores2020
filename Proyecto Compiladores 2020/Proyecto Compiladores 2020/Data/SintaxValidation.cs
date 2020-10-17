using System;
using System.Collections.Generic;
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
		static Stack<string> StackDeEntrada = new Stack<string>();
		static List<string> Pasos = new List<string>();
		static List<KeyValuePair<string, string>> Entrada;
		// calcular lookahead
		// 
		// obtener lista de tokens
		// error: leer hasta ; y seguir
		// des stackear estados


		public void Parser(List<KeyValuePair<string, string>> _Aceptados)
		{

			StackDeConsumo.Push(0);
			Entrada = _Aceptados;
			for (int i = _Aceptados.Count - 1; i >= 0; i--)
			{
				StackDeEntrada.Push(_Aceptados[i].Key);
			}
			var xd =StackDeEntrada.Pop();

		}

		public bool Estado0(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado1(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado2(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado3(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado4(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado5(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado6(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado7(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado8(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado9(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado10(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado11(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado12(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado13(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado14(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado15(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado16(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado17(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado18(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado19(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado20(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado21(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado22(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado23(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado24(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado25(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado26(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado27(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado28(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado29(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado30(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado31(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado32(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado33(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado34(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado35(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado36(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado37(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado38(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado39(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado40(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado41(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado42(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado43(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado44(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado45(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado46(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado47(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado48(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado49(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado50(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado51(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado52(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado53(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado54(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado55(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado56(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado57(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado58(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado59(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado60(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado61(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado62(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado63(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado64(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado65(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado66(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado67(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado68(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado69(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado70(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado71(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado72(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado73(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado74(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado75(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado76(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado77(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado78(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado79(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado80(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado81(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado82(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado83(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado84(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado85(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado86(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado87(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado88(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado89(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado90(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado91(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado92(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado93(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado94(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado95(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado96(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado97(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado98(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado99(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado100(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado101(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado102(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado103(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado104(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado105(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado106(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado107(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado108(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado109(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado110(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado111(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado112(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado113(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado114(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado115(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado116(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado117(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado118(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado119(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado120(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado121(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado122(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado123(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado124(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado125(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado126(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado127(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado128(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado129(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado130(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado131(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado132(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado133(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado134(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado135(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado136(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado137(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado138(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado139(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado140(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado141(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado142(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado143(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado144(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado145(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado146(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado147(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado148(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado149(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado150(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado151(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado152(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado153(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado154(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado155(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado156(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado157(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado158(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado159(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado160(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado161(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado162(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado163(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado164(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado165(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado166(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado167(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado168(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado169(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado170(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado171(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado172(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado173(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado174(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}
		public bool Estado175(Stack<int> _Pila, string _actual, string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(9);
					return Estado9(null, null, null);
				case "const":
					//desplazamiento a d5
					//consume const
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(5);
					return Estado5(null, null, null);
				case "class":
					//desplazamiento a d6
					//consume class
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(6);
					return Estado6(null, null, null);
				case "interface":
					//desplazamiento a d7
					//consume interface
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(7);
					return Estado7(null, null, null);
				case "void":
					//desplazamiento a d10
					//consume void
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(10);
					return Estado10(null, null, null);
				case "int":
					//desplazamiento a d11
					//consume int
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(11);
					return Estado11(null, null, null);
				case "double":
					//desplazamiento a d12
					//consume double
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(12);
					return Estado12(null, null, null);
				case "bool":
					//desplazamiento a d13
					//consume bool
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(13);
					return Estado13(null, null, null);
				case "string":
					//desplazamiento a d14
					//consume string
					//StackDeEntrada.Pop();
					//StackDeConsumo.Push(14);
					return Estado14(null, null, null);
				case "Program":
					//irA 1
					return Estado1(null, null, null);
				case "Decl":
					//irA 2
					return Estado2(null, null, null);
				case "Type":
					//irA 3
					return Estado3(null, null, null);
				case "FRoot":
					//irA 4
					return Estado4(null, null, null);
				case "CnsTp":
					//irA 8
					return Estado8(null, null, null);

				default:
					Err(); return false;
			}
		}

		public void Err()
		{
			
		}

		public void EstadoDePrueba()
		{
			var actual ="";
			switch (actual)
			{
				default:

					break;
			}
		}

	}
}
