using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace SFPrj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<ImageForCreationDto, Image>();
            CreateMap<ImageForUpdateDto, Image>();

            CreateMap<Chassi, ChassiDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<DescriptionGPResult, DescriptionGPResultDto>();
            CreateMap<DNQ, DNQDto>();
            CreateMap<Engine, EngineDto>();
            CreateMap<Fail, FailDto>();
            CreateMap<FastLap, FastLapDto>();
            CreateMap<Fine, FineDto>();
            CreateMap<GP, GPDto>();
            CreateMap<GPResult, GPResultDto>();
            CreateMap<LeaderLap, LeaderLapDto>();
            CreateMap<Livery, LiveryDto>();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<Pit, PitDto>();
            CreateMap<Qualification, QualificationDto>();
            CreateMap<Racer, RacerDto>();
            CreateMap<Season, SeasonDto>();
            CreateMap<Team, TeamDto>();
            CreateMap<TeamName, TeamNameDto>();
            CreateMap<Track, TrackDto>();
            CreateMap<TrackСonfiguration, TrackСonfigurationDto>();
            CreateMap<TypeCalculate, TypeCalculateDto>();
            CreateMap<TypeDNQ, TypeDNQDto>();
            CreateMap<TypeFail, TypeFailDto>();
            CreateMap<TypeFinish, TypeFinishDto>();
            CreateMap<Tyre, TyreDto>();
        }
    }
}
