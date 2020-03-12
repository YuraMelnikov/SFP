using Entities;
using Contracts;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repoContext;
        private IChassiRepository _chassi;
        private ICountryRepository _country;
        private IDescriptionGPResultRepository _descriptionGPResult;
        private IDNQRepository _dNQ;
        private IEngineRepository _engine;
        private IFailRepository _fail;
        private IFastLapRepository _fastLap;
        private IFineRepository _fine;
        private IGPRepository _gP;
        private IGPResultRepository _gPResult;
        private IImageRepository _image;
        private ILeaderLapRepository _leaderLap;
        private ILiveryRepository _livery;
        private IManufacturerRepository _manufacturer;
        private IParticipantRepository _participant;
        private IPitRepository _pit;
        private IQualificationRepository _qualification;
        private IRacerRepository _racer;
        private ISeasonRepository _season;
        private ITeamNameRepository _teamName;
        private ITeamRepository _team;
        private ITrackСonfigurationRepository _trackConfiguration;
        private ITrackRepository _track;
        private ITypeCalculateRepository _typeCalculate;
        private ITypeDNQRepository _typeDNQ;
        private ITypeFailRepository _typeFail;
        private ITypeFinishRepository _typeFinish;
        private ITyreRepository _tyre;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IChassiRepository Chassi
        {
            get
            {
                if (_chassi == null)
                    _chassi = new ChassiRepository(_repoContext);
                return _chassi;
            }
        }

        public ICountryRepository Country 
        {
            get
            {
                if(_country == null)
                    _country = new CountryRepository(_repoContext);
                return _country;
            }
        }

        public IDescriptionGPResultRepository DescriptionGPResult 
        {
            get
            {
                if(_descriptionGPResult == null)
                    _descriptionGPResult = new DescriptionGPResultRepository(_repoContext);
                return _descriptionGPResult;
            }
        }

        public IDNQRepository DNQ 
        {
            get 
            {
                if(_dNQ == null)
                    _dNQ = new DNQRepository(_repoContext);
                return _dNQ;
            }
        }

        public IEngineRepository Engine 
        {
            get 
            {
                if(_engine == null)
                    _engine = new EngineRepository(_repoContext);
                return _engine;
            }
        }

        public IFailRepository Fail 
        {
            get
            {
                if(_fail == null)
                    _fail = new FailRepository(_repoContext);
                return _fail;
            }
        }

        public IFastLapRepository FastLap 
        {
            get 
            { 
                if(_fastLap == null)
                    _fastLap = new FastLapRepository(_repoContext);
                return _fastLap;
            }
        }

        public IFineRepository Fine 
        {
            get
            {
                if(_fine == null)
                    _fine = new FineRepository(_repoContext);
                return _fine;
            }
        }

        public IGPRepository GP 
        {
            get
            {
                if(_gP == null)
                    _gP = new GPRepository(_repoContext);
                return _gP;
            }
        }

        public IGPResultRepository GPResult 
        {
            get
            {
                if(_gPResult == null)
                    _gPResult = new GPResultRepository(_repoContext);
                return _gPResult;
            }
        }

        public IImageRepository Image 
        {
            get 
            { 
                if(_image == null)
                    _image = new ImageRepository(_repoContext);
                return _image;
            }
        }

        public ILeaderLapRepository LeaderLap 
        {
            get 
            {
                if(_leaderLap == null)
                    _leaderLap = new LeaderLapRepository(_repoContext);
                return _leaderLap;
            }
        }

        public ILiveryRepository Livery 
        {
            get
            {
                if(_livery == null)
                    _livery = new LiveryRepository(_repoContext);
                return _livery;
            }
        }

        public IManufacturerRepository Manufacturer 
        {
            get 
            { 
                if(_manufacturer == null)
                    _manufacturer = new ManufacturerRepository(_repoContext);
                return _manufacturer;
            }
        }

        public IParticipantRepository Participant
        {
            get
            {
                if(_participant == null)
                    _participant = new ParticipantRepository(_repoContext);
                return _participant;
            }
        }

        public IPitRepository Pit
        {
            get
            {
                if(_pit == null)
                    _pit = new PitRepository(_repoContext);
                return _pit;
            }
        }

        public IQualificationRepository Qualification
        {
            get
            {
                if(_qualification == null)
                    _qualification = new QualificationRepository(_repoContext);
                return _qualification;
            }
        }

        public IRacerRepository Racer
        {
            get
            {
                if(_racer == null)
                    _racer = new RacerRepository(_repoContext);
                return _racer;
            }
        }

        public ISeasonRepository Season
        {
            get
            {
                if(_season == null)
                    _season = new SeasonRepository(_repoContext);
                return _season;
            }
        }

        public ITeamNameRepository TeamName
        {
            get
            {
                if (_teamName == null)
                    _teamName = new TeamNameRepository(_repoContext);
                return _teamName;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if(_team == null)
                    _team = new TeamRepository(_repoContext);
                return _team;
            }
        }

        public ITrackСonfigurationRepository TrackConfiguration
        {
            get
            {
                if(_trackConfiguration == null)
                    _trackConfiguration = new TrackConfigurationRepository(_repoContext);
                return _trackConfiguration;
            }
        }

        public ITrackRepository Track
        {
            get
            {
                if(_track == null)
                    _track = new TrackRepository(_repoContext);
                return _track;
            }
        }

        public ITypeCalculateRepository TypeCalculate
        {
            get
            {
                if(_typeCalculate == null)
                    _typeCalculate = new TypeCalculateRepository(_repoContext);
                return _typeCalculate;
            }
        }

        public ITypeDNQRepository TypeDNQ
        {
            get
            {
                if(_typeDNQ == null)
                    _typeDNQ = new TypeDNQRepository(_repoContext);
                return _typeDNQ;
            }
        }

        public ITypeFailRepository TypeFail
        {
            get
            {
                if(_typeFail == null)
                    _typeFail = new TypeFailRepository(_repoContext);
                return _typeFail;
            }
        }

        public ITypeFinishRepository TypeFinish
        {
            get
            {
                if(_typeFinish == null)
                    _typeFinish = new TypeFinishRepository(_repoContext);
                return _typeFinish;
            }
        }

        public ITyreRepository Tyre
        {
            get
            {
                if(_tyre == null)
                    _tyre = new TyreRepository(_repoContext);
                return _tyre;
            }
        }

        public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}
