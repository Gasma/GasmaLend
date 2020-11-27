using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Login;

namespace gasmaTools.Application.Mappers
{
    public class LoginViewModelToDomainMapper : Profile
    {
        public LoginViewModelToDomainMapper()
        {
            CreateMap<LoginViewModel, InsertLoginCommand>()
                .ConvertUsing(viewModel => new InsertLoginCommand(viewModel.Email, viewModel.Password, viewModel.FullName, viewModel.UserName));            
            
            CreateMap<LoginViewModel, SignInLoginCommand>()
                .ConvertUsing(viewModel => new SignInLoginCommand(viewModel.Email, viewModel.Password));
        }
    }
}
