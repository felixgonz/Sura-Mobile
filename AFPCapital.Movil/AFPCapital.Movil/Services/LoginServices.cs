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
    public class LoginServices : ServiceManager
    {

        public async Task<LoginResponse> PostAsync(LoginRequest item)
        {
            try
            {
                var uri = new Uri(UrlLogin);
                var json = JsonConvert.SerializeObject(item);
                HttpResponseMessage response = await PostGenericAsync(uri, json);
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
