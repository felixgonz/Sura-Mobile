using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class CertificadoCotizacionRequest
    {
        [JsonProperty(PropertyName = "rutAfiliado")]
        public string RutAfiliado { get; set; }

        [JsonProperty(PropertyName = "tipoConsulta")]
        public string TipoConsulta { get; set; }

        [JsonProperty(PropertyName = "tipoProducto")]
        public string TipoProducto { get; set; }

        [JsonProperty(PropertyName = "numeroMeses")]
        public string NumeroMeses { get; set; }
    }
}
