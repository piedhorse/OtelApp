using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OtelApp.DataDB
{
    public partial class OtelRezervasyonContext : DbContext
    {
        public OtelRezervasyonContext()
        {
        }

        public OtelRezervasyonContext(DbContextOptions<OtelRezervasyonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OtelOdalari> OtelOdalaris { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6OAEM3JA;Database=OtelRezervasyon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OtelOdalari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OtelOdalari");

                entity.Property(e => e.Fiyat).HasColumnType("money");

                entity.Property(e => e.OdaAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Oda Adi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
