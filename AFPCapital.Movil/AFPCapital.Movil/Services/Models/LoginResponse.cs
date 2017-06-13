using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "validarClienteResult")]
        public ValidarCliente ValidarCliente { get; set; }
    }

    public class ValidarCliente
    {
        [JsonProperty(PropertyName = "Estado")]
        public string Estado { get; set; }

        [JsonProperty(PropertyName = "Mensaje")]
        public string Mensaje { get; set; }
    }
}
