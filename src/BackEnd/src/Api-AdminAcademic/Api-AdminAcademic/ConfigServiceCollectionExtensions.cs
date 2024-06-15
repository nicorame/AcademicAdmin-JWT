using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Repository;
using Api_AdminAcademic.Service.Roles;
using Api_AdminAcademic.Service.Usuarios;

namespace Api_AdminAcademic;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddMyDependecyGroup(this IServiceCollection services)
    {
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        services.AddScoped<IUsuariosService, UsuariosService>();
        
        return services;
    }
}