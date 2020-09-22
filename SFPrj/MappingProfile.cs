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
            CreateMap<ChassiCreateDto, Chassi>();
            CreateMap<ChassiUpdateDto, Chassi>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>();

            CreateMap<DescriptionGPResult, DescriptionGPResultDto>();
            CreateMap<DescriptionGPResultCreateDto, DescriptionGPResult>();
            CreateMap<DescriptionGPResultUpdateDto, DescriptionGPResult>();

            CreateMap<DNQ, DNQDto>();
            CreateMap<DNQCreateDto, DNQ>();
            CreateMap<DNQUpdateDto, DNQ>();

            CreateMap<Engine, EngineDto>();
            CreateMap<EngineCreateDto, Engine>();
            CreateMap<EngineUpdateDto, Engine>();

            CreateMap<Fail, FailDto>();
            CreateMap<FailCreateDto, Fail>();
            CreateMap<FailUpdateDto, Fail>();

            CreateMap<FastLap, FastLapDto>();
            CreateMap<FastLapCreateDto, FastLap>();
            CreateMap<FastLapUpdateDto, FastLap>();

            CreateMap<Fine, FineDto>();
            CreateMap<FineCreateDto, Fine>();
            CreateMap<FineUpdateDto, Fine>();

            CreateMap<GP, GPDto>();
            CreateMap<GPCreateDto, GP>();
            CreateMap<GPUpdateDto, GP>();

            CreateMap<GPResult, GPResultDto>();
            CreateMap<GPResultCreateDto, GPResult>();
            CreateMap<GPResultUpdateDto, GPResult>();

            CreateMap<LeaderLap, LeaderLapDto>();
            CreateMap<LeaderLapCreateDto, LeaderLap>();
            CreateMap<LeaderLapUpdateDto, LeaderLap>();

            CreateMap<Livery, LiveryDto>();
            CreateMap<LiveryCreateDto, Livery>();
            CreateMap<LiveryUpdateDto, Livery>();

            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<ManufacturerCreateDto, Manufacturer>();
            CreateMap<ManufacturerUpdateDto, Manufacturer>();

            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantCreateDto, Participant>(); 
            CreateMap<ParticipantUpdateDto, Participant>();

            CreateMap<Pit, PitDto>();
            CreateMap<PitCreateDto, Pit>();
            CreateMap<PitUpdateDto, Pit>();

            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationCreateDto, Qualification>();
            CreateMap<QualificationUpdateDto, Qualification>();

            CreateMap<Racer, RacerDto>();
            CreateMap<RacerCreateDto, Racer>();
            CreateMap<RacerUpdateDto, Racer>();

            CreateMap<Season, SeasonDto>();
            CreateMap<SeasonCreateDto, Season>();
            CreateMap<SeasonUpdateDto, Season>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();

            CreateMap<TeamName, TeamNameDto>();
            CreateMap<TeamNameCreateDto, TeamName>();
            CreateMap<TeamNameUpdateDto, TeamName>();

            CreateMap<Track, TrackDto>();
            CreateMap<TrackCreateDto, Track>();
            CreateMap<TrackUpdateDto, Track>();

            CreateMap<TrackСonfiguration, TrackСonfigurationDto>();
            CreateMap<TrackСonfigurationCreateDto, TrackСonfiguration>();
            CreateMap<TrackСonfigurationUpdateDto, TrackСonfiguration>();

            CreateMap<TypeCalculate, TypeCalculateDto>();
            CreateMap<TypeCalculateCreateDto, TypeCalculate>();
            CreateMap<TypeCalculateUpdateDto, TypeCalculate>();

            CreateMap<TypeDNQ, TypeDNQDto>();
            CreateMap<TypeDNQCreateDto, TypeDNQ>();
            CreateMap<TypeDNQUpdateDto, TypeDNQ>();

            CreateMap<TypeFail, TypeFailDto>();
            CreateMap<TypeFailCreateDto, TypeFail>();
            CreateMap<TypeFailUpdateDto, TypeFail>();

            CreateMap<TypeFinish, TypeFinishDto>();
            CreateMap<TypeFinishCreateDto, TypeFinish>();
            CreateMap<TypeFinishUpdateDto, TypeFinish>();

            CreateMap<Tyre, TyreDto>();
            CreateMap<TyreCreateDto, Tyre>(); 
            CreateMap<TyreUpdateDto, Tyre>();
        }
    }
}
