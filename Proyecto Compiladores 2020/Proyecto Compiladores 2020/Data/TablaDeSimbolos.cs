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
		static int scoopingLevel = 0;
		static int ScoopingActual = 0;
		static Dictionary<string, Simbolo> Simbolos = new Dictionary<string, Simbolo>();
		//private static Regex Keywords = new Regex(@"^(void|int|double|boolean|string|class|static|interface|null|this|extends|implements|for|while|if|else|return|break|New|System|out|println)$");

		/// Tipos de Sentencias
		////Declaraciones
		///types (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string)
		////* variables, staticas, clases
		private static Regex Simples = new Regex(@"^(([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex Estaticas = new Regex(@"^static (([a-z]|[A-Z]|([0-9]))+|int|double|boolean|string) (\[\] )?([a-z]|[A-Z]|([0-9]))* ;$");
        private static Regex Clases = new Regex(@"^class ([a-z]|[A-Z]|([0-9]))+ extends ([a-z]|[A-Z]|([0-9]))+ implements ([a-z]|[A-Z]|([0-9]))+( , ([a-z]|[A-Z]|([0-9]))*)*$");
		///metodos
        private static Regex Metodos = new Regex(@"^(void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+ \( (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+( , (void|int|double|boolean|string|([a-z]|[A-Z]|([0-9]))+) (\[\] )?([a-z]|[A-Z]|([0-9]))+)* \)$");
		//-> asignacion de tipos, metodos y parametros
		/////*Operaciones
		//-> Regex o gramatica especial

		//////* Calculo de operaciones

		public void ObtenerSimbolos(List<KeyValuePair<string, string>> tokensAceptados)
		{
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
				while (tokensAceptados[actual].Key != ";" || tokensAceptados[actual].Key != ";")
				{
					aux += $" {tokensAceptados[actual].Value}";
					aux = aux.Trim();
					actual++;
				}
				aux += $" {tokensAceptados[actual].Value}";
				aux = aux.Trim();
				actual++;
				IdentificarDeclaracion(aux);
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
			if (Simbolos.ContainsKey($"{Symbolo}↓{ScoopingActual}"))
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
				var NuevoSimbolo = new Simbolo();
				
			}
		}
		bool IdentificarDeclaracion(string Sentencia)
		{
			if (Simples.IsMatch(Sentencia))
			{
				//variables simples
				return true;

			}
			else if (Estaticas.IsMatch(Sentencia))
			{
				//variable estatica
				return true;

			}
			else
			{
				return false;

			}

		}

		void IdentificarFuncion()
		{ 

		}
		void CalcularOperaciones()
		{ 
		
		}
	}
}
