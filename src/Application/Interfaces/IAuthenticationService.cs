﻿using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        User? ValidateUser(AuthenticationRequest authenticationRequest);

        string Autenticate( User user);
    }
}
