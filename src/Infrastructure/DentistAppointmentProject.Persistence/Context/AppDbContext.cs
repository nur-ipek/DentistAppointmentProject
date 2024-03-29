using DentistAppointmentProject.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid> //Code First yaklaşımıyla üretilecek olan veritabanımızın bir karşılığı olan DbContext sınıfı
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
