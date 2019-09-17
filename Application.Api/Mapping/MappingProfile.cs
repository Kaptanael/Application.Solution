using Application.ViewModel.Task;
using Application.ViewModel.Value;
using Application.Model;
using AutoMapper;
namespace Application.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   
            CreateMap<UserTask, TaskForListDto>().ForMember(dest=>dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
            CreateMap<ValueForCreateDto, Value>();
            CreateMap<ValueForUpdateDto, Value>();
            CreateMap<ValueForDeleteDto, Value>();
            CreateMap<ValueForListDto, Value>();
        }
    }
}
