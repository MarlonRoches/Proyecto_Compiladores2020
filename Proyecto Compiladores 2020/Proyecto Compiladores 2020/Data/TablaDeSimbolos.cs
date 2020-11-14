using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data
{
	public class TablaDeSimbolos
	{
		private static TablaDeSimbolos _instance = null;
		public static TablaDeSimbolos Instance
		{
			get
			{
				if (_instance == null) _instance = new TablaDeSimbolos();
				return _instance;
			}
		}
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

		/// Tipos de Sentencias
		////Declaraciones
		///types (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string)
		////* variables, staticas, clases
		private static Regex RgxSimples = new Regex(@"^(([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex RgxEstaticas = new Regex(@"^static (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex RgxClases = new Regex(@"^class ([a-z]|[A-Z]|([0-9]))+( extends ([a-z]|[A-Z]|([0-9]))+)?( implements ([a-z]|[A-Z]|([0-9]))+( , ([a-z]|[A-Z]|([0-9]))*)*)?$$");
		///metodos
        private static Regex RgxMetodos = new Regex(@"^(void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+ \( (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+( , (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+)* \)$");
		private static Stack<int> Accesibilidad = new Stack<int>();
		//-> asignacion de tipos, metodos y parametros
		/////*Operaciones
		//-> Regex o gramatica especial

		//////* Calculo de operaciones

		public void ObtenerSimbolos(List<KeyValuePair<string, string>> tokensAceptados)
		{
			Accesibilidad.Push(ScoopingActual);
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
					IdentificarDeclaracion(aux);

					scoopingLevel++;
					ScoopingActual++;

					actual++;

				}
				else if (tokensAceptados[actual].Key == "}")
				{
					IdentificarDeclaracion(aux);
					scoopingLevel++;
					ScoopingActual--;

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
			

			while (actual < tokensAceptados.Count)
			{
				//mientras no se nos acaben las lineas
				var Symbol = "";
				switch (tokensAceptados[actual].Key)
				{
					case "ident":

						break;

					case ";":
						actual++;
						break;
					case "(":

						break;
					case ")":

						break;
					case "void":

						break;

					case "static":
						while (tokensAceptados[actual].Key != ";"||tokensAceptados[actual].Key != ";")
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						}

						break;
					case "class":

						break;
					case "{":
						//encontramos nuevo scooping
						ScoopingActual++;
						//Entramos a otro nivel
						scoopingLevel++;
						break;
					case "}":
						//Salimos de nivel a otro nivel
						ScoopingActual--;

						break;
					case "interface":

						break;
					case "[]":

						break;
					case ",":

						break;
					case "int":
						while (tokensAceptados[actual].Key != ";" && tokensAceptados[actual].Key != ")")
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						}
						//agregamos el siguiente simbolo
						Symbol += $" {tokensAceptados[actual].Value}";
						Symbol = Symbol.Trim();
						actual++;
						CargarSimboloADiccionario(Symbol);
						break;
					case "double":
						//while (tokensAceptados[actual].Key != ";")
						//{
						//	Symbol += $" {tokensAceptados[actual].Value}";
						//	Symbol = Symbol.Trim();
						//	actual++;
						//}
						break;
					case "boolean":
						//while (tokensAceptados[actual].Key != ";")
						//{
						//	Symbol += $" {tokensAceptados[actual].Value}";
						//	Symbol = Symbol.Trim();
						//	actual++;
						//}
						//Symbol += $" {tokensAceptados[actual].Value}";
						//Symbol = Symbol.Trim();
						//actual++;
						break;
					case "string":
						while (tokensAceptados[actual].Key != ";")
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						}
						break;
					case "extends":

						break;
					case "implements":

						break;
					case "if":

						break;
					case "while":

						break;
					case "for":

						break;
					case "break":

						break;
					case "return":

						break;
					case "System":

						break;
					case ".":

						break;
					case "out":

						break;
					case "println":

						break;
					case "else":

						break;
					case "-":

						break;
					case "/":

						break;
					case "%":

						break;
					case ">":

						break;
					case ">=":

						break;
					case "!=":

						break;
					case "||":

						break;
					case "!":

						break;
					case "New":

						break;
					case "=":

						break;
					case "this":

						break;
					case "intConstant":

						break;
					case "stringConstant":

						break;
					case "boolConstant":

						break;
					case "doubleConstant":

						break;
					case "null":

						break;
					default:
						break;
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
				var sim = new Variables();
				//variables simples
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
				sim.Accesibilidad = ScoopingActual;
				sim.val = null;
				sim.Estatica = false;
				guardarSimbolo(sim);
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
				sim.Accesibilidad = ScoopingActual;
				sim.val = null;
				sim.Estatica = true;
				guardarSimbolo(sim);
				return true;

			}
			else if (RgxClases.IsMatch(Sentencia))
			{
				var clases = new Clase();
				var splited = Sentencia.Replace(" , "," ").Split(' ');
				clases.Nombre = splited[1];
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
						clases.Interfaz.Add(saux[i].Trim());
					}
					var stop = 0;	
				}

				return true	;

			}
			else if (RgxMetodos.IsMatch(Sentencia))
			{
				return true;

			}
			else
			{
				return false;

			}

		}

		void guardarSimbolo(Variables Sym)
		{
			if (Variables.ContainsKey(Sym.Nombre))
			{
				Console.WriteLine($"Una funcion o variable ya fue declarada con el nobre \"{Sym.Nombre}\"");
			}
			else
			{
				Variables.Add(Sym.Nombre, Sym);
			}
		}
		void CalcularOperaciones()
		{ 
		
		}
	}
}
