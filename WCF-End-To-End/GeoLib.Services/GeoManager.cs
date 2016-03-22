using System.Collections.Generic;
using System.Data;
using GeoLib.Contracts;
using GeoLib.Data;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        IZipCodeRepository _zipCodeRepository = null;
        IStateRepository _stateRepository = null;

        public GeoManager()
        {
            
        }

        public GeoManager(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public GeoManager(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public GeoManager(ZipCodeRepository zipCodeRepository, StateRepository stateRepository)
        {
            _zipCodeRepository = zipCodeRepository;
            _stateRepository = stateRepository;
        }

        public ZipCodeData GetZipInfo(string zip)
        {
            ZipCodeData zipCodeData = null;


            IZipCodeRepository zipCodeRepository = _zipCodeRepository?? new ZipCodeRepository();
            


            ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zip);

            if (zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData()
                {
                    City = zipCodeEntity.City,
                    State = zipCodeEntity.State.Abbreviation,
                    ZipCode =  zipCodeEntity.Zip
                };
            }
            return zipCodeData;
        }

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
           List<string> stateData = new List<string>();

            IStateRepository stateRepository = _stateRepository?? new StateRepository();

            IEnumerable<State> states = stateRepository.Get(primaryOnly);

            if (states != null)
            {
                foreach (State state in states)
                {
                    stateData.Add(state.Abbreviation);
                }
            }
            return stateData;
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository?? new ZipCodeRepository();

            var zipCodes = zipCodeRepository.GetByState(state);

            if (zipCodes != null)
            {
                foreach (ZipCode zipCode in zipCodes)
                {
                    zipCodeData.Add(new ZipCodeData {City = zipCode.City,
                                                    ZipCode = zipCode.Zip,
                                                    State = zipCode.State.Abbreviation});
                }
            }
            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository?? new ZipCodeRepository();

            ZipCode zipEntity = zipCodeRepository.GetByZip(zip);

            var zipCodes = zipCodeRepository.GetZipsForRange(zipEntity, range);

            if (zipCodes != null)
            {
                foreach (ZipCode zipCode in zipCodes)
                {
                    zipCodeData.Add(new ZipCodeData { City = zipCode.City, ZipCode = zipCode.Zip, State = zipCode.State.Abbreviation });
                }
            }
            return zipCodeData;

        }
    }
}