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
		static Dictionary<string, Simbolo> CargaDeSimbolos = new Dictionary<string, Simbolo>();
        //private static Regex Keywords = new Regex(@"^(void|int|double|boolean|string|class|static|interface|null|this|extends|implements|for|while|if|else|return|break|New|System|out|println)$");
		
		/// Tipos de Sentencias
		////Declaraciones
		////* variables, staticas, metodos
		//-> asignacion de tipos, metodos y parametros
		/////*Operaciones
		//-> Regex o gramatica especial

		//////* Calculo de operaciones

		public void ObtenerSimbolos(List<KeyValuePair<string, string>> tokensAceptados)
		{
			var actual = 0;
			while (actual < tokensAceptados.Count)
			{
				//mientras no se nos acaben las lineas
				var Symbol = "";
				switch (tokensAceptados[actual].Key)
				{
					case "ident":

						break;

					case ";":

						break;
					case "(":

						break;
					case ")":

						break;
					case "void":

						break;

					case "static":
						while (tokensAceptados[actual].Key != ";")
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
						while (tokensAceptados[actual].Key != ";")
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						}

						break;
					case "double":
						while (tokensAceptados[actual].Key != ";")
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						}
						break;
					case "boolean":
						do
						{
							Symbol += $" {tokensAceptados[actual].Value}";
							Symbol = Symbol.Trim();
							actual++;
						} while (tokensAceptados[actual].Key != ";");
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
		void CargarSimboloADiccionario()
		{

		}
		bool IdentificarSymbolo(string Sentencia)
		{
			return true;
		}

		void ObtenerOperaciones()
		{ 
		}
		void CalcularOperaciones()
		{ 
		
		}
	}
}
