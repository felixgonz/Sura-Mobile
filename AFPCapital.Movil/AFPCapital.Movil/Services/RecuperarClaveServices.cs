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
    public class RecuperarClaveServices : ServiceManager
    {
        public async Task<RecuperarClaveResponse> PostAsync(RecuperarClaveRequest item)
        {
            var uri = new Uri(UrlRecuperarClave);
            var json = JsonConvert.SerializeObject(item);
            HttpResponseMessage response = await PostGenericAsync(uri, json);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RecuperarClaveResponse>(response.Content.ReadAsStringAsync().Result);
                return result;
            }

            return null;
        }
    }
}
