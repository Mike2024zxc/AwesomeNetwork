using AutoMapper;
using AwesomeNetwork.Models;
using AwesomeNetwork.Models.Users;
using AwesomeNetwork.ViewModels.Account;

namespace AwesomeNetwork
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
               .ForMember(x => x.DateBirth, opt => opt.MapFrom(c => new DateTime((int)c.Year, (int)c.Month, (int)c.Date)))
               .ForMember(x => x.Email, opt => opt.MapFrom(c => c.EmailReg))
               .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.Login));
            

            CreateMap<LoginViewModel, User>()
               .ForMember(dest => dest.FirstName, opt => opt.Ignore())
               .ForMember(dest => dest.MidleName, opt => opt.Ignore())
               .ForMember(dest => dest.LastName, opt => opt.Ignore())
               .ForMember(dest => dest.DateBirth, opt => opt.Ignore());

            CreateMap<EditViewModel, User>();
            CreateMap<User, EditViewModel>().ForMember(x => x.UserId, opt => opt.MapFrom(c => c.Id));
             


            CreateMap<User, UserWithFriendExt>()
               .ForMember(dest => dest.IsFriendWithCurrent, opt => opt.MapFrom(src => false));
        }

    }
   
}
