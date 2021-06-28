using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DTO.Models
{
    public class UserChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }

        public string Location { get; set; }

        //public string LocationString => Location.ToString(location.EncodeLocation());

        public DateTime TimeStamp { get; set; }
        public string TimeStampString => TimeStamp.ToString("dd-MM-yyy, hh:mm:ss");

        public Task<string> Local { get; set; }
    }
}
