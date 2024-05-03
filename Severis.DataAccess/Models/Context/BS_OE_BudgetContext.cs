using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Severis.DataAccess.Models.DB;

#nullable disable

namespace Severis.DataAccess.Models.Context
{
    public partial class BS_OE_BudgetContext : DbContext
    {
        public BS_OE_BudgetContext()
        {
        }

        public BS_OE_BudgetContext(DbContextOptions<BS_OE_BudgetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarGroup> CarGroups { get; set; }
        public virtual DbSet<EstimateTotalVehicleProduction> EstimateTotalVehicleProductions { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Oem> Oems { get; set; }
        public virtual DbSet<UploadFileErrorMessage> UploadFileErrorMessages { get; set; }
        public virtual DbSet<UploadFileJob> UploadFileJobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS03;Database=BS_OE_Budget;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<CarGroup>(entity =>
            {
                entity.Property(e => e.CarGroupId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EstimateTotalVehicleProduction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Oem)
                    .WithMany(p => p.EstimateTotalVehicleProductions)
                    .HasForeignKey(d => d.OemId)
                    .HasConstraintName("FK_EstimateTotalVehicleProduction_OEM");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Oem>(entity =>
            {
                entity.Property(e => e.OemId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UploadFileErrorMessage>(entity =>
            {
                entity.Property(e => e.UploadFileErrorMessageId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UploadFileJob>(entity =>
            {
                entity.Property(e => e.UploadFileId).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
