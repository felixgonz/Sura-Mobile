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

using AFPCapital.Movil.Dependency;
using Newtonsoft.Json.Linq;

namespace AFPCapital.Movil.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmergencyNumbersView : ContentPage
    {
        public EmergencyNumbersView()
        {
            InitializeComponent();

            listviewPhoneNumbers.ItemsSource = (new List<EmergencyNumbersModel>() {
                new EmergencyNumbersModel {Order=1,Description="Central",PhoneNumber ="600 6600 900" },
                new EmergencyNumbersModel {Order=2,Description="Emergencias",PhoneNumber ="2 2915 4150" },
                new EmergencyNumbersModel {Order=3,Description="Ayuda",PhoneNumber ="2 2299 3650" },
            }).OrderBy(x => x.Order);
            listviewPhoneNumbers.ItemTapped += ListviewPhoneNumbers_ItemTapped;
        }

        private async void ListviewPhoneNumbers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as EmergencyNumbersModel;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
            if (item != null)
            {
                try
                {
                    Telefono.LlamarTelefono(item.PhoneNumber);
				JObject jsonObj = JObject.FromObject(new { Accion = "Llamar Emergencia", Usuario = App.UserProfile.User });
				cliente.Analytics.Log("Llamando Numero Emergencia", jsonObj);
				cliente.Analytics.Send();
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Este dispositivo no permite realizar llamadas.", "Ok");
                }
            }
        }
    }
}
