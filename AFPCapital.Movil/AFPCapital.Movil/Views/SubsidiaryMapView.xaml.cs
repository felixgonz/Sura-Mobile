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

namespace AFPCapital.Movil.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubsidiaryMapView : ContentPage
    {
        public SubsidiaryModel Subsidiary { get; set; }

        public SubsidiaryMapView(SubsidiaryModel subsidiary)
        {
            InitializeComponent();
            Subsidiary = subsidiary;

            if (Subsidiary != null)
            {
                labelAddress.Text = Subsidiary.Address;
                labelDistanceDisplay.Text = Subsidiary.DistanceDisplay;
                labelName.Text = Subsidiary.Name;


                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) => {
                    try
                    {
                        Telefono.LlamarTelefono(Subsidiary.Phone);
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Este dispositivo no permite realizar llamadas.", "Ok");
                    }
                };
                imagePhone.GestureRecognizers.Add(tapGestureRecognizer);

                try
                {
                    var position = new Xamarin.Forms.Maps.Position(Subsidiary.Latitude, Subsidiary.Longitude); // Latitude, Longitude
                    var pin = new Xamarin.Forms.Maps.Pin
                    {
                        Type = Xamarin.Forms.Maps.PinType.Place,
                        Position = position,
                        Label = Subsidiary.Name,
                        Address = Subsidiary.Address
                    };
                    map.Pins.Add(pin);
                    map.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(position, 0.01, 0.01));
                }
                catch
                {
                    DisplayAlert("Error", "Se necesita acceso a internet para visualizar los mapas.", "Ok");
                }
            }
        }

    }
}

