using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IChassiRepository Chassi { get; }
        ICountryRepository Country { get; }
        IDescriptionGPResultRepository DescriptionGPResult { get; }
        IDNQRepository DNQ { get; }
        IEngineRepository Engine { get; }
        IFailRepository Fail { get; }
        IFastLapRepository FastLap { get; }
        IFineRepository Fine { get; }
        IGPRepository GP { get; }
        IGPResultRepository GPResult { get; }
        IImageRepository Image { get; }
        ILeaderLapRepository LeaderLap { get; }
        IManufacturerRepository Manufacturer { get; }
        IParticipantRepository Participant { get; }
        IPitRepository Pit { get; }
        IQualificationRepository Qualification { get; }
        IRacerRepository Racer { get; }
        ISeasonRepository Season { get; }
        ITeamNameRepository TeamName { get; }
        ITeamRepository Team { get; }
        ITrackСonfigurationRepository TrackConfiguration { get; }
        ITrackRepository Track { get; }
        ITypeFailRepository TypeFail { get; }
        ITyreRepository Tyre { get; }
        Task SaveAsync();
    }
}
