using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services.Models
{
    public class LoginRequest
    {
        [JsonProperty(PropertyName = "sistema")]
        public string Sistema { get; set; }

        [JsonProperty(PropertyName = "rut")]
        public string Rut { get; set; }

        [JsonProperty(PropertyName = "clave")]
        public string Clave { get; set; }
    }
}
 