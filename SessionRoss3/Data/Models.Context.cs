﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SessionRoss3.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VseRossDBEntities4 : DbContext
    {
        public VseRossDBEntities4()
            : base("name=VseRossDBEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<MethodPay> MethodPay { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInVending> ProductInVending { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vending> Vending { get; set; }
    }
}
