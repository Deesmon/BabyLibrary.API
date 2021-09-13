using BabyLibrary.Services;
using BabyLibrary.Tools.DateTimeProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BabyLibrary.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();
            serviceCollection.AddScoped<IBookService, BookService>();
            serviceCollection.AddScoped<IBookLoanService, BookLoanService>();
            serviceCollection.AddScoped<IBookReservationService, BookReservationService>();
        }
    }
}
