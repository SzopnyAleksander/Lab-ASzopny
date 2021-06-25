using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DTO.Commands
{
    class CreateAccessTokenCommand
    {
        public string username { get; set; }

        public string email { get; set; }
        public string password { get; set; }
    }
}
