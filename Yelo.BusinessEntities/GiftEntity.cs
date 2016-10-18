using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelo.BusinessEntities
{
    public class GiftEntity
    {
        public int GiftId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string GiftName { get; set; }
        public int CityId { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> Claims { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<bool> IsSpecial { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ValidityDate { get; set; }
        public Nullable<bool> IsArchived { get; set; }
    }
}
