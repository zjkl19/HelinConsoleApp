﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelinConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HighSpeed_JCBEntities : DbContext
    {
        public HighSpeed_JCBEntities()
            : base("name=HighSpeed_JCBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HS_Data> HS_Data { get; set; }
        public virtual DbSet<HS_Data_201907> HS_Data_201907 { get; set; }
        public virtual DbSet<HS_Data_201908> HS_Data_201908 { get; set; }
        public virtual DbSet<HS_Data_201909> HS_Data_201909 { get; set; }
        public virtual DbSet<HS_Data_201910> HS_Data_201910 { get; set; }
        public virtual DbSet<HS_Data_201911> HS_Data_201911 { get; set; }
        public virtual DbSet<HS_Data_201912> HS_Data_201912 { get; set; }
        public virtual DbSet<HS_Data_202001> HS_Data_202001 { get; set; }
        public virtual DbSet<HS_Data_202002> HS_Data_202002 { get; set; }
        public virtual DbSet<HS_Data_202003> HS_Data_202003 { get; set; }
        public virtual DbSet<HS_Data_202004> HS_Data_202004 { get; set; }
        public virtual DbSet<HS_Data_202005> HS_Data_202005 { get; set; }
        public virtual DbSet<HS_Data_202006> HS_Data_202006 { get; set; }
        public virtual DbSet<HS_Data_202007> HS_Data_202007 { get; set; }
        public virtual DbSet<HS_Data_202008> HS_Data_202008 { get; set; }
        public virtual DbSet<HS_Data_202009> HS_Data_202009 { get; set; }
        public virtual DbSet<HS_Data_202010> HS_Data_202010 { get; set; }
        public virtual DbSet<LDN_HS_Data> LDN_HS_Data { get; set; }
    }
}
