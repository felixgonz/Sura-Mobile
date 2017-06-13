using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Utility
{
    public static class Fechas
    {
        public static int Edad(DateTime fechaNacimiento)
        {
            //Obtengo la diferencia en años.
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            //Obtengo la fecha de cumpleaños de este año.
            DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
            //Le resto un año si la fecha actual es anterior 
            //al día de nacimiento.
            if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).CompareTo(nacimientoAhora) < 0)
            {
                edad--;
            }

            return edad;
        }

        public static bool MayorEdad(DateTime fechaNacimiento)
        {
            if (Edad(fechaNacimiento) >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
