using Proyecto_Compiladores_2020.Data.Simbolos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aspose.Cells;
using Aspose.Cells.Utility;
using System.Data;
using Z.Expressions;
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

		static Dictionary<string, Ambito> RegistroDeAmbitos = new Dictionary<string, Ambito>();

		static Dictionary<string, Variables> Variables = new Dictionary<string, Variables>();
		static Dictionary<string, Metodo> Metodos = new Dictionary<string, Metodo>();
		static Dictionary<string, Interfaz> Interfaces = new Dictionary<string, Interfaz>();
		static Dictionary<string, Clase> Clases = new Dictionary<string, Clase>();
		///FALTA PASARLO TODO A EL QUE VA POR AMBITOS
		///FALTA N LOS STMT
		///FALTAN VALIDAR LOS EXPR
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

		//RGX de Operaciones
		private static Regex Asignacion = new Regex(@"^([a-z]|[A-Z]|([0-9]))+ = .+( ;)?$");
		private static Stack<string> PilaDeAmbitos = new Stack<string>();
		private static Stack<string> PilaDeTipoDeSentencia = new Stack<string>();
		//string lol = "\"";
		//-> asignacion de tipos, metodos y parametros
		/////*Operaciones
		//-> Regex o gramatica especial
		private static Regex Operadores = new Regex(@"^(\+|-|\*|/|%|<|<=|>|>=|=|==|!=|&&|\|\||!|;|,|\.|\[|\]|\(|\)|{|}|\[\]|\(\)|{})$");
		private static Regex Boolean = new Regex("true|false");
		private static Regex Identifier = new Regex(@"^([a-z]|[A-Z]|([0-9]))+$");
		private static Regex Number = new Regex(@"^([0-9])+$");

		private static Regex RgxStmts= new Regex(@"^(if|while|for|System \. out \. println) \( .+ \)$");

		private static Dictionary<string, string> Cadenas;
		//////* Calculo de operaciones

		public void TamblaDeSimbolosFase3(List<KeyValuePair<string, string>> tokensAceptados)
		{//5
			Cadenas = TextValidation.Cadenas;
			AbrirUnAmbito("Global");
			PilaDeTipoDeSentencia.Push("Global");
			var cadena = "";
			for (int i = 0; i < tokensAceptados.Count; i++)
			{
				cadena += $" {tokensAceptados[i].Value}";
				cadena = cadena.Trim();
			}

			var actual = 0;
			while (cadena != "")
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
						cadena = cadena.Remove(0, cadena.IndexOf("{") + 1).Trim();
					}
					else
					{
						IdentificarDeclaracion(aux);

						cadena = QuitarTokensDeLaCadena(cadena, aux + " {");

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

						cadena = QuitarTokensDeLaCadena(cadena, aux + " {");

					}
					scoopingLevel++;
					ScoopingActual--;
					//cerramos un ambito y lo sacamos de la pila
					if ((PilaDeAmbitos.Peek() == "Global"))
					{

					}
					else
					{
						RegistroDeAmbitos[PilaDeAmbitos.Peek()].Accesible = false;
						PilaDeAmbitos.Pop();
						PilaDeTipoDeSentencia.Pop();

					}
					actual++;

				}
				else
				{
					if (aux == ";")
					{
						cadena = cadena.Remove(0, cadena.IndexOf(";") + 1).Trim();

					}
					else
					{
						aux += $" {tokensAceptados[actual].Value}";
						aux = aux.Trim();
						actual++;
						IdentificarDeclaracion(aux);

						cadena = QuitarTokensDeLaCadena(cadena, aux);

					}
				}

			}
			var xd = JsonConvert.SerializeObject(RegistroDeAmbitos);
			// Create a Workbook object
			Workbook workbook = new Workbook();
			Worksheet worksheet = workbook.Worksheets[0];

			// Read JSON File
			string jsonInput = xd;

			// Set JsonLayoutOptions
			JsonLayoutOptions options = new JsonLayoutOptions();
			options.ArrayAsTable = true;

			// Import JSON Data
			JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

			// Save Excel file
			workbook.Save("TablaDeSimbolos.xlsx");
		}
		bool IdentificarDeclaracion(string Sentencia)
		{
			if (RgxSimples.IsMatch(Sentencia))
			{
				//variables simples
				var VariableAGuardar = new Variables();
				var arreglo = Sentencia.Split();
				var tipo = arreglo[0];

				if (arreglo[1] == "[]")
				{
					VariableAGuardar.Nombre = arreglo[2];
					VariableAGuardar.Array = true;
				}
				else
				{
					VariableAGuardar.Nombre = arreglo[1];
					VariableAGuardar.Array = false;
				}
				VariableAGuardar.tipo = tipo;

				//validar arreglo
				//agrega
				VariableAGuardar.Ambito = PilaDeAmbitos.Peek();
				VariableAGuardar.val = null;
				VariableAGuardar.Estatica = false;
				GuardarVariableEnAmbito(VariableAGuardar);
				return true;

			}
			else if (RgxEstaticas.IsMatch(Sentencia))
			{
				//variable estatica
				var arreglo = Sentencia.Split();
				var tipo = arreglo[1];
				var nombre = arreglo[2];
				var VariableAGuardar = new Variables();
				VariableAGuardar.tipo = tipo;
				VariableAGuardar.Nombre = nombre;
				VariableAGuardar.Ambito = PilaDeAmbitos.Peek();
				VariableAGuardar.val = null;
				VariableAGuardar.Estatica = true;
				GuardarVariableEnAmbito(VariableAGuardar);
				return true;

			}
			else if (RgxClases.IsMatch(Sentencia))
			{//CLASES
				var clases = new Clase();
				var splited = Sentencia.Replace(" , ", " ").Split(' ');
				clases.Nombre = splited[1];
				clases.Ambito = PilaDeAmbitos.Peek();
				if (Sentencia.Contains("extends"))
				{
					clases.HeredaDe = splited[3];
				}
				if (Sentencia.Contains("implements"))
				{
					var inicio = Sentencia.IndexOf("implements");
					var parteAEliminar = "";
					for (int i = 0; i < inicio; i++)
					{
						parteAEliminar += Sentencia[i];
					}
					var saux = Sentencia.Replace(parteAEliminar, "").Replace("implements ", "").Split(',');

					for (int i = 0; i < saux.Length; i++)
					{
						clases.Interfaces.Add(saux[i].Trim());
					}

					var stop = 0;
				}
				//GuardarClase(clases);
				GuardarClaseEnAmbito(clases);
				AbrirUnAmbito(clases.Nombre);
				PilaDeTipoDeSentencia.Push("Clase");
				return true;

			}
			else if (RgxMetodos.IsMatch(Sentencia))
			{//METODOS
				var MetodoActual = new Metodo()
				{
					Tipo = Sentencia.Split(' ')[0],
					Nombre = Sentencia.Split(' ')[1],
					Ambito = PilaDeAmbitos.Peek()
				};
				MetodoActual.Ambito = PilaDeAmbitos.Peek();
				var ParametrosDeMetodo = Sentencia.Remove(0, Sentencia.IndexOf('(')).Trim().Replace("(", "").Replace(")", "").Replace(" , ", ",").Split(',');
				//diccionario clases[clase actual].metodos.add(nombre defuncion); 
				//metodos generales.add[nombre, clase funcion]
				foreach (var item in ParametrosDeMetodo)
				{
					var ParametroActual = new Variables()
					{
						tipo = item.Trim().Split(' ')[0],
						Ambito = MetodoActual.Nombre

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
				GuardarMetodo(MetodoActual);
				if (PilaDeTipoDeSentencia.Peek() == "Interfaz")
				{

				}
				else
				{
					//AbrirUnAmbito(MetodoActual.Nombre);
					//PilaDeTipoDeSentencia.Push("Metodo");

				}

				return true;

			}
			else if (RgxInterfaz.IsMatch(Sentencia))
			{
				var InterfazActual = new Interfaz()
				{
					Nombre = Sentencia.Trim().Split(' ')[1], Ambito = PilaDeAmbitos.Peek()
				};

				if (AbrirUnAmbito(InterfazActual.Nombre))
				{
					GuardarInterfazEnAmbito(InterfazActual);
					PilaDeTipoDeSentencia.Push("Interfaz");
				}
				else
				{//Error en Apertura de Ambito por que ya existia en el actual


				}

				return true;
			}
			else
			{
				if (Asignacion.IsMatch(Sentencia))
				{
					var SimboloAAsignar = Sentencia.Split('=')[0].Trim();
					var VariableResultante = BuscarVariables(SimboloAAsignar);
					if (VariableResultante == null)
					{
						Console.WriteLine($"La instruccion no se ejecuto por que la variable \"{SimboloAAsignar}\" no existe en ningun ambito.");
						return true;
					}
					else
					{// ComprobarTipos
						var Operacion = Sentencia.Split('=')[1].Trim();
						var TipoGeneralDeLaOperacion = ComprobarTiposParaAsignacion(VariableResultante, Operacion);

						if (VariableResultante.tipo == TipoGeneralDeLaOperacion.Key)
						{
							//operar
							RegistroDeAmbitos[VariableResultante.Ambito].Variables[VariableResultante.Nombre].val = TipoGeneralDeLaOperacion.Value;
						}
						else
						{
							//tipos diferentes
							Console.WriteLine($"La instruccion no se ejecuto por que la variable \"{VariableResultante.Nombre}\" es tipo {VariableResultante.tipo} y no hay convercion hacia tipo {TipoGeneralDeLaOperacion.Key} para {TipoGeneralDeLaOperacion.Value}.");
						}
					}
				}
				else if (RgxStmts.IsMatch(Sentencia))
				{
					var StmtTipo = Sentencia.Substring(0,Sentencia.IndexOf("(")).Trim();
					var parametros = Sentencia.Remove(0,Sentencia.IndexOf("(")).Trim();

					var resultado =VerificarParametrosDeSTMT(parametros);
					if (resultado.Key != null)
					{

					}
					else
					{

					}
				}

				return false;

			}

		}

		KeyValuePair<string, string> VerificarParametrosDeSTMT(string Parametros_)
		{
			var splited = Parametros_.Split(' ');
			var stack = new Stack<KeyValuePair<string, string>>();
			var operacion = "";
			for (int i = 0; i < splited.Length; i++)
			{
				if (splited[i] == ";")
				{
					break;
				}
				else
				{
					if (splited[i].Contains('▄'))
					{
						var cadena = Cadenas[splited[i].Trim()];
						stack.Push(new KeyValuePair<string, string>("string", cadena)); operacion += $" {cadena}";
						operacion = operacion.Trim(); ;
					}
					else if (Number.IsMatch(splited[i]))
					{
						stack.Push(new KeyValuePair<string, string>("int", splited[i])); operacion += $" {splited[i]}";
						operacion = operacion.Trim(); ;

					}
					else if (Boolean.IsMatch(splited[i]))
					{
						stack.Push(new KeyValuePair<string, string>("boolean", splited[i]));
						operacion += $" {splited[i]}";
						operacion = operacion.Trim(); ;

					}
					else if (Identifier.IsMatch(splited[i]))
					{
						var Referencia = BuscarVariables(splited[i]);
						if (Referencia== null)
						{
							Referencia= BuscarEnParametros(splited[i]);
						}
						switch (Referencia.tipo)
						{
							case "string":
								stack.Push(new KeyValuePair<string, string>("string", Referencia.val == null ? "\"\"" : Referencia.val));
								break;
							case "boolean":
								stack.Push(new KeyValuePair<string, string>("boolean", Referencia.val == null ? "false" : Referencia.val));
								break;
							case "int":
								stack.Push(new KeyValuePair<string, string>("int", Referencia.val == null ? "0" : Referencia.val));

								break;
							default:
								break;
						}
						operacion += $" {Referencia.val}";
						operacion = operacion.Trim();

					}
					else
					{
						//operacion += $" {splited[i]}";
						//operacion = operacion.Trim(); ;
					}
				}
			}
			var tipoGeneral = stack.Peek().Key;
			var resultado = new KeyValuePair<string, string>();
			foreach (var item in stack)
			{
				if (item.Key != tipoGeneral)
				{
					return new KeyValuePair<string, string>(item.Key, item.Value);
				}
			}
			
			return new KeyValuePair<string, string>(null, null);
		}
		KeyValuePair<string, string> ComprobarTiposParaAsignacion(Variables AAsginar, string sentencia)
		{
			var splited = sentencia.Split(' ');
			var stack = new Stack<KeyValuePair<string, string>>();
			var operacion = "";
			for (int i = 0; i < splited.Length; i++)
			{
				if (splited[i] == ";")
				{
					break;
				}
				else
				{
					if (splited[i].Contains('▄'))
					{
						var cadena = Cadenas[splited[i].Trim()];
						stack.Push(new KeyValuePair<string, string>("string", cadena)); operacion += $" {cadena}";
						operacion = operacion.Trim(); ;
					}
					else if (Number.IsMatch(splited[i]))
					{
						stack.Push(new KeyValuePair<string, string>("int", splited[i])); operacion += $" {splited[i]}";
						operacion = operacion.Trim(); ;

					}
					else if (Boolean.IsMatch(splited[i]))
					{
						stack.Push(new KeyValuePair<string, string>("boolean", splited[i])); 
						operacion += $" {splited[i]}";
						operacion = operacion.Trim(); ;

					}
					else if (Identifier.IsMatch(splited[i]))
					{
						var Referencia = BuscarVariables(splited[i]);
						if (Referencia == null)
						{
							Referencia = BuscarEnParametros(splited[i]);
						}
						switch (Referencia.tipo)
						{
							case "string":
						stack.Push(new KeyValuePair<string, string>("string", Referencia.val==null ? "\"\"": Referencia.val));
								break;
							case "boolean":
						stack.Push(new KeyValuePair<string, string>("boolean", Referencia.val == null ? "false" : Referencia.val));
								break;
							case "int":
						stack.Push(new KeyValuePair<string, string>("int", Referencia.val == null ? "0" : Referencia.val));

								break;
							default:
								break;
						}
						operacion += $" {Referencia.val}";
						operacion = operacion.Trim();

					}
					else
					{
						operacion += $" {splited[i]}";
						operacion = operacion.Trim(); ;
					}
				}
			}
			var tipoGeneral = stack.Peek().Key;
			var resultado = new KeyValuePair<string, string>();
			foreach (var item in stack)
			{
				if (item.Key != tipoGeneral)
				{
					return new KeyValuePair<string, string>(item.Key, item.Value);
				}
			}
			switch (tipoGeneral)
			{
				case "int":
					DataTable dt = new DataTable();
					var limiea=sentencia.Replace(";", "").Trim();
					//int answer = (int)dt.Compute(sentencia.Replace(";","").Replace(" ", "").Trim(), ""); ;
					var sdasd =Eval.Execute<int>(operacion);
					return new KeyValuePair<string, string>("int", sdasd.ToString());
					break;
				case "string":


					return new KeyValuePair<string, string>("string", operacion);

					break;
				case "boolean":
					return new KeyValuePair<string, string>("boolean", operacion);

					break;
				default:
					break;
			}

			return resultado;
		}
		Variables BuscarEnParametros(string VariableABuscar)
		{
			var ambito = "";
			
				var actual =PilaDeAmbitos.Peek();
			var listaDeParametrosdDisponibles =RegistroDeAmbitos[actual].Metodos[RegistroDeAmbitos[actual].Metodos.ElementAt(0).Key].Parametros.ToList();
			for (int i = 0; i < listaDeParametrosdDisponibles.Count; i++)
			{
				if (listaDeParametrosdDisponibles[i].Key == VariableABuscar)
				{
					return listaDeParametrosdDisponibles[i].Value;
				}
			}
			return null;
		}

		Variables BuscarVariables(string VariableABuscar)
		{
			var ambito = "";
			for (int i = 0; i < PilaDeAmbitos.Count; i++)
			{
				var actual = PilaDeAmbitos.ElementAt(i);
				if (RegistroDeAmbitos[actual].Variables.ContainsKey(VariableABuscar))
				{
					if (RegistroDeAmbitos[actual].Variables[VariableABuscar].Accesible)
					{
						return RegistroDeAmbitos[actual].Variables[VariableABuscar]; 
					}
					
				}
			}
			return null;
		}
		void GuardarMetodo(Metodo MetodoAGuardar_)
		{
			if (RegistroDeAmbitos[PilaDeAmbitos.Peek()].Metodos.ContainsKey(MetodoAGuardar_.Nombre))
			{
				Console.WriteLine($"El Metodo ya fue declarada con el nobre \"{MetodoAGuardar_.Nombre}\" en el ambito {MetodoAGuardar_.Ambito}");

			}
			else
			{
				if (PilaDeTipoDeSentencia.Peek() == "Interfaz")
				{//en lugar de cuardarlo en el diccionario principal se guarda en la lista de prototipos

					if (RegistroDeAmbitos[PilaDeAmbitos.Peek()].Metodos.ContainsKey(MetodoAGuardar_.Nombre))
					{
						Console.WriteLine($"Un Prototipo de la Interfaz {RegistroDeAmbitos[PilaDeAmbitos.Peek()].Interfaces[MetodoAGuardar_.Ambito].Nombre} ya fue declarada con el nobre \"{MetodoAGuardar_.Nombre}\" en el ambito {MetodoAGuardar_.Ambito}");

					}
					else
					{//al ambito de la interfaz le agregamos la 0
						RegistroDeAmbitos[PilaDeAmbitos.Peek()].Metodos.Add(MetodoAGuardar_.Nombre, MetodoAGuardar_);

					}
				}
				else
				{
					if (AbrirUnAmbito(MetodoAGuardar_.Nombre))
					{
						RegistroDeAmbitos[PilaDeAmbitos.Peek()].Metodos.Add(MetodoAGuardar_.Nombre, MetodoAGuardar_);
						PilaDeTipoDeSentencia.Push("Metodo");

					}
					else
					{

					}
				}
			}
		}
		//------------------------------------- QUE NO SE TE OLVIDE ------------------------
		
		// hacer la llamada a el ambito mas cercano
		void GuardarClaseEnAmbito(Clase Metodo)
		{
			if (!RegistroDeAmbitos[PilaDeAmbitos.Peek()].Variables.ContainsKey(Metodo.Nombre))
			{
				RegistroDeAmbitos[PilaDeAmbitos.Peek()].Clases.Add(Metodo.Nombre, Metodo);
			}
			else
			{
				Console.WriteLine($"Una variable ya fue declarada con el nobre \"{Metodo.Nombre}\" en el ambito {PilaDeAmbitos.Peek()}");

			}

		}

		void GuardarInterfazEnAmbito(Interfaz Interfaz)
		{
			if (!RegistroDeAmbitos[PilaDeAmbitos.Peek()].Variables.ContainsKey(Interfaz.Nombre))
			{
				RegistroDeAmbitos[PilaDeAmbitos.Peek()].Interfaces.Add(Interfaz.Nombre, Interfaz);
			}
			else
			{
				Console.WriteLine($"Una variable ya fue declarada con el nobre \"{Interfaz.Nombre}\" en el ambito {PilaDeAmbitos.Peek()}");

			}

		}
		void GuardarVariableEnAmbito(Variables variables)
		{
			if (!RegistroDeAmbitos[PilaDeAmbitos.Peek()].Variables.ContainsKey(variables.Nombre))
			{
				RegistroDeAmbitos[PilaDeAmbitos.Peek()].Variables.Add(variables.Nombre,variables);
			}
			else
			{
				Console.WriteLine($"Una variable ya fue declarada con el nobre \"{variables.Nombre}\" en el ambito {PilaDeAmbitos.Peek()}");

			}

		}

		string QuitarTokensDeLaCadena(string originial, string AAquitar)
		{
			var nueva = originial.Remove(0,AAquitar.Length).Trim();
			return nueva;
		}

		bool AbrirUnAmbito(string NombreDelAmbito)
		{
			if (RegistroDeAmbitos.ContainsKey(NombreDelAmbito))
			{
				Console.WriteLine($"El Ambito {NombreDelAmbito} ya se declaró previamente en el Ambito {PilaDeAmbitos.Peek()}");
				return false;
			}
			else
			{
				PilaDeAmbitos.Push(NombreDelAmbito);
				RegistroDeAmbitos.Add(PilaDeAmbitos.Peek(), new Ambito());

				return true;
			}
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
