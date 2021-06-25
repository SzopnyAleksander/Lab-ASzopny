using Microsoft.CSharp;
using MobileApp.GetEndPoint;
using MobileApp.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            btnSignUp.Clicked += BtnSignUp_Clicked;
            btnLoginPage.Clicked += BtnLoginPage_Clicked;

        }

        

        public async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var userName = txtLogin.Text;
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            var passwordConfirm = txtPasswordConfirm.Text;
            dynamic x = await Get.GetRequest();

            if (string.IsNullOrWhiteSpace(userName))
            {
                await DisplayAlert("Validation errors", "The user name is required.", "Ok");
                return;
            }

            else if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Validation errors", "The email is required.", "Ok");
                return;
            }


            else if (string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Validation errors", "The password is required.", "Ok");
                return;
            }

            else if (string.IsNullOrWhiteSpace(passwordConfirm))
            {
                await DisplayAlert("Validation errors", "Confirm your password.", "Ok");
                return;
            }

            foreach (var i in x)
            {
                if (i.login == userName)
                {
                    await DisplayAlert("Validation errors", "Login already taken!", "Ok");
                    return;
                }
                if (i.email == email)
                {
                    await DisplayAlert("Validation errors", "Email already used!", "Ok");
                    return;
                }
            }

            if (password != passwordConfirm)
            {
                await DisplayAlert("Validation errors", "Passwords are not the same!", "Ok");
                return;
            }

            //USER POST

            Post.PostRequest(userName, email, password); 

            //var httpClient = HttpClienFactory.Create();
            //var url = "https://webappweb20210624210720.azurewebsites.net/Api/Users";
            //var data = await httpClient.GetStringAsync(url);
            //JArray jArray = JsonConvert.DeserializeObject<JArray>(GetUser());

            await Navigation.PushAsync(new ChatPage(userName));
            //await Navigation.PushAsync(new ChatPage(email));
            //await Navigation.PushAsync(new ChatPage(password));
            //await Navigation.PushAsync(new ChatPage(passwordConfirm));

        }

        private async void BtnLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}