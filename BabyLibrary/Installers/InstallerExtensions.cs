using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BabyLibrary.Installers
{
    /// <summary>
    /// Extensions methods for <see cref="IInstaller"/> assemblies exploration and invokation
    /// </summary>
    public static class InstallerExtensions
    {
        /// <summary>
        /// Explore <see cref="Startup"/> assembly in search of <see cref="IInstaller"/> and invoke them
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installersClasses = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installersClasses.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
