using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yelo.Api.Filters;
using Yelo.BusinessEntities;
using Yelo.BusinessServices;
using Yelo.BusinessServices.Interfaces;
using Yelo.DataModel;

namespace Yelo.Api.Controllers
{
    [AuthorizationRequired]  
    public class GiftController : ApiController
    {

        private readonly IGiftServices _giftServices;

        #region Public Constructor

        /// <summary>  
        /// Public constructor to initialize product service instance  
        /// </summary>  
        public GiftController(IGiftServices giftServices)
        {
            _giftServices = giftServices;
        }

        #endregion  
        
        // GET api/gift  
        public HttpResponseMessage Get()
        {
            var gifts = _giftServices.GetAllGifts();
            if (gifts != null)
            {
                var giftEntities = gifts as List<GiftEntity> ?? gifts.ToList();
                if (giftEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, giftEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/gift/5  
        [Route("gift/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<GetGiftDetails_sp_Result> gift = _giftServices.GetGiftDetails(id);
            if (gift != null)
                return Request.CreateResponse(HttpStatusCode.OK, gift);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/gift  
        public int Post([FromBody] GiftEntity giftEntity)
        {
            return _giftServices.CreateGift(giftEntity);
        }

        // PUT api/gift/5  
        public bool Put(int id, [FromBody]GiftEntity giftEntity)
        {
            if (id > 0)
            {
                return _giftServices.UpdateGift(id, giftEntity);
            }
            return false;
        }

        // DELETE api/gift/5  
        public bool Delete(int id)
        {
            if (id > 0)
                return _giftServices.DeleteGift(id);
            return false;
        }  
    }
}
