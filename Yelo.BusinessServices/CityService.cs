using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;
using Yelo.DataModel;
using Yelo.DataModel.UnitOfWork;

namespace Yelo.BusinessServices.Interfaces
{
    public class CityServices : ICityServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CityServices(UnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }
        public BusinessEntities.CityEntity GetCityById(int cityId)
        {
            var city = _unitOfWork.CityRepository.GetByID(cityId);
            if (city != null)
            {
                Mapper.CreateMap<City, CityEntity>();
                var cityModel = Mapper.Map<City, CityEntity>(city);
                return cityModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.CityEntity> GetAllCities()
        {
            var cities = _unitOfWork.CityRepository.GetAll().ToList();
            if (cities.Any())
            {
                Mapper.CreateMap<City, CityEntity>();
                var citiesModel = Mapper.Map<List<City>, List<CityEntity>>(cities);
                return citiesModel;
            }
            return null; 
        }

        public int CreateCity(BusinessEntities.CityEntity cityEntity)
        {
            //using (var scope = new TransactionScope()) // TODO: Handle transction scope.
            //{
            var city = new City
            {
                CityName = cityEntity.CityName
            };
            _unitOfWork.CityRepository.Insert(city);
            _unitOfWork.Save();
            //scope.Complete();
            return city.CityId;
            //}  
        }

        public bool UpdateCity(int cityId, BusinessEntities.CityEntity cityEntity)
        {
            var success = false;
            if (cityEntity != null)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                var city = _unitOfWork.CityRepository.GetByID(cityId);
                if (city != null)
                {
                    city.CityName = cityEntity.CityName;
                    _unitOfWork.CityRepository.Update(city);
                    _unitOfWork.Save();
                    //scope.Complete();
                    success = true;
                }
                //}
            }
            return success;
        }

        public bool DeleteCity(int cityId)
        {
            var success = false;
            if (cityId > 0)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                var city = _unitOfWork.CityRepository.GetByID(cityId);
                if (city != null)
                {

                    _unitOfWork.CityRepository.Delete(city);
                    _unitOfWork.Save();
                    //scope.Complete();
                    success = true;
                }
                //}
            }
            return success; 
        }
    }
}
