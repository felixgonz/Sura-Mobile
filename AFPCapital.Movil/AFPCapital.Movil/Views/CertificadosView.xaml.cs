using AFPCapital.Movil.Dependency;
using AFPCapital.Movil.Models;
using AFPCapital.Movil.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worklight;
using Newtonsoft.Json.Linq;

namespace AFPCapital.Movil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CertificadosView : ContentPage
    {
        private CertificadosModel model = new CertificadosModel();
        public CertificadosView()
        {
            InitializeComponent();
            BindingContext = model;

            buttonDescargar.Clicked += ButtonDescargar_Clicked;
            pickerMeses.SelectedIndex = 1;
        }

        private async void ButtonDescargar_Clicked(object sender, EventArgs e)
        {
            model.IsBusy = true;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();

			JObject jsonObj = JObject.FromObject(new { Accion = "Certificado", Usuario = App.UserProfile.User });
			cliente.Analytics.Log("Certificado Emitido", jsonObj);
			cliente.Analytics.Send();
            await DescargarCertificado();
            model.IsBusy = false;
        }

        private async Task DescargarCertificado()
        {
			try{
            
				
                string numeroMeses=pickerMeses.Items[pickerMeses.SelectedIndex].Substring(0,2).Trim();
                var result = await new Services.CertificadosServices().PostAsync(new Services.Models.CertificadoCotizacionRequest
                {
                    RutAfiliado = Rut.Limpiar(App.UserProfile.User).PadLeft(15, '0'),
                    TipoConsulta = "1",
                    TipoProducto = "3",
                    NumeroMeses = numeroMeses,
                });

                var path = DependencyService.Get<IFileDependency>().BinaryWrite("AfpCapital_Cotizaciones" + numeroMeses + "Meses_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf", result.Pdf);
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        Device.OpenUri(new Uri(path));
                        break;
                    case Device.iOS:
                        Device.OpenUri(new Uri(path));
                        break;
                    //case Device.WinPhone:
                    //    break;
                    //case Device.Windows:
                    //    break;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Error al procesar la solicitud.", "Ok");
            }

        }
    }
}
