using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BBP
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("jymanager") { }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Online> Onlines { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        //权限部分
        public DbSet<ControllerAction> ControllerActions { get; set; }
        public DbSet<ControllerActionRole> ControllerActionRoles { get; set; }
        public DbSet<Operator> Operators { get; set; }
        //系统业务部分
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBill> Bills { get; set; }
        public DbSet<RepairDetail> RepairDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }

        //系统业务-考核部分
        public DbSet<AttrType> AttrTypes { get; set; }
        public DbSet<Attrs> Attrs { get; set; }
        public DbSet<ValueType> ValueTypes { get; set; }

        public DbSet<ETAttr> ETAttrs { get; set; }
        public DbSet<ExamineeType> ExamineeTypes { get; set; }

        public DbSet<Examinee> Examinees { get; set; }
        public DbSet<AttrValue> ExamineeAttrValue { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<QuestionResult> QuestionResults { get; set; }
        public DbSet<ExaminationTask> ExaminationTasks { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

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

            modelBuilder.Entity<User>()
                .HasMany(r => r.Powers)
                .WithMany(p => p.Users)
                .Map(x => x.ToTable("UserPowers")
                    .MapLeftKey("UserID")
                    .MapRightKey("PowerID"));
            modelBuilder.Entity<Operator>()
                .HasOptional(o => o.Role)
                .WithMany()
                .Map(x => x.MapKey("RoleID"));

            modelBuilder.Entity<Order>()
                .HasMany(r => r.Bills)
                .WithOptional(b => b.Order)
                .Map(x => x.MapKey("OrderID"));
            modelBuilder.Entity<Order>()
                .HasMany(r => r.Details)
                .WithOptional(d => d.Order)
                .Map(x => x.MapKey("OrderID"));
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Dept)
                .WithMany()
                .Map(x => x.MapKey("DeptId"));
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Engineer)
                .WithMany()
                .Map(x => x.MapKey("EngineerId"));
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOptional(o => o.Customer)
                .Map(x => x.MapKey("OrderID"));

            modelBuilder.Entity<Customer>()
                .HasOptional(c => c.Creator)
                .WithMany()
                .Map(x => x.MapKey("Creator"));
            
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Creator)
                .WithMany()
                .Map(x => x.MapKey("UserID"));
            modelBuilder.Entity<Task>()
                .HasOptional(t => t.User)
                .WithMany()
                .Map(x => x.MapKey("UserID"));
            modelBuilder.Entity<Task>()
                .HasOptional(t => t.Order)
                .WithMany()
                .Map(x => x.MapKey("OrderID"));
            /*
            modelBuilder.Entity<ControllerAction>()
                .HasMany(c => c.Roles)
                .WithMany(r => r.ControllerActions)
                .Map(x => x.ToTable("ControllerActionRole")
                    .MapLeftKey("ControllerActionID")
                    .MapRightKey("RoleID"));
             */
            modelBuilder.Entity<ControllerActionRole>()
                .HasOptional(c => c.ControllerAction)
                .WithMany()
                .Map(x => x.MapKey("ControllerActionID"));
            modelBuilder.Entity<ControllerActionRole>()
               .HasOptional(c => c.Role)
               .WithMany()
               .Map(x => x.MapKey("RoleID"));

            modelBuilder.Entity<Attrs>()
                .HasOptional(t => t.AttrType)
                .WithMany()
                .Map(x => x.MapKey("TypeID"));
            modelBuilder.Entity<Attrs>()
                .HasOptional(t => t.ValueType)
                .WithMany()
                .Map(x => x.MapKey("ValueTypeId"));
            modelBuilder.Entity<ExamineeType>()
                .HasMany(t => t.ExtAttrs)
                .WithOptional(t=>t.ExamineeType)
                .Map(x =>x.MapKey("ExamTypeId")).WillCascadeOnDelete(true);
            modelBuilder.Entity<ETAttr>()
                .HasOptional(t => t.ValueType)
                .WithMany()
                .Map(x => x.MapKey("ValueTypeId"));
            modelBuilder.Entity<AttrValue>()
                .HasOptional(t => t.EtAttr)
                .WithMany()
                .Map(x => x.MapKey("AttrId"))
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Examinee>()
                .HasMany(e => e.ExtAttrs)
                .WithOptional(a => a.Examinee)
                .Map(x => x.MapKey("ExamineeId"));
            modelBuilder.Entity<Examinee>()
                .HasOptional(e => e.ExamineeType)
                .WithMany()
                .Map(x => x.MapKey("ExamineeTypeId"));
            modelBuilder.Entity<Examination>()
                .HasOptional(e => e.Examinee)
                .WithMany()
                .Map(x => x.MapKey("ExamId"));
            modelBuilder.Entity<Examination>()
                .HasOptional(e => e.ExaminationTask)
                .WithMany()
                .Map(x => x.MapKey("TaskId"));
            modelBuilder.Entity<Examination>()
                .HasMany(e => e.QuestionResults)
                .WithOptional()
                .Map(x => x.MapKey("ExaminationId"));
            modelBuilder.Entity<QuestionResult>()
                .HasOptional(e => e.Question)
                .WithMany()
                .Map(x => x.MapKey("QuestionId"));
            modelBuilder.Entity<ExaminationTask>()
                .HasMany(e => e.Questions)
                .WithOptional()
                .Map(x => x.MapKey("ExamId")).WillCascadeOnDelete(true);
            modelBuilder.Entity<ExaminationTask>()
                .HasMany(e => e.Examinees)
                .WithMany()
                .Map(x => x.ToTable("Exam_Examinee").MapLeftKey("TaskId").MapRightKey("ExamineeId"));
            modelBuilder.Entity<Feedback>()
                .HasOptional(e => e.Examination)
                .WithMany()
                .Map(x => x.MapKey("ExamId"));
            modelBuilder.Entity<Feedback>()
                .HasOptional(e => e.ExamQuestion)
                .WithMany()
                .Map(x => x.MapKey("ExamQuestionId"));

        }
    }
}