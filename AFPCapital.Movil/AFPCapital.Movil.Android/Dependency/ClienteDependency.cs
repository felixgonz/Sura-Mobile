using System;
using AFPCapital.Movil.Dependency;
using Worklight;

[assembly: Xamarin.Forms.Dependency(typeof(AFPCapital.Movil.Droid.Dependency.ClienteDependency))]
namespace AFPCapital.Movil.Droid.Dependency
{
	public class ClienteDependency:IClienteDependency
	{
		IWorklightClient IClienteDependency.getCliente()
		{
			return WLHelper.cliente;
		}
	}
}
