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
			var xd = StackDeEntrada.Pop();

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
		#region Estados

		#endregion

	}
}
