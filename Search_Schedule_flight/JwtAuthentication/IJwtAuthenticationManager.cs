﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.JwtAuthentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userName, string password);
    }
}
