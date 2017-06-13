using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Utility
{
    public static class Rut
    {
        public static bool Validar(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = Convert.ToChar(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public static string Limpiar(string rut)
        {
            rut = rut.Replace(" ", "");
            rut = rut.Replace(".", "");
            rut = rut.Replace(",", "");
            rut = rut.Replace("-", "");

            return rut;
        }

        public static string Formatear(string rut)
        {
            int cont = 0;
            string format;
            if (string.IsNullOrWhiteSpace(rut))
            {
                return "";
            }
            else
            {
                rut = rut.Replace(" ", "");
                rut = rut.Replace(".", "");
                rut = rut.Replace(",", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }
    }
}
