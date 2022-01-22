using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class haushaltsbuchContext : DbContext
    {
        public haushaltsbuchContext()
        {
        }

        public haushaltsbuchContext(DbContextOptions<haushaltsbuchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ausgaben> Ausgabens { get; set; }
        public virtual DbSet<Einkomman> Einkommen { get; set; }
        public virtual DbSet<Familienmitglied> Familienmitglieds { get; set; }
        public virtual DbSet<Japan> Japans { get; set; }
        public virtual DbSet<Laden> Ladens { get; set; }
        public virtual DbSet<Pkw> Pkws { get; set; }
        public virtual DbSet<Produktgruppe> Produktgruppes { get; set; }
        public virtual DbSet<Rechnung> Rechnungs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=haushaltsbuch");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ausgaben>(entity =>
            {
                entity.ToTable("ausgaben");

                entity.HasIndex(e => e.ProdGr, "ausgabe_to_kategorie");

                entity.HasIndex(e => e.Rechnungsnr, "ausgabe_to_rechnung");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Betrag)
                    .HasColumnName("betrag")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(60)
                    .HasColumnName("bezeichnung")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProdGr)
                    .HasColumnType("int(2)")
                    .HasColumnName("prod_gr")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rechnungsnr)
                    .HasColumnType("int(11)")
                    .HasColumnName("rechnungsnr")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.ProdGrNavigation)
                    .WithMany(p => p.Ausgabens)
                    .HasForeignKey(d => d.ProdGr)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ausgabe_to_kategorie");

                entity.HasOne(d => d.RechnungsnrNavigation)
                    .WithMany(p => p.Ausgabens)
                    .HasForeignKey(d => d.Rechnungsnr)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ausgabe_to_rechnung");
            });

            modelBuilder.Entity<Einkomman>(entity =>
            {
                entity.HasKey(e => e.Nr)
                    .HasName("PRIMARY");

                entity.ToTable("einkommen");

                entity.HasIndex(e => e.Person, "einkommen_to_person");

                entity.Property(e => e.Nr)
                    .HasColumnType("int(11)")
                    .HasColumnName("nr");

                entity.Property(e => e.Betrag)
                    .HasColumnName("betrag")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(60)
                    .HasColumnName("bezeichnung")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Person)
                    .HasColumnType("int(1)")
                    .HasColumnName("person")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Einkommen)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("einkommen_to_person");
            });

            modelBuilder.Entity<Familienmitglied>(entity =>
            {
                entity.ToTable("familienmitglied");

                entity.Property(e => e.Id)
                    .HasColumnType("int(1)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(20)
                    .HasColumnName("nachname")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(20)
                    .HasColumnName("vorname")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Japan>(entity =>
            {
                entity.ToTable("japan");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Betrag)
                    .HasColumnName("betrag")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(60)
                    .HasColumnName("bezeichnung")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Essen)
                    .HasColumnName("essen")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Geschenk)
                    .HasColumnName("geschenk")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Laden)
                    .HasMaxLength(40)
                    .HasColumnName("laden")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Person)
                    .HasColumnType("int(1)")
                    .HasColumnName("person")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Laden>(entity =>
            {
                entity.ToTable("laden");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Online).HasColumnName("online");
            });

            modelBuilder.Entity<Pkw>(entity =>
            {
                entity.ToTable("pkw");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(100)
                    .HasColumnName("bemerkungen")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Km)
                    .HasColumnName("KM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Verbrauch)
                    .HasColumnName("verbrauch")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Produktgruppe>(entity =>
            {
                entity.ToTable("produktgruppe");

                entity.Property(e => e.Id)
                    .HasColumnType("int(2)")
                    .HasColumnName("ID");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(20)
                    .HasColumnName("bezeichnung")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Essen).HasColumnName("essen");
            });

            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.ToTable("rechnung");

                entity.HasIndex(e => e.Laden, "rechnung_to_laden");

                entity.HasIndex(e => e.Person, "rechnung_to_person");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Einmalig)
                    .HasColumnType("int(1)")
                    .HasColumnName("einmalig")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Laden)
                    .HasColumnType("int(11)")
                    .HasColumnName("laden")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Person)
                    .HasColumnType("int(1)")
                    .HasColumnName("person")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.LadenNavigation)
                    .WithMany(p => p.Rechnungs)
                    .HasForeignKey(d => d.Laden)
                    .HasConstraintName("rechnung_to_laden");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Rechnungs)
                    .HasForeignKey(d => d.Person)
                    .HasConstraintName("rechnung_to_person");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Name, "USER_NAME")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
