﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KpopZtation.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KzEntities : DbContext
    {
        public KzEntities()
            : base("name=KzEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<album> albums { get; set; }
        public virtual DbSet<artist> artists { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<transactionDetail> transactionDetails { get; set; }
        public virtual DbSet<transactionHeader> transactionHeaders { get; set; }
    }
}
