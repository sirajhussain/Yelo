//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yelo.DataModel
{
    using System;
    
    public partial class GetGiftDetails_sp_Result
    {
        public int GiftId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string GiftName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> Claims { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ChanceOfWining { get; set; }
        public Nullable<int> DaysRemaining { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<bool> IsSpecial { get; set; }
        public string GiftDescription { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ValidityDate { get; set; }
        public Nullable<bool> IsArchived { get; set; }
    }
}
