using AFPCapital.Movil.Models;
using AFPCapital.Movil.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AccountView : ContentPage
    {
        StorageManager db = new StorageManager();
        private ObservableCollection<AccountStorage> _account;
		private ObservableCollection<ListActionModel> _actions;

        public AccountView()
        {
            InitializeComponent();
            listViewAccount.ItemsSource = Account;
            listViewActions.ItemsSource = Actions;

            listViewActions.ItemTapped += ListViewActions_ItemTapped;
            listViewAccount.ItemTapped += ListViewAccount_ItemTapped;
        }

        private async void ListViewAccount_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as AccountStorage;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
            if (item != null)
            {
				JObject jsonObj = JObject.FromObject(new { Accion = "Informacion", Usuario = App.UserProfile.User });
				cliente.Analytics.Log("Buscando informacion", jsonObj);
				cliente.Analytics.Send();
				await DisplayAlert("Info", "Método no implementado.", "Ok");

            }
        }

        private async void ListViewActions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ListActionModel;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
            if (item != null)
            {
                if (item.Action == ListActionType.Logout)
                {
					JObject jsonObj = JObject.FromObject(new { Accion = "Logout", Usuario = App.UserProfile.User });
					cliente.Analytics.Log("Realizando Logout", jsonObj);
					cliente.Analytics.Send();
					if (await DisplayAlert("Cerrar Sesión", "Al cerrar la sesión no podrá recibir notificaciones.\n\nDesea continuar y cerrar la sesión?", "Aceptar", "Cancelar"))
                    {
                        db.DeleteCuentaAll();
                        Application.Current.MainPage = new NavigationPage(new LoginView())
                        {
                            BarBackgroundColor = (Color)App.Current.Resources["BackgroundColorDark"],
                            BarTextColor = Color.White
                        };
                    }
                }
                else if (item.Action == ListActionType.EmergencyPhone)
                {
					JObject jsonObj = JObject.FromObject(new { Accion = "TelefonoEmergencia", Usuario = App.UserProfile.User });
					cliente.Analytics.Log("Telefono de Emergencia", jsonObj);
					cliente.Analytics.Send();
					await Navigation.PushAsync(new EmergencyNumbersView());
                }
                else if (item.Action == ListActionType.Subsidiary)
                { 
					JObject jsonObj = JObject.FromObject(new { Accion = "Sucursales", Usuario = App.UserProfile.User });
					cliente.Analytics.Log("Buscando Sucursales", jsonObj);
					cliente.Analytics.Send();
					await Navigation.PushAsync(new SubsidiaryView());
                }
                else
                {
                    
					JObject jsonObj = JObject.FromObject(new { Accion = "Otras", Usuario = App.UserProfile.User });
					cliente.Analytics.Log("Otras Acciones", jsonObj);
					cliente.Analytics.Send();
					await DisplayAlert("Info", "Método no implementado.", "Ok");
                }

            }
        }

        public ObservableCollection<AccountStorage> Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new ObservableCollection<AccountStorage>();
                    _account.Add(App.UserProfile);
                }
                return _account;
            }
        }

        public ObservableCollection<ListActionModel> Actions
        {
            get
            {
                if (_actions == null)
                {
                    _actions = new ObservableCollection<ListActionModel>();
                    _actions.Add(new ListActionModel { Action = ListActionType.Message, Count = 8, Display = "Notificaciones", Image = "chat.png" });
                    _actions.Add(new ListActionModel { Action = ListActionType.EmergencyPhone, Count = 0, Display = "Teléfonos de emergencia", Image = "phone4.png" });
                    _actions.Add(new ListActionModel { Action = ListActionType.Subsidiary, Count = 0, Display = "Sucursales", Image = "home.png" });
                    _actions.Add(new ListActionModel { Action = ListActionType.Info, Count = 0, Display = "Información y ayuda", Image = "info.png" });
                    _actions.Add(new ListActionModel { Action = ListActionType.Logout, Count = 0, Display = "Cerrar sesión", Image = "close.png" });
                }
                return _actions;
            }
        }
    }
}
