using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data.Simbolos
{
    class Ambito
    {
        string NombreDeAmbito;
        public bool Accesible = false;
        public Dictionary<string, Variables> Variables = new Dictionary<string, Variables>();
        public Dictionary<string, Metodo> Metodos = new Dictionary<string, Metodo>();
        public Dictionary<string, Interfaz> Interfaces = new Dictionary<string, Interfaz>();
        public Dictionary<string, Clase> Clases = new Dictionary<string, Clase>();
        
    }
}
