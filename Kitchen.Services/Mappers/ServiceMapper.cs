using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Kitchen.Context.Contracts.Enums;
using Kitchen.Context.Contracts.Models;
using Kitchen.Services.Contracts.Enums;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;

namespace Kitchen.Services.Mappers
{
    /// <summary>
    /// Маппер
    /// </summary>
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<TypeOfKitchen, TypeOfKitchenModel>().ConvertUsingEnumMapping(opt => opt.MapByName()).ReverseMap();

            CreateMap<Cuisine, CuisineModel>(MemberList.Destination).ReverseMap();
            CreateMap<Post, PostModel>(MemberList.Destination).ReverseMap();
            CreateMap<Stimulation, StimulationModel>(MemberList.Destination).ReverseMap();
            CreateMap<TypeOfTurnout, TypeOfTurnoutModel>(MemberList.Destination).ReverseMap();
            CreateMap<Staff, StaffModel>(MemberList.Destination)
                .ForMember(x => x.Post, opt => opt.Ignore()).ReverseMap();

            CreateMap<TurnOut, TurnOutModel>(MemberList.Destination)
                .ForMember(x => x.Cuisine, opt => opt.Ignore())
                .ForMember(x => x.Stimulation, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.Ignore())
                .ForMember(x => x.Staff, opt => opt.Ignore()).ReverseMap();

            CreateMap<TurnOurRequestModel, TurnOut>(MemberList.Destination)
                .ForMember(x => x.Cuisine, opt => opt.Ignore())
                .ForMember(x => x.Stimulation, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.Ignore())
                .ForMember(x => x.Staff, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.DeletedAt, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore());

            CreateMap<StaffRequestModel, Staff>(MemberList.Destination)
               .ForMember(x => x.Post, opt => opt.Ignore())
               .ForMember(x => x.CreatedAt, opt => opt.Ignore())
               .ForMember(x => x.DeletedAt, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.UpdatedAt, opt => opt.Ignore())
               .ForMember(x => x.UpdatedBy, opt => opt.Ignore());
        }
    }
}
