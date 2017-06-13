using AFPCapital.Movil.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services
{
    public class CertificadosServices : ServiceManager
    {

        public async Task<CertificadoCotizacionResponse> PostAsync(CertificadoCotizacionRequest item)
        {
            var uri = new Uri(UrlCertificados);
            var json = JsonConvert.SerializeObject(item);
            HttpResponseMessage response = await PostGenericAsync(uri, json);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CertificadoCotizacionResponse>(response.Content.ReadAsStringAsync().Result);
                return result;
            }

            return null;
        }
    }
}
