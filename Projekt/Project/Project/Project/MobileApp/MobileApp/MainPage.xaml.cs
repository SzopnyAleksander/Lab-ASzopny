using MobileApp.GetEndPoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

            InitializeComponent();

            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegisterPage.Clicked += BtnRegisterPage_Clicked;
        }

        

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var userName = txtLogin.Text;
            var password = txtPassword.Text;
            dynamic x = await Get.GetRequest();

            //LOCALIZATION
            var location = await Localization.GetMyLocation();
            var encodedLocation = await location.EncodeLocation();
            string loc = encodedLocation.ToString();
            //await DisplayAlert("Lokalizacja",  loc, "ok");

            if (string.IsNullOrWhiteSpace(userName))
            {
                await DisplayAlert("Validation errors", "The user name is required.", "Ok");
                return;
            }

            else if (string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Validation errors", "The password is required.", "Ok");
                return;
            }

            int a = 0;
            using (MD5 md5Hash = MD5.Create())
            {
                password = PasswordHash.GetMd5Hash(md5Hash, password);

            }
            foreach (var i in x)
            {
                if (i.login == userName && i.password == password)
                {
                    a = 1;
                    await Navigation.PushAsync(new ChatPage(userName));
                }
            }
            if (a != 1) {
                await DisplayAlert("Validation errors", "Wrong login or password!", "Ok");
            }
            //await Navigation.PushAsync(new ChatPage(password));
            //await Navigation.PushAsync(new ChatPage(userName));

            
        }

        private async void BtnRegisterPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
