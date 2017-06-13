using AFPCapital.Movil.Dependency;
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
using Newtonsoft.Json.Linq;
using Worklight;

namespace AFPCapital.Movil.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubsidiaryView : ContentPage
    {
        private List<SubsidiaryModel> Subsidiaries { get; set; }

        public SubsidiaryView()
        {
            InitializeComponent();
             
            Subsidiaries = new List<SubsidiaryModel> {
                new SubsidiaryModel(){Order=0, Name="Sucursal Miraflores",Address="Miraflores 199, Santiago",Latitude=-33.440279, Longitude=-70.645254, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=1, Name="Sucursal Las Condes",Address="San Sebastián 2787, Las Condes",Latitude=-33.415937, Longitude=-70.601842, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=1, Name="Sucursal Las Condes",Address="Av. Apoquindo 4820, Las Condes",Latitude=-33.411830, Longitude=-70.579308, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=2, Name="Sucursal Ñuñoa",Address="Irarrázaval 4568, Ñuñoa",Latitude=-33.454712, Longitude=-70.582166, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=3, Name="Sucursal Maipú",Address="Monumento 2088, Maipú, ",Latitude=-33.508128, Longitude=-70.758961, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=4, Name="Sucursal Providencia",Address="Las Bellotas 273, Providencia",Latitude=-33.422680, Longitude=-70.607048, Phone="+56 9 9999 9999"},
                new SubsidiaryModel(){Order=5, Name="Sucursal San Bernardo",Address="Bulnes 493, San Bernardo",Latitude=-33.593522, Longitude=-70.701289, Phone="+56 9 9999 9999"},
            };
            listviewSubsidiary.ItemTapped += listviewSubsidiary_ItemTapped;
            listviewSubsidiary.ItemsSource = Subsidiaries;
            UpdateDistancesAsync();
        }

        private async void UpdateDistancesAsync()
        {
            try
            {
                var geo = await DependencyService.Get<IGeolocationDependecy>().GetLocationAsync();
                if (geo != null)
                {
                    foreach (var item in Subsidiaries)
                    {
                        var distance = new Distances(geo.Latitude, geo.Longitude, item.Latitude, item.Longitude);
                        item.Distance = distance.Distance;
                        item.DistanceDisplay = distance.DistanceDisplay;
                    }
                    listviewSubsidiary.ItemsSource = Subsidiaries.OrderBy(x => x.Distance);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No fue posible obtener la posición actual, asegurese de que el GPS se encuentra activo.", "Ok");
            }

            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
        }

        private async void listviewSubsidiary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SubsidiaryModel;
            if (item != null)
            {
                
				var cliente = DependencyService.Get<IClienteDependency>().getCliente();
				JObject jsonObj = JObject.FromObject(new { Accion = "Visualizar Sucursales", Usuario = App.UserProfile.User });
				cliente.Analytics.Log("Visualizando Sucursales", jsonObj);
				cliente.Analytics.Send();
				await Navigation.PushAsync(new SubsidiaryMapView(item));
            }
        }
    }
}

