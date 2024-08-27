using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Core.Interfaces;
using Template.Infrastructure.Repositories;

namespace Template.Api.Extensions;

public static class AppServicesExtension
{
    public static void RegisterAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
