using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class CertificadoCotizacionResponse
    {
        [JsonProperty(PropertyName = "GenerarCertificadoCotizacionResult")]
        public string Pdf { get; set; }
    }
}
