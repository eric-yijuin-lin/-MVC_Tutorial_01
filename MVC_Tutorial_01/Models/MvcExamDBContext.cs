using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_Tutorial_01.Models
{
    public partial class MvcExamDBContext : DbContext
    {
        public MvcExamDBContext()
        {
        }

        public MvcExamDBContext(DbContextOptions<MvcExamDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblNews> TblNews { get; set; }
        public virtual DbSet<TblNewsType> TblNewsType { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CCustomerId);

                entity.Property(e => e.CCustomerId).HasColumnName("cCustomerID");

                entity.Property(e => e.CCreatorDt)
                    .HasColumnName("cCreatorDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CCreatorId).HasColumnName("cCreatorID");

                entity.Property(e => e.CCustomerAddress)
                    .IsRequired()
                    .HasColumnName("cCustomerAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.CCustomerName)
                    .IsRequired()
                    .HasColumnName("cCustomerName")
                    .HasMaxLength(50);

                entity.Property(e => e.CCustomerPhone)
                    .IsRequired()
                    .HasColumnName("cCustomerPhone")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblNews>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CreateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblNewsType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeText)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.CUserId);

                entity.Property(e => e.CUserId).HasColumnName("cUserID");

                entity.Property(e => e.CCreatorDt)
                    .HasColumnName("cCreatorDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CCreatorId).HasColumnName("cCreatorID");

                entity.Property(e => e.CUserAccout)
                    .IsRequired()
                    .HasColumnName("cUserAccout")
                    .HasMaxLength(20);

                entity.Property(e => e.CUserMail)
                    .IsRequired()
                    .HasColumnName("cUserMail")
                    .HasMaxLength(200);

                entity.Property(e => e.CUserName)
                    .IsRequired()
                    .HasColumnName("cUserName")
                    .HasMaxLength(50);

                entity.Property(e => e.CUserPassword)
                    .IsRequired()
                    .HasColumnName("cUserPassword")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
