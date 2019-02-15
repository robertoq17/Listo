using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Listo.Services
{
    public class GeoLocatorService
    {
        #region Properties
        public double Latitud { get; set; }

        public double Longitud { get; set; }
        #endregion

        #region Constructor

        #endregion

        #region Methods
        public async Task GetLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var location = await locator.GetPositionAsync();
                Latitud = location.Latitude;
                Longitud = location.Longitude;
            }
            catch (Exception e)
            {

                e.ToString();
            }
        }
        #endregion
    }
}
