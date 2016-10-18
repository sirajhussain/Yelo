using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;
using Yelo.DataModel;

namespace Yelo.BusinessServices
{
    /// <summary>  
    /// Gift Service Contract  
    /// </summary>  
    public interface IGiftServices
    {
        GiftEntity GetGiftById(int giftId);
        IEnumerable<GiftEntity> GetAllGifts();
        int CreateGift(GiftEntity giftEntity);
        bool UpdateGift(int giftId, GiftEntity giftEntity);
        bool DeleteGift(int giftId);
        // Stored procedures.
        IEnumerable<GetGiftDetails_sp_Result> GetGiftDetails(int giftId);
    }
}
