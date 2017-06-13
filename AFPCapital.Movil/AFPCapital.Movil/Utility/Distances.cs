using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Utility
{
    public class Distances
    {
        private const double EARTH_RADIUS_KM = 6371;
        private double Latitude1 { get; set; }
        private double Longitude1 { get; set; }
        private double Latitude2 { get; set; }
        private double Longitude2 { get; set; }
        public double Distance { get; private set; }
        public string DistanceDisplay { get; private set; }

        public Distances(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            Latitude1 = latitude1;
            Latitude2 = latitude2;
            Longitude1 = longitude1;
            Longitude2 = longitude2;
            Distance = GetDistanceKM();
            DistanceDisplay = GetDistanceKMDisplay();
        }

        private double GetDistanceKM()
        {
            double lat = ToRad(Latitude2 - Latitude1);
            double lon = ToRad(Longitude2 - Longitude1);

            double a = Math.Pow(Math.Sin(lat / 2), 2) +
                Math.Cos(ToRad(Latitude1)) * Math.Cos(ToRad(Latitude2)) *
                Math.Pow(Math.Sin(lon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EARTH_RADIUS_KM * c;
            return distance;
        }

        private double ToRad(double input)
        {
            return input * (Math.PI / 180);
        }

        private string GetDistanceKMDisplay()
        {
            if (Distance < 1)
            {
                return string.Format("Está a {0:N2} mts. de tí", Distance * 1000);
            }
            return string.Format("Está a {0:N2} kms. de tí", Distance);
        }
    }
}

