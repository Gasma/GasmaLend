using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Entities;

namespace gasmaTools.Application.Mappers
{
    public class LoginDomainToViewModelMapper : Profile
    {
        public LoginDomainToViewModelMapper()
        {
            CreateMap<AppUser, LoginViewModel>();
        }
    }
}
