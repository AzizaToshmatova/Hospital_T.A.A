using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBaseService<Patient>, PatientService>();
        services.AddScoped<IBaseService<Admin>, AdminService>();        
        services.AddScoped<IBaseService<Payment>, PaymentService>();
        services.AddScoped<IBaseService<Doctor>, DoctorService>();
        services.AddScoped<IBaseService<Registration>, RegistrationService>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}