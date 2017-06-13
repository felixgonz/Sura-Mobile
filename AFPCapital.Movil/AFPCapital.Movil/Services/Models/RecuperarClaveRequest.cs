using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class RecuperarClaveRequest
    {
        [JsonProperty(PropertyName = "RutCliente")]
        public string RutCliente { get; set; }

        [JsonProperty(PropertyName = "TipoEnvio")]
        public string TipoEnvio { get; set; }

        [JsonProperty(PropertyName = "CodLineaNegocio")]
        public string CodLineaNegocio { get; set; }

        [JsonProperty(PropertyName = "CodigoSistema")]
        public string CodigoSistema { get; set; }
    }
}
