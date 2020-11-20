using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data
{
    class Metodo
    { 
        public string Tipo;
        public string Nombre;
        public Dictionary<string, Variables> Parametros = new Dictionary<string, Variables>();
        public string Ambito;

    }
}
