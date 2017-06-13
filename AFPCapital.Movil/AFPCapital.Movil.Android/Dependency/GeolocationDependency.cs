using System;
using System.Threading.Tasks;
using AFPCapital.Movil.Dependency;
using AFPCapital.Movil.Models;
using Plugin.Geolocator;

[assembly: Xamarin.Forms.Dependency(typeof(AFPCapital.Movil.Droid.Dependency.GeolocationDependency))]
namespace AFPCapital.Movil.Droid.Dependency
{
    public class GeolocationDependency : IGeolocationDependecy
    {
        public GeolocationDependency()
        {
        }

        public async Task<LocationModel> GetLocationAsync()
        {
            LocationModel geo = null;
            try
            {
                geo = new LocationModel();
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                geo.Timestamp = position.Timestamp;
                geo.Latitude = position.Latitude;
                geo.Longitude = position.Longitude;
                geo.Accuracy = position.Accuracy;
                geo.Altitude = position.Altitude;
                geo.AltitudeAccuracy = position.AltitudeAccuracy;
                geo.Heading = position.Heading;
                geo.Speed = position.Speed;
            }
            catch
            {
                geo = null;
            }

            return geo;
        }
    }
}

