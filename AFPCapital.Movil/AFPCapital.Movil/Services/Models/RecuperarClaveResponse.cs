using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class RecuperarClaveResponse
    {
        [JsonProperty(PropertyName = "CodigoEstado")]
        public string CodigoEstado { get; set; }

        [JsonProperty(PropertyName = "DescripcionEstado")]
        public string DescripcionEstado { get; set; }
    }
}
