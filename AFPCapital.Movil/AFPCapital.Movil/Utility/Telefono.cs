using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AFPCapital.Movil.Utility
{
    public static class Telefono
    {
        public static void LlamarTelefono(string telefono)
        {
            Device.OpenUri(new Uri(string.Format("tel:{0}", telefono)));
        }
    }
}
