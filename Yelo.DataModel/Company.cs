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
    using System.Collections.Generic;
    
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<bool> IsArchived { get; set; }
    
        public virtual City City { get; set; }
        public virtual Gift Gift { get; set; }
    }
}
