using AutoMapper;
using BabyLibrary.Domain.DTO;
using BabyLibrary.Domain.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using v1Requests = BabyLibrary.Contracts.V1.Requests;
using v1Responses = BabyLibrary.Contracts.V1.Responses;

namespace BabyLibrary.Installers
{
    /// <summary>
    /// Configure mapping between Model and EFCore Domain
    /// </summary>
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookEFCore, Book>(MemberList.Source).ReverseMap();
                cfg.CreateMap<Book, Book>();
                cfg.CreateMap<v1Requests.CreateBookRequest, Book>(MemberList.Source).ReverseMap();
                cfg.CreateMap<v1Requests.UpdateBookRequest, Book>(MemberList.Source).ReverseMap();
                cfg.CreateMap<v1Responses.CreateBookResponse, Book>(MemberList.Source).ReverseMap();
                cfg.CreateMap<v1Responses.GetBookResponse, Book>(MemberList.Source).ReverseMap();
                cfg.CreateMap<v1Responses.UpdateBookResponse, Book>(MemberList.Source).ReverseMap();
            });

            mapperConfig.AssertConfigurationIsValid();

            serviceCollection.AddScoped(x => mapperConfig.CreateMapper());
        }
    }
}
