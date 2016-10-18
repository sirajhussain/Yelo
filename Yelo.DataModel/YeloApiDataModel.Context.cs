﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class YeloApiDbEntities : DbContext
    {
        public YeloApiDbEntities()
            : base("name=YeloApiDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<LotteryDate> LotteryDates { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UserGiftsClaimLog> UserGiftsClaimLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserWonGiftsLog> UserWonGiftsLogs { get; set; }
    
        public virtual ObjectResult<GetGiftDetails_sp_Result> GetGiftDetails_sp(Nullable<int> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetGiftDetails_sp_Result>("GetGiftDetails_sp", productIdParameter);
        }
    
        public virtual ObjectResult<GetUserGiftsClaims_sp_Result> GetUserGiftsClaims_sp(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserGiftsClaims_sp_Result>("GetUserGiftsClaims_sp", userIdParameter);
        }
    
        public virtual int GetUserProductsClaims_sp(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetUserProductsClaims_sp", userIdParameter);
        }
    
        public virtual ObjectResult<GetAllUsers_sp_Result> GetAllUsers_sp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUsers_sp_Result>("GetAllUsers_sp");
        }

    }
}
