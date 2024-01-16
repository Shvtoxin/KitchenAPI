using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Kitchen.API.Enums;
using Kitchen.API.Models.CreateRequest;
using Kitchen.API.Models.Reqsponse;
using Kitchen.API.Models.Request;
using Kitchen.Services.Contracts.Enums;
using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;

namespace Kitchen.API.Mappers
{
    public class APIMapper : Profile
    {
        public APIMapper()
        {
            CreateMap<TypeOfKitchenModel, TypeOfKitchenRequest>().ConvertUsingEnumMapping(opt => opt.MapByName()).ReverseMap();

            CreateMap<CreateCuisineRequestModel, CuisineModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CreatePostRequestModel, PostModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CreateStimulationRequestModel, StimulationModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CreateTypeOfTurnoutRequestModel, TypeOfTurnoutModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CreateStaffRequestModel, StaffRequestModel>(MemberList.Destination)
               .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CreateTurnOutRequestModel, TurnOurRequestModel>(MemberList.Destination)
               .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CuisineRequest, CuisineModel>(MemberList.Destination).ReverseMap();
            CreateMap<PostRequest, PostModel>(MemberList.Destination).ReverseMap();
            CreateMap<StimulationRequest, StimulationModel>(MemberList.Destination).ReverseMap();
            CreateMap<TypeOfTurnoutRequest, TypeOfTurnoutModel>(MemberList.Destination).ReverseMap();
            CreateMap<StaffRequest, StaffRequestModel>(MemberList.Destination).ReverseMap();
            CreateMap<StaffRequest, StaffModel>(MemberList.Destination)
                .ForMember(x => x.Post, opt => opt.Ignore()).ReverseMap();


            CreateMap<TurnOutRequest, TurnOurRequestModel>(MemberList.Destination).ReverseMap();
            CreateMap<TurnOutRequest, TurnOutModel>(MemberList.Destination)
                .ForMember(x => x.Cuisine, opt => opt.Ignore())
                .ForMember(x => x.Stimulation, opt => opt.Ignore())
                .ForMember(x => x.TypeOfTurnout, opt => opt.Ignore())
                .ForMember(x => x.Staff, opt => opt.Ignore()).ReverseMap();

            CreateMap<CuisineModel, CuisineResponse>(MemberList.Destination);
            CreateMap<PostModel, PostResponse>(MemberList.Destination);
            CreateMap<StimulationModel, StimulationResponse>(MemberList.Destination);
            CreateMap<TypeOfTurnoutModel, TypeOfTurnoutResponse>(MemberList.Destination);
            CreateMap<TurnOutModel, TurnOutResponse>(MemberList.Destination);
            CreateMap<StaffModel, StaffResponse>(MemberList.Destination)
                .ForMember(x => x.Name, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.Patronymic}"));
        }
    }
}
