using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yelo.Api.Filters;
using Yelo.BusinessEntities;
using Yelo.BusinessServices.Interfaces;

namespace Yelo.Api.Controllers
{
    [AuthorizationRequired]  
    public class CityController : ApiController
    {
        private readonly ICityServices _cityServices;

         #region Public Constructor

        /// <summary>  
        /// Public constructor to initialize city service instance  
        /// </summary>  
        public CityController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        #endregion  

        // GET api/city  
        public HttpResponseMessage Get()
        {
            var cities = _cityServices.GetAllCities();
            if (cities != null)
            {
                var cityEntities = cities as List<CityEntity> ?? cities.ToList();
                if (cityEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
        }

        // GET api/city/1  
        [Route("city/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            CityEntity city = _cityServices.GetCityById(id);
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No city found for this id");
        }

        // POST api/city  
        public int Post([FromBody] CityEntity cityEntity)
        {
            return _cityServices.CreateCity(cityEntity);
        }

        // PUT api/city/5  
        public bool Put(int id, [FromBody]CityEntity cityEntity)
        {
            if (id > 0)
            {
                return _cityServices.UpdateCity(id, cityEntity);
            }
            return false;
        }

        // DELETE api/city/5  
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityServices.DeleteCity(id);
            return false;
        }  
    }
}
