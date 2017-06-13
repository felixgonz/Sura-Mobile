using System;
using Worklight;
namespace AFPCapital.Movil.Droid
{
	public class WLHelper
	{

		//public LoginChallengeHandler _challengeHandler { get; private set; }
		public IWorklightClient _client { get; private set; }

		public static IWorklightClient cliente { get; private set; }

		public WLHelper(IWorklightClient client)
		{
            this._client = client;
			//this._client.Logger("AFP Capital").UpdateConfigFromServer();
			this._client.Analytics.Enable();
			//JObject jsonObj = JObject.FromObject(new { hello = "there", world = "citizen" });
			//this._client.Analytics.Log("Message", jsonObj);
			//this._client.Analytics.Log("SantanderMessage", jsonObj);
			this._client.Analytics.Send();

			ObtainToken();

			cliente = this._client;

			//this._challengeHandler = new LoginChallengeHandler("SantanderLoginSecurityCheck");
			//this._client.RegisterChallengeHandler(this._challengeHandler);
		}

		public async void ObtainToken()
{
	try
	{

				// IWorklightClient _newClient = Cliente.WorklightClient;
		WorklightAccessToken accessToken = await this._client.AuthorizationManager.ObtainAccessToken("");

		//if (accessToken.Value != null && accessToken.Value != "")
		//{
		//	System.Diagnostics.Debug.WriteLine("Received the following access token value: " + accessToken.Value);
		//	StringBuilder uriBuilder = new StringBuilder().Append("/adapters/javaAdapter/resource/greet");

		//	WorklightResourceRequest request = _newClient.ResourceRequest(new Uri(uriBuilder.ToString(), UriKind.Relative), "GET");
		//	request.SetQueryParameter("name", "world");
		//	WorklightResponse response = await request.Send();

		//	System.Diagnostics.Debug.WriteLine("Success: " + response.ResponseText);
		//}
	}
	catch (Exception e)
	{
		System.Diagnostics.Debug.WriteLine("An error occurred: '{0}'", e);
	}
}
	}
}
