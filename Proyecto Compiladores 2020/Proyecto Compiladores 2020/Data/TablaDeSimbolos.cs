using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public void GenerarTabla(List<KeyValuePair<string, string>> tokensAceptados)
		 {
			var viaTokens = "";
			var viaEntrad = "";
			foreach (var item in tokensAceptados)
			{
				viaTokens += $" {item.Key}";
				viaEntrad += $" {item.Value}";

				viaTokens = viaTokens .Trim();
				viaEntrad = viaEntrad.Trim();
			}
			//variable simples
			//staticas
			//scoopear por {}
			var xd=0;
		}

	}
}
