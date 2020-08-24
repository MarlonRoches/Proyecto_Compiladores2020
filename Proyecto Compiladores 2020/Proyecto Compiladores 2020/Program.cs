using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Compiladores_2020.Data;
using Newtonsoft.Json;


namespace Proyecto_Compiladores_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linea De Codigo Java");

            
            Data.Data.Instance.Sustituir(Data.TextValidation.Instance.ValidarComentarios(""));

            //{ } [] () {}
            ////id		
            //TOKEN 1 = LETRA.(LETRA|DIGITO)*
            //json5
            ////integer
            //TOKEN 2 = DIGITO.DIGITO* 
            //    15654

            ////string    
            //TOKEN 3 = '"'.LETRA(LETRA|DIGITO)*.'"'
            //    "asdasdasd"
            ////Bool   
            //TOKEN 4=(TRUE|FALSE)
            //true
            //    //double
            //TOKEN 5 = DIGITO.DIGITO*.'.'DIGITO.DIGITO*
            //    5.21651

            ////integer asignado
            //TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' '*.DIGITO.DIGITO *.' '*.';'
            //         int    numero                          =            1565;
            ////string asignado
            //TOKEN 2 = £.' '*.LETRA.(LETRA|DIGITO)*.' '*.= ' ' *.'"'.LETRA(LETRA|DIGITO)*.'"'.' '*.';'
            //         int numero = 1565;

        }
    }
}
