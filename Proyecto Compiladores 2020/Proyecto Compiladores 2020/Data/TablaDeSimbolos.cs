using Proyecto_Compiladores_2020.Data.Simbolos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//0
namespace Proyecto_Compiladores_2020.Data
{//1
	public class TablaDeSimbolos
	{//2
		private static TablaDeSimbolos _instance = null;
		public static TablaDeSimbolos Instance
		{//3
			get
			{//4
				if (_instance == null) _instance = new TablaDeSimbolos();
				return _instance;
			}
		}//3
		/// <summary>
		/// Contador del nivel en base a llaves
		/// </summary>
		static int scoopingLevel = 0;
		/// <summary>
		/// Contador Del Interno
		/// </summary>
		static int ScoopingActual = 0;
		static Dictionary<string, Variables> Variables = new Dictionary<string, Variables>();
		static Dictionary<string, Variables> Metodos = new Dictionary<string, Variables>();
		static Dictionary<string, Interfaz> Interfaces = new Dictionary<string, Interfaz>();
		static Dictionary<string, Clase> Clases = new Dictionary<string, Clase>();

		/// Tipos de Sentencias
		////Declaraciones
		///types (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string)
		////* variables, staticas, clases
		private static Regex RgxSimples = new Regex(@"^(([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex RgxEstaticas = new Regex(@"^static (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex RgxClases = new Regex(@"^class ([a-z]|[A-Z]|([0-9]))+( extends ([a-z]|[A-Z]|([0-9]))+)?( implements ([a-z]|[A-Z]|([0-9]))+( , ([a-z]|[A-Z]|([0-9]))*)*)?$$");
		///metodos
        private static Regex RgxMetodos = new Regex(@"^(void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+ \( (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+( , (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+)* \)$");
		///metodos
        private static Regex RgxInterfaz = new Regex(@"^interface ([a-z]|[A-Z]|([0-9]))+$");
		private static Stack<string> PilaDeAmbitos = new Stack<string>();
		//-> asignacion de tipos, metodos y parametros
		/////*Operaciones
		//-> Regex o gramatica especial

		//////* Calculo de operaciones

		public void ObtenerSimbolos(List<KeyValuePair<string, string>> tokensAceptados)
		{//5
			PilaDeAmbitos.Push("Global");
			var cadena = "";
			for (int i = 0; i < tokensAceptados.Count; i++)
			{
				cadena += $" {tokensAceptados[i].Value}";
				cadena = cadena.Trim();
			}

			var actual = 0;		
			while (cadena!="")
			{
				var aux = "";
				while (tokensAceptados[actual].Key != ";" && tokensAceptados[actual].Key != ")" && tokensAceptados[actual].Key != "{" && tokensAceptados[actual].Key != "}")
				{
					aux += $" {tokensAceptados[actual].Value}";
					aux = aux.Trim();
					actual++;
				}
				if (tokensAceptados[actual].Key == "{")
				{
					if (aux == "")
					{//solo encontro la llave
						cadena = cadena.Remove(0,cadena.IndexOf("{")+1).Trim();
					}
					else
					{
						IdentificarDeclaracion(aux);
						cadena = cadena.Replace(aux + " {", "").Trim();

					}
					scoopingLevel++;
					ScoopingActual++;
					actual++;
				}
				else if (tokensAceptados[actual].Key == "}")
				{
					if (aux == "")
					{//solo encontro la llave
						cadena = cadena.Remove(0, cadena.IndexOf("}") + 1).Trim();
					}
					else
					{
						IdentificarDeclaracion(aux);
						cadena = cadena.Replace(aux + " {", "").Trim();

					}
					scoopingLevel++;
					ScoopingActual--;
					//cerramos un ambito y lo sacamos de la pila
					PilaDeAmbitos.Pop();
					actual++;

				}
				else
				{
					aux += $" {tokensAceptados[actual].Value}";
					aux = aux.Trim();
					actual++;
					IdentificarDeclaracion(aux);
					cadena = cadena.Replace(aux, "").Trim();
				}
				
			}
			//variable simples int, string, boolean , ident , 
			//staticas
			//scoopear por {}
			//class leer hasta encontrar )

			var xd = 0;
		}
		
		void CargarSimboloADiccionario(string Symbolo)
		{
			if (Variables.ContainsKey($"{Symbolo}↓{ScoopingActual}"))
			{
			}
			else
			{
				//crear simbolo
				if (Symbolo.Split(' ')[Symbolo.Split(' ').Length-1] ==";")
				{//es una instancia

				}
				else if (Symbolo.Split(' ')[Symbolo.Split(' ').Length - 1] == ")")
				{//es un metodo

				}
				var NuevoSimbolo = new Variables();
				
			}
		}
		bool IdentificarDeclaracion(string Sentencia)
		{
			if (RgxSimples.IsMatch(Sentencia))
			{
				//variables simples
				var sim = new Variables();
				var arreglo = Sentencia.Split();
				var tipo = arreglo[0];
				
				if (arreglo[1] == "[]")
				{
					sim.Nombre = arreglo[2];
					sim.Array = true;
				}
				else
				{
					sim.Nombre = arreglo[1];
					sim.Array = false;
				}
				sim.tipo = tipo;
				
				//validar arreglo
				//agrega
				sim.Ambito = PilaDeAmbitos.Peek();
				sim.val = null;
				sim.Estatica = false;
				GuardarVariable(sim);
				return true;

			}
			else if (RgxEstaticas.IsMatch(Sentencia))
			{
				//variable estatica
				var arreglo = Sentencia.Split();
				var tipo = arreglo[1];
				var nombre = arreglo[2];
				var sim = new Variables();
				sim.tipo = tipo;
				sim.Nombre = nombre;
				sim.Ambito = PilaDeAmbitos.Peek();
				sim.val = null;
				sim.Estatica = true;
				GuardarVariable(sim);
				return true;

			}
			else if (RgxClases.IsMatch(Sentencia))
			{//CLASES
				var clases = new Clase();
				var splited = Sentencia.Replace(" , "," ").Split(' ');
				clases.Nombre = splited[1];
				clases.Ambito = PilaDeAmbitos.Peek();
				if (Sentencia.Contains("extends"))
				{
					clases.HeredaDe = splited[3];
				}
				if (Sentencia.Contains("implements"))
				{
					var inicio = Sentencia.IndexOf("implements");
					var parteAEliminar ="";
					for (int i = 0; i < inicio; i++)
					{
						parteAEliminar += Sentencia[i];
					}
					var saux = Sentencia.Replace(parteAEliminar, "").Replace("implements ", "").Split(',');

					for (int i = 0; i < saux.Length; i++)
					{
						clases.Interfaces.Add(saux[i].Trim());
					}
					PilaDeAmbitos.Push(clases.Nombre);
					var stop = 0;	
				}
				GuardarClase(clases);
				return true	;

			}
			else if (RgxMetodos.IsMatch(Sentencia))
			{//METODOS
				var MetodoActual = new Metodo()
				{
					Tipo = Sentencia.Split(' ')[0],
					Nombre= Sentencia.Split(' ')[1],
					Ambito = PilaDeAmbitos.Peek()
				};
				MetodoActual.Ambito = PilaDeAmbitos.Peek();
				var ParametrosDeMetodo = Sentencia.Remove(0, Sentencia.IndexOf('(')).Trim().Replace("(","").Replace(")", "").Replace(" , ", ",").Split(',');
				//diccionario clases[clase actual].metodos.add(nombre defuncion); 
				//metodos generales.add[nombre, clase funcion]
				foreach (var item in ParametrosDeMetodo)
				{
					var ParametroActual = new Variables()
					{
						tipo = item.Trim().Split(' ')[0],
						Ambito = MetodoActual.Ambito

					};
					if (item.Trim().Contains("[]"))
					{//es un parametro tipo array
						ParametroActual.Array = true;
						ParametroActual.Nombre = item.Trim().Split(' ')[2];
					}
					else
					{//es un parametro normal
						ParametroActual.Nombre = item.Trim().Split(' ')[1];
					}

					if (MetodoActual.Parametros.ContainsKey(ParametroActual.Nombre))
					{//parametro de nombre repetido

					}
					else
					{
						MetodoActual.Parametros.Add(ParametroActual.Nombre, ParametroActual);

					}


				}
				PilaDeAmbitos.Push(MetodoActual.Nombre);

				return true;

			}
			else if (RgxInterfaz.IsMatch(Sentencia))
			{
				return true;
			}else
			{
				return false;

			}

		}

		void GuardarVariable(Variables VariableAGuardar_)
		{
			if (Variables.ContainsKey(VariableAGuardar_.Nombre))
			{
				Console.WriteLine($"Una variable ya fue declarada con el nobre \"{VariableAGuardar_.Nombre}\" en el ambito {VariableAGuardar_.Ambito}");
			}
			else
			{
				Variables.Add(VariableAGuardar_.Nombre, VariableAGuardar_);
			}
		}
		void GuardarMetodo(Metodo MetodoAGuardar_)
		{
			if (Clases.ContainsKey(MetodoAGuardar_.Nombre))
			{
				Console.WriteLine($"Una clase ya fue declarada con el nobre \"{MetodoAGuardar_.Nombre}\" en el ambito {MetodoAGuardar_.Ambito}");

			}
			else
			{

			}
		}
		//------------------------------------- QUE NO SE TE OLVIDE ------------------------
		//guardar por ambitos
		// hacer la llamada a el ambito mas cercano
		void GuardarInterfaz(Interfaz InterfazA_Guardar_)
		{
			if (Clases.ContainsKey(InterfazA_Guardar_.Nombre))
			{
				Console.WriteLine($"Una clase ya fue declarada con el nobre \"{InterfazA_Guardar_.Nombre}\" en el ambito {InterfazA_Guardar_.Ambito}");

			}
			else
			{

			}
		}
		void GuardarClase( Clase ClaseA_Guardar_)
		{
			if (Clases.ContainsKey(ClaseA_Guardar_.Nombre))
			{
				Console.WriteLine($"Una clase ya fue declarada con el nobre \"{ClaseA_Guardar_.Nombre}\" en el ambito {ClaseA_Guardar_.Ambito}");

			}
			else
			{
				Clases.Add(ClaseA_Guardar_.Nombre, ClaseA_Guardar_);
			}
		}
		void CalcularOperaciones()
		{ 
		
		}


		#region Antes


		//void Antes()
		//{
		//	var actual = 0;
		//	tokensAceptados
		//	while (actual < tokensAceptados.Count)
		//	{
		//		//mientras no se nos acaben las lineas
		//		var Symbol = "";
		//		switch (tokensAceptados[actual].Key)
		//		{
		//			case "ident":

		//				break;

		//			case ";":
		//				actual++;
		//				break;
		//			case "(":

		//				break;
		//			case ")":

		//				break;
		//			case "void":

		//				break;

		//			case "static":
		//				while (tokensAceptados[actual].Key != ";" || tokensAceptados[actual].Key != ";")
		//				{
		//					Symbol += $" {tokensAceptados[actual].Value}";
		//					Symbol = Symbol.Trim();
		//					actual++;
		//				}

		//				break;
		//			case "class":

		//				break;
		//			case "{":
		//				//encontramos nuevo scooping
		//				ScoopingActual++;
		//				//Entramos a otro nivel
		//				scoopingLevel++;
		//				break;
		//			case "}":
		//				//Salimos de nivel a otro nivel
		//				ScoopingActual--;

		//				break;
		//			case "interface":

		//				break;
		//			case "[]":

		//				break;
		//			case ",":

		//				break;
		//			case "int":
		//				while (tokensAceptados[actual].Key != ";" && tokensAceptados[actual].Key != ")")
		//				{
		//					Symbol += $" {tokensAceptados[actual].Value}";
		//					Symbol = Symbol.Trim();
		//					actual++;
		//				}
		//				//agregamos el siguiente simbolo
		//				Symbol += $" {tokensAceptados[actual].Value}";
		//				Symbol = Symbol.Trim();
		//				actual++;
		//				CargarSimboloADiccionario(Symbol);
		//				break;
		//			case "double":
		//				//while (tokensAceptados[actual].Key != ";")
		//				//{
		//				//	Symbol += $" {tokensAceptados[actual].Value}";
		//				//	Symbol = Symbol.Trim();
		//				//	actual++;
		//				//}
		//				break;
		//			case "boolean":
		//				//while (tokensAceptados[actual].Key != ";")
		//				//{
		//				//	Symbol += $" {tokensAceptados[actual].Value}";
		//				//	Symbol = Symbol.Trim();
		//				//	actual++;
		//				//}
		//				//Symbol += $" {tokensAceptados[actual].Value}";
		//				//Symbol = Symbol.Trim();
		//				//actual++;
		//				break;
		//			case "string":
		//				while (tokensAceptados[actual].Key != ";")
		//				{
		//					Symbol += $" {tokensAceptados[actual].Value}";
		//					Symbol = Symbol.Trim();
		//					actual++;
		//				}
		//				break;
		//			case "extends":

		//				break;
		//			case "implements":

		//				break;
		//			case "if":

		//				break;
		//			case "while":

		//				break;
		//			case "for":

		//				break;
		//			case "break":

		//				break;
		//			case "return":

		//				break;
		//			case "System":

		//				break;
		//			case ".":

		//				break;
		//			case "out":

		//				break;
		//			case "println":

		//				break;
		//			case "else":

		//				break;
		//			case "-":

		//				break;
		//			case "/":

		//				break;
		//			case "%":

		//				break;
		//			case ">":

		//				break;
		//			case ">=":

		//				break;
		//			case "!=":

		//				break;
		//			case "||":

		//				break;
		//			case "!":

		//				break;
		//			case "New":

		//				break;
		//			case "=":

		//				break;
		//			case "this":

		//				break;
		//			case "intConstant":

		//				break;
		//			case "stringConstant":

		//				break;
		//			case "boolConstant":

		//				break;
		//			case "doubleConstant":

		//				break;
		//			case "null":

		//				break;
		//			default:
		//				break;
		//		}

		//	}
		//}
		#endregion
	}
}
