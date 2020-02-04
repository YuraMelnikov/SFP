using System;
using System.Threading.Tasks;
using Contracts;

namespace MockData.Repositories
{
    public class RepositoryFakeWrapper : IRepositoryWrapper
    {
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
        private ITrackConfigurationRepository _trackConfiguration;
        private ITrackRepository _track;
        private ITypeCalculateRepository _typeCalculate;
        private ITypeDNQRepository _typeDNQ;
        private ITypeFailRepository _typeFail;
        private ITypeFinishRepository _typeFinish;
        private ITyreRepository _tyre;


        public IChassiRepository Chassi
        {
            get
            {
                if (_chassi == null)
                {
                    _chassi = new ChassiFakeRepository();
                }

                return _chassi;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryFakeRepository();
                }

                return _country;
            }
        }

        public IDescriptionGPResultRepository DescriptionGPResult
        {
            get
            {
                if (_descriptionGPResult == null)
                {
                    _descriptionGPResult = new DescriptionGPResultFakeRepository();
                }

                return _descriptionGPResult;
            }
        }

        public IDNQRepository DNQ
        {
            get
            {
                if (_dNQ == null)
                {
                    _dNQ = new DNQFakeRepository();
                }

                return _dNQ;
            }
        }

        public IEngineRepository Engine
        {
            get
            {
                if (_engine == null)
                {
                    _engine = new EngineFakeRepository();
                }

                return _engine;
            }
        }

        public IFailRepository Fail
        {
            get
            {
                if (_fail == null)
                {
                    _fail = new FailFakeRepository();
                }

                return _fail;
            }
        }

        public IFastLapRepository FastLap
        {
            get
            {
                if (_fastLap == null)
                {
                    _fastLap = new FastLapFakeRepository();
                }

                return _fastLap;
            }
        }

        public IFineRepository Fine
        {
            get
            {
                if (_fine == null)
                {
                    _fine = new FineFakeRepository();
                }

                return _fine;
            }
        }

        public IGPRepository GP
        {
            get
            {
                if (_gP == null)
                {
                    _gP = new GPFakeRepository();
                }

                return _gP;
            }
        }

        public IGPResultRepository GPResult
        {
            get
            {
                if (_gPResult == null)
                {
                    _gPResult = new GPResultFakeRepository();
                }

                return _gPResult;
            }
        }

        public IImageRepository Image
        {
            get
            {
                if (_image == null)
                {
                    _image = new ImageFakeRepository();
                }

                return _image;
            }
        }

        public ILeaderLapRepository LeaderLap
        {
            get
            {
                if (_leaderLap == null)
                {
                    _leaderLap = new LeaderLapFakeRepository();
                }

                return _leaderLap;
            }
        }

        public ILiveryRepository Livery
        {
            get
            {
                if (_livery == null)
                {
                    _livery = new LiveryFakeRepository();
                }

                return _livery;
            }
        }

        public IManufacturerRepository Manufacturer
        {
            get
            {
                if (_manufacturer == null)
                {
                    _manufacturer = new ManufacturerFakeRepository();
                }

                return _manufacturer;
            }
        }

        public IParticipantRepository Participant
        {
            get
            {
                if (_participant == null)
                {
                    _participant = new ParticipantFakeRepository();
                }

                return _participant;
            }
        }

        public IPitRepository Pit
        {
            get
            {
                if (_pit == null)
                {
                    _pit = new PitFakeRepository();
                }

                return _pit;
            }
        }

        public IQualificationRepository Qualification
        {
            get
            {
                if (_qualification == null)
                {
                    _qualification = new QualificationFakeRepository();
                }

                return _qualification;
            }
        }

        public IRacerRepository Racer
        {
            get
            {
                if (_racer == null)
                {
                    _racer = new RacerFakeRepository();
                }

                return _racer;
            }
        }

        public ISeasonRepository Season
        {
            get
            {
                if (_season == null)
                {
                    _season = new SeasonFakeRepository();
                }

                return _season;
            }
        }

        public ITeamNameRepository TeamName
        {
            get
            {
                if (_teamName == null)
                {
                    _teamName = new TeamNameFakeRepository();
                }

                return _teamName;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamFakeRepository();
                }

                return _team;
            }
        }

        public ITrackConfigurationRepository TrackConfiguration
        {
            get
            {
                if (_trackConfiguration == null)
                {
                    _trackConfiguration = new TrackСonfigurationFakeRepository();
                }

                return _trackConfiguration;
            }
        }

        public ITrackRepository Track
        {
            get
            {
                if (_track == null)
                {
                    _track = new TrackFakeRepository();
                }

                return _track;
            }
        }

        public ITypeCalculateRepository TypeCalculate
        {
            get
            {
                if (_typeCalculate == null)
                {
                    _typeCalculate = new TypeCalculateFakeRepository();
                }

                return _typeCalculate;
            }
        }

        public ITypeDNQRepository TypeDNQ
        {
            get
            {
                if (_typeDNQ == null)
                {
                    _typeDNQ = new TypeDNQFakeRepository();
                }

                return _typeDNQ;
            }
        }

        public ITypeFailRepository TypeFail
        {
            get
            {
                if (_typeFail == null)
                {
                    _typeFail = new TypeFailFakeRepository();
                }

                return _typeFail;
            }
        }

        public ITypeFinishRepository TypeFinish
        {
            get
            {
                if (_typeFinish == null)
                {
                    _typeFinish = new TypeFinishFakeRepository();
                }

                return _typeFinish;
            }
        }

        public ITyreRepository Tyre
        {
            get
            {
                if (_tyre == null)
                {
                    _tyre = new TyreFakeRepository();
                }

                return _tyre;
            }
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
