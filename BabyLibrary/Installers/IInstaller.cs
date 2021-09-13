using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BabyLibrary.Installers
{
    /// <summary>
    /// Contact to declare an installer
    /// </summary>
    public interface IInstaller
    {
        /// <summary>
        /// Install service
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
