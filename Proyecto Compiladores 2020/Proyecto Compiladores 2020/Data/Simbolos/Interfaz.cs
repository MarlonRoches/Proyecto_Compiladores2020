using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data.Simbolos
{
    class Interfaz
    {
        public string Nombre;
        public string Ambito;
        public Dictionary<string, Metodo> Metodos = new Dictionary<string, Metodo>();

    }
}
