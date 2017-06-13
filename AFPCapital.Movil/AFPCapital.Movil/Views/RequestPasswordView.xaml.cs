using AFPCapital.Movil.Models;
using AFPCapital.Movil.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Worklight;
using Newtonsoft.Json.Linq;
using AFPCapital.Movil.Dependency;

namespace AFPCapital.Movil.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPasswordView : ContentPage
    {
        private RequestPasswordModel model = new RequestPasswordModel();

        public RequestPasswordView()
        {
            InitializeComponent();
            BindingContext = model;

            buttonSolicitar.Clicked += ButtonSolicitar_Clicked;
        }

        private async void ButtonSolicitar_Clicked(object sender, EventArgs e)
        {
			model.IsBusy = true;
            await SolicitarClave();
            model.IsBusy = false;
        }

        private async Task SolicitarClave()
        {
            try
            {
                entryRut.Text = Rut.Formatear(entryRut.Text);
                if (!Rut.Validar(entryRut.Text) || !(switchSms.IsToggled || switchEmail.IsToggled))
                {
                    await DisplayAlert("Error", "Debe ingresar un rut válido y seleccionar una opción de envío.", "Ok");
                }
                else
                {
                    string tipo = string.Empty;
                    if(switchSms.IsToggled && switchEmail.IsToggled)
                    {
                        tipo = "3";
                    }
                    else if (switchEmail.IsToggled)
                    {
                        tipo = "1";
                    }
                    else if (switchSms.IsToggled)
                    {
                        tipo = "2";
                    }

                    var result = await new Services.RecuperarClaveServices().PostAsync(new Services.Models.RecuperarClaveRequest
                    {
                        RutCliente = Rut.Limpiar(entryRut.Text),
                        CodigoSistema = "AFP",
                        CodLineaNegocio = "SM",
                        TipoEnvio = tipo,
                    });

                    if (result.CodigoEstado == "00")
                    {
						var cliente = DependencyService.Get<IClienteDependency>().getCliente();
						JObject jsonObj = JObject.FromObject(new { Accion = "Solicitar Clave", Usuario = entryRut.Text });
						cliente.Analytics.Log("Solicitando Clave", jsonObj);
						cliente.Analytics.Send();
						await DisplayAlert("Info", "Solicitud enviada satisfactoriamente.", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Rut no registrado o no posee email/sms para el envío.", "Ok");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Error al procesar la solicitud.", "Ok");
            }

        }

    }
    
}
