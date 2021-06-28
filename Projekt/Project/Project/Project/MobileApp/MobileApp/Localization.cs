using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileApp
{
    public static class Localization
    {
        public static async Task<string> EncodeLocation(this Location location)
        {
            //var lat = location.Latitude;
            //var lon = location.Longitude;
            var lat = 52.4158112;
            var lon = 16.9293361;
          

            var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                var geocodeAddress =$" {placemark.SubAdminArea}";



                return geocodeAddress;
            }
            return null;
        }
    

        public static async Task<Location> GetMyLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }
    }
}
