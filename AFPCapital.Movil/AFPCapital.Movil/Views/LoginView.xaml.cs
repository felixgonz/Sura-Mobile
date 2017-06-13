using AFPCapital.Movil.Dependency;
using AFPCapital.Movil.Models;
using AFPCapital.Movil.Storage;
using AFPCapital.Movil.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    public partial class LoginView : ContentPage
    {
        private LoginModel model = new LoginModel();

        public LoginView()
        {
            InitializeComponent();
            BindingContext = model;

            buttonLogin.Clicked += ButtonLogin_Clicked;

            buttonBorderOlvidoClave.Clicked += ButtonBorderOlvidoClave_Clicked;
            buttonBorderSucursales.Clicked += ButtonBorderSucursales_Clicked;
            buttonBorderTelefonos.Clicked += ButtonBorderTelefonos_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            model.IsBusy = true;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
            if (await ObtenerLoginAsync(entryUser.Text, entryPassword.Text))
            {
                model.DataBase.SaveCuenta(App.UserProfile);
                App.Perfilar(App.UserProfile);
				JObject jsonObj = JObject.FromObject(new { Accion = "Login", Usuario = App.UserProfile.User });
				cliente.Analytics.Log("Realizando Login", jsonObj);
				cliente.Analytics.Send();
            }
            else
            {
                entryPassword.Text = "";
            }
            model.IsBusy = false;
        }

        async Task<bool> ObtenerLoginAsync(string usuario, string clave)
        {
            try
            {
				var cliente = DependencyService.Get<IClienteDependency>().getCliente();
				if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(clave))
                {
                    using (var api = new Services.LoginServices())
                    {
                        var request = new Services.Models.LoginRequest { Rut = Rut.Limpiar(usuario), Sistema = "AFP", Clave = clave };
                        var result = await api.PostAsync(request);

                        if (result.ValidarCliente.Estado == "00" || result.ValidarCliente.Estado == "10")
                        {
                            App.UserProfile = new AccountStorage()
                            {
                                FirstName = "Juan",
                                LastName = "Pérez",
                                User = Rut.Limpiar(usuario),
                                Password = clave,
                                Email = "mi_correo@mi_empresa.cl",
                                PhoneNumber = "+56 9 9999 9999",
                                IsActive = true,
                            };
							JObject jsonObj = JObject.FromObject(new { Accion = "Nuevo Login", Usuario = App.UserProfile.User });
							cliente.Analytics.Log("Realizando Nuevo Login", jsonObj);
							cliente.Analytics.Send();
                            return true;
                        }
                        else
                        {
                            var mensaje = "Usuario o clave no corresponde.";//result.ValidarCliente.Mensaje;

                            await DisplayAlert("Error", mensaje, "Ok");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Debe ingresar usuario y clave.", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Error al iniciar sesión.", "Ok");
            }

            return false;
        }

        private async void ButtonBorderTelefonos_Clicked(object sender, EventArgs e)
        {
            model.IsBusy = true;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
			JObject jsonObj = JObject.FromObject(new { Accion = "Telefonos Login"});
			cliente.Analytics.Log("Pidiendo Telefonos", jsonObj);
			cliente.Analytics.Send();
            await Navigation.PushAsync(new EmergencyNumbersView());
            model.IsBusy = false;
        }

        private async void ButtonBorderSucursales_Clicked(object sender, EventArgs e)
        {
            model.IsBusy = true;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
			JObject jsonObj = JObject.FromObject(new { Accion = "Sucursales Login"});
			cliente.Analytics.Log("Pidiendo Sucursales", jsonObj);
			cliente.Analytics.Send();
            await Navigation.PushAsync(new SubsidiaryView());
            model.IsBusy = false;
        }

        private async void ButtonBorderOlvidoClave_Clicked(object sender, EventArgs e)
        {
            model.IsBusy = true;
			var cliente = DependencyService.Get<IClienteDependency>().getCliente();
			JObject jsonObj = JObject.FromObject(new { Accion = "Olvido Clave"});
			cliente.Analytics.Log("Buscando Clave", jsonObj);
			cliente.Analytics.Send();
            await Navigation.PushAsync(new RequestPasswordView());
            model.IsBusy = false;
        }

    }
    
}
