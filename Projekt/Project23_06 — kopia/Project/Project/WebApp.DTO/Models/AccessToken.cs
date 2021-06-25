using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DTO.Models
{
    class AccessToken
    {
        public long ExpiresIn { get; set; }
        public DateTime CreateOn { get; set; }
        public string Token { get; set; }
    }
}
