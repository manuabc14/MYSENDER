using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MYSENDER.Models
{
    public partial class MYSENDERContext : DbContext
    {
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Emetteur> Emetteur { get; set; }
        public virtual DbSet<Historique> Historique { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=TRSB1209002\SQLEXPRESS2014;Database=MYSENDER;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(36);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Emetteur>(entity =>
            {
                entity.ToTable("EMETTEUR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accestoken)
                    .HasColumnName("ACCESTOKEN")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(36);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Historique>(entity =>
            {
                entity.ToTable("HISTORIQUE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEnvoi)
                    .HasColumnName("DATE_ENVOI")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdContact).HasColumnName("ID_CONTACT");

                entity.Property(e => e.IdEmetteur).HasColumnName("ID_EMETTEUR");

                entity.Property(e => e.Smstext)
                    .HasColumnName("SMSTEXT")
                    .HasMaxLength(160);

                entity.Property(e => e.Statut).HasColumnName("STATUT");

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.Historique)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_CONTACT");

                entity.HasOne(d => d.IdEmetteurNavigation)
                    .WithMany(p => p.Historique)
                    .HasForeignKey(d => d.IdEmetteur)
                    .HasConstraintName("FK_EMETEUR");
            });
        }
    }
}