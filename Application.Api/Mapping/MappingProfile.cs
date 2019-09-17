using Application.ViewModel.Task;
using Applicationa.Model;
using AutoMapper;
namespace Application.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   
            CreateMap<UserTask, TaskForListDto>().ForMember(dest=>dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}
