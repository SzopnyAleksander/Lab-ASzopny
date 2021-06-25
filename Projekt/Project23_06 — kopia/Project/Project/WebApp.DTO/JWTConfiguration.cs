﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DTO
{
    class JWTConfiguration
    {
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int TokenExpirationTime { get; set; }

    }
}
