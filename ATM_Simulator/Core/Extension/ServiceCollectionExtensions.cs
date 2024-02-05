using Core.AdminServices;
using Core.CurrentUserServices;
using Core.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminServices, AdminService>();

        collection.AddScoped<IUserServices, UserService>();

        collection.AddScoped<CurrentUser>();

        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUser>());
        return collection;
    }
}