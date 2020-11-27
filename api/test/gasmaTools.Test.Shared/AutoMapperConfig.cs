using AutoMapper;
using gasmaTools.Application.Mappers;

namespace gasmaTools.Test.Shared
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration((cfg =>
            {
                cfg.AddProfile<GameDomainToViewModelMapper>();
                cfg.AddProfile<GameViewModelToDomainMapper>();                
                cfg.AddProfile<LoginDomainToViewModelMapper>();
                cfg.AddProfile<LoginViewModelToDomainMapper>();                
                cfg.AddProfile<PersonDomainToViewModelMapper>();
                cfg.AddProfile<PersonViewModelToDomainMapper>();
            })).CreateMapper();
        }
    }
}
