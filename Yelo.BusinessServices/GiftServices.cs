using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;
using Yelo.DataModel;
using Yelo.DataModel.UnitOfWork;
using AutoMapper;
using System.Data;
using System.Data.SqlClient;

namespace Yelo.BusinessServices
{
    public class GiftServices : IGiftServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>  
        /// Public constructor.  
        /// </summary>  
        public GiftServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// Fetches gift details by id  
        /// </summary>  
        /// <param name="giftId"></param>  
        /// <returns></returns> 
        public GiftEntity GetGiftById(int giftId)
        {
            var gift = _unitOfWork.GiftRepository.GetByID(giftId);
            if (gift != null)
            {
                Mapper.CreateMap<Gift, GiftEntity>();
                var giftModel = Mapper.Map<Gift, GiftEntity>(gift);
                return giftModel;  
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the gifts.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<GiftEntity> GetAllGifts()
        {
            var gifts = _unitOfWork.GiftRepository.GetAll().ToList();
            if (gifts.Any())
            {
                Mapper.CreateMap<Gift, GiftEntity>();
                var giftsModel = Mapper.Map<List<Gift>, List<GiftEntity>>(gifts);
                return giftsModel;
            }
            return null; 
        }

        /// <summary>  
        /// Creates a gift  
        /// </summary>  
        /// <param name="giftEntity"></param>  
        /// <returns></returns>  
        public int CreateGift(GiftEntity giftEntity)
        {
            //using (var scope = new TransactionScope()) // TODO: Handle transction scope.
            //{
                var gift = new Gift
                {
                    GiftName = giftEntity.GiftName
                };
                _unitOfWork.GiftRepository.Insert(gift);
                _unitOfWork.Save();
                //scope.Complete();
                return gift.GiftId;
            //}  
        }

        /// <summary>  
        /// Updates a gift  
        /// </summary>  
        /// <param name="giftId"></param>  
        /// <param name="giftEntity"></param>  
        /// <returns></returns>  
        public bool UpdateGift(int giftId, GiftEntity giftEntity)
        {
            var success = false;
            if (giftEntity != null)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                    var gift = _unitOfWork.GiftRepository.GetByID(giftId);
                    if (gift != null)
                    {
                        gift.GiftName = giftEntity.GiftName;
                        _unitOfWork.GiftRepository.Update(gift);
                        _unitOfWork.Save();
                        //scope.Complete();
                        success = true;
                    }
                //}
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular gift  
        /// </summary>  
        /// <param name="giftId"></param>  
        /// <returns></returns>     
        public bool DeleteGift(int giftId)
        {
            var success = false;
            if (giftId > 0)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                var gift = _unitOfWork.GiftRepository.GetByID(giftId);
                    if (gift != null)
                    {

                        _unitOfWork.GiftRepository.Delete(gift);
                        _unitOfWork.Save();
                        //scope.Complete();
                        success = true;
                    }
                //}
            }
            return success; 
        }

        public IEnumerable<GetGiftDetails_sp_Result> GetGiftDetails(int giftId)
        {
            var gifts = _unitOfWork.GiftRepository.ExecWithStoreProcedure<GetGiftDetails_sp_Result>("GetGiftDetails_sp @ProductId", new SqlParameter("ProductId", SqlDbType.Int) { Value = giftId });
            return gifts;

        }
    }
}
