using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JYManager
{
    public class BaseContext : DbContext
    {
        public BaseContext()
            : base("Default")
        {
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Online> Onlines { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        //系统业务部分
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBill> Bills { get; set; }
        public DbSet<RepairDetail> RepairDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .Map(x => x.ToTable("RoleUsers")
                    .MapLeftKey("RoleID")
                    .MapRightKey("UserID"));

            modelBuilder.Entity<Title>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Titles)
                .Map(x => x.ToTable("TitleUsers")
                    .MapLeftKey("TitleID")
                    .MapRightKey("UserID"));

            modelBuilder.Entity<Dept>()
                .HasOptional(d => d.Parent)
                .WithMany(d => d.Children)
                .Map(x => x.MapKey("ParentID"));

            modelBuilder.Entity<Dept>()
                .HasMany(d => d.Users)
                .WithOptional(u => u.Dept)
                .Map(x => x.MapKey("DeptID"));

            modelBuilder.Entity<Online>()
                .HasRequired(o => o.User)
                .WithMany()
                .Map(x => x.MapKey("UserID"));

            modelBuilder.Entity<Menu>()
                .HasOptional(m => m.Parent)
                .WithMany(m => m.Children)
                .Map(x => x.MapKey("ParentID"));

            //modelBuilder.Entity<Menu>()
            //    .HasOptional(m => m.Module)
            //    .WithMany()
            //    .Map(x => x.MapKey("ModuleID"));

            //modelBuilder.Entity<Module>()
            //    .HasMany(m => m.ModulePowers)
            //    .WithRequired(mp => mp.Module);

            //modelBuilder.Entity<Power>()
            //    .HasMany(p => p.ModulePowers)
            //    .WithRequired(mp => mp.Power);

            modelBuilder.Entity<Menu>()
                .HasOptional(m => m.ViewPower)
                .WithMany()
                .Map(x => x.MapKey("ViewPowerID"));

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Powers)
                .WithMany(p => p.Roles)
                .Map(x => x.ToTable("RolePowers")
                    .MapLeftKey("RoleID")
                    .MapRightKey("PowerID"));


            modelBuilder.Entity<Order>()
                .HasMany(r => r.Bills)
                .WithOptional(b => b.Order)
                .Map(x => x.MapKey("OrderID"));
            modelBuilder.Entity<Order>()
                .HasMany(r => r.Details)
                .WithOptional(d => d.Order)
                .Map(x => x.MapKey("OrderID"));
            modelBuilder.Entity<Order>()
                .HasMany(r => r.Customers)
                .WithMany(c => c.Orders)
                .Map(x => x.ToTable("CustomerOrders").MapLeftKey("OrderID").MapRightKey("CustomerID"));
        }
    }
}