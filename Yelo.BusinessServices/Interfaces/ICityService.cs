using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;

namespace Yelo.BusinessServices.Interfaces
{
    public interface ICityServices
    {
        CityEntity GetCityById(int cityId);
        IEnumerable<CityEntity> GetAllCities();
        int CreateCity(CityEntity cityEntity);
        bool UpdateCity(int cityId, CityEntity cityEntity);
        bool DeleteCity(int cityId);  
    }
}
