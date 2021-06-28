using ChatApp.Web.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Request
{
    public class Post
    {
        public static void PostRequest(string Login, string Email, string Password)
        {
            var url = "https://webappweb20210624210720.azurewebsites.net/Api/Users";
            var client = new RestClient(url);
            var request = new RestRequest();

            using (MD5 md5Hash = MD5.Create())
            {
                Password = PasswordHash.GetMd5Hash(md5Hash, Password);

            }

            var body = new User { login = Login, email = Email, password = Password };

            request.AddJsonBody(body);
            client.Post(request);
        }
    }
}