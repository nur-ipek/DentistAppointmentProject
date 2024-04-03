using DentistAppointmentProject.Application.Interfaces.Repositories;
using DentistAppointmentProject.Application.Interfaces.Services;
using DentistAppointmentProject.Persistence.Repositories;
using DentistAppointmentProject.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
        }
    }
}
