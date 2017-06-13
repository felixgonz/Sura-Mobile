using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Services
{
    public class ServiceManager:IDisposable
    {
        public static string BaseAddress = " https://api.us.apiconnect.ibmcloud.com/transversal-cl-qa-trans/surapoc";
        public static string UrlCertificados = BaseAddress + "/certificado/certificado";
        public static string UrlRecuperarClave = BaseAddress + "/solicitaclave/solicitaclave";
        public static string UrlLogin = BaseAddress + "/login/login";

        public HttpClient Http { get; private set; }

        public string Token { get; private set; }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public ServiceManager()
        {
            Http = new HttpClient();
            ClientId = "f485351e-08a4-451a-9fd8-3746ef145edb";
            ClientSecret = "cK2fY6kP0dP8wU8xU7fQ2uL4fJ1cY2oT7nL7cN1sE8gN0rP7pD";
            Token = "";

            Http.BaseAddress =new Uri(BaseAddress);
            if (!string.IsNullOrWhiteSpace(Token))
            {
                Http.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}", Token));
            }
            Http.DefaultRequestHeaders.Add("x-ibm-client-id", ClientId);
            Http.DefaultRequestHeaders.Add("x-ibm-client-secret", ClientSecret);

        }

        public void Dispose()
        {
            if (Http != null)
            {
                Http.Dispose();
            }
        }

        public async Task<HttpResponseMessage> PostGenericAsync(Uri uri, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Http.PostAsync(uri, content);
            return response;
        }

        public async Task<HttpResponseMessage> GetGenericAsync(Uri uri)
        {
            HttpResponseMessage response = await Http.GetAsync(uri);
            return response;
        }
    }
}
