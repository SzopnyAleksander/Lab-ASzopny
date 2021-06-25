using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.GetEndPoint
{
   
    public class Get
    {
        public static async Task<dynamic> GetRequest()
        {
            var url = "https://webappweb20210624210720.azurewebsites.net/Api/Users";
            var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            dynamic json = JsonConvert.DeserializeObject(result);
            return json;
        }
    }

}
