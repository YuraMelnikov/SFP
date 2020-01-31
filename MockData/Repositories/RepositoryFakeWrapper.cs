using System;
using System.Collections.Generic;
using System.Text;
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

        public IChassiRepository Chassi => throw new NotImplementedException();

        public ICountryRepository Country => throw new NotImplementedException();

        public IDescriptionGPResultRepository DescriptionGPResult => throw new NotImplementedException();

        public IDNQRepository DNQ => throw new NotImplementedException();

        public IEngineRepository Engine => throw new NotImplementedException();

        public IFailRepository Fail => throw new NotImplementedException();

        public IFastLapRepository FastLap => throw new NotImplementedException();

        public IFineRepository Fine => throw new NotImplementedException();

        public IGPRepository GP => throw new NotImplementedException();

        public IGPResultRepository GPResult => throw new NotImplementedException();












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











        public ILeaderLapRepository LeaderLap => throw new NotImplementedException();

        public ILiveryRepository Livery => throw new NotImplementedException();

        public IManufacturerRepository Manufacturer => throw new NotImplementedException();

        public IParticipantRepository Participant => throw new NotImplementedException();

        public IPitRepository Pit => throw new NotImplementedException();

        public IQualificationRepository Qualification => throw new NotImplementedException();

        public IRacerRepository Racer => throw new NotImplementedException();

        public ISeasonRepository Season => throw new NotImplementedException();

        public ITeamNameRepository TeamName => throw new NotImplementedException();

        public ITeamRepository Team => throw new NotImplementedException();

        public ITrackConfigurationRepository TrackConfiguration => throw new NotImplementedException();

        public ITrackRepository Track => throw new NotImplementedException();

        public ITypeCalculateRepository TypeCalculate => throw new NotImplementedException();

        public ITypeDNQRepository TypeDNQ => throw new NotImplementedException();

        public ITypeFailRepository TypeFail => throw new NotImplementedException();

        public ITypeFinishRepository TypeFinish => throw new NotImplementedException();

        public ITyreRepository Tyre => throw new NotImplementedException();

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
