﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Domain.Entities.Authentication
{
    public class User: IdentityUser<Guid>
    {
    }
}
