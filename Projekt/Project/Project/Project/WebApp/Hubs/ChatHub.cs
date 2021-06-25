using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.DTO.Models;

namespace WebApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(UserChatMessage message)
        {
            message.TimeStamp = System.DateTime.Now;
            await Clients.All.SendAsync(Consts.RECEIVE_MESSAGE, message);
        }

        public async Task RegisterUser(string userName)
        {
            await Clients.All.SendAsync(Consts.USER_JOINED, userName);
        }
    }
}
