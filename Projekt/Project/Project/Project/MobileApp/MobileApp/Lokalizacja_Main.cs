using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    public class Lokalizacja_Main
    {
        public async static Task<string> lokacja()
        {
            //LOCALIZATION
            var location = await Localization.GetMyLocation();
            var encodedLocation = await location.EncodeLocation();
            string loc = encodedLocation.ToString();
            //await DisplayAlert("Lokalizacja",  loc, "ok");
            return loc;
        }
    }
}
