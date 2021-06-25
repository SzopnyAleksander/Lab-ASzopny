using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.DTO.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly string userName;
        private readonly HubConnection hubConnection;
        private ObservableCollection<UserChatMessage> Messages { get; } = new ObservableCollection<UserChatMessage>();

        public ChatPage(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            btnSend.Clicked += BtnSend_Clicked;
            btnPhoto.Clicked += BtnPhoto_Clicked;
            lvMessages.ItemsSource = Messages;

            hubConnection = new HubConnectionBuilder().WithUrl("https://webappweb20210624210720.azurewebsites.net/chathub").Build();

            hubConnection.On<UserChatMessage>(Consts.RECEIVE_MESSAGE, ReceiveMessage_Event);
            hubConnection.On<string>(Consts.USER_JOINED, UserJoined_Event);
            hubConnection.StartAsync();

            hubConnection.SendAsync(Consts.REGISTER_USER, userName);

        }
        
        //photo mode
        private async void BtnPhoto_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PhotoPage());
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

            });
            
        }

        private void UserJoined_Event(string obj)
        {
            Messages.Insert(0, new UserChatMessage
            {
                Message = "User joined to the conversation.",
                Username = userName,
                TimeStamp = DateTime.Now
            });
        }

        private void ReceiveMessage_Event(UserChatMessage obj)
        {
            Messages.Insert(0, obj);
        }

        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            var message = txtMassage.Text;

            if (string.IsNullOrWhiteSpace(message))
            {
                await DisplayAlert("Message errors", "The message is required.", "Ok");
                return;
            }

            await hubConnection.SendAsync(Consts.SEND_MESSAGE, new UserChatMessage
            {
                Message = message,
                Username = userName
            });
   
        }
    }
}