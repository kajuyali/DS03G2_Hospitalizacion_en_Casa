using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
namespace HospiEnCasa.App.Persistencia.Models
{
    public partial class HospiEnCasaContext : DbContext
    {
        public HospiEnCasaContext()
        {
        }

        public HospiEnCasaContext(DbContextOptions<HospiEnCasaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignado> Asignados { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Enfermero> Enfermeros { get; set; }
        public virtual DbSet<Familiar> Familiars { get; set; }
        public virtual DbSet<Historium> Historia { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<SignosPaciente> SignosPacientes { get; set; }
        public virtual DbSet<SignosVitale> SignosVitales { get; set; }
        public virtual DbSet<Sugerencia> Sugerencias { get; set; }

        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asignado>(entity =>
            {
                entity.HasKey(e => e.IdAsignado)
                    .HasName("PK__asignado__123B78A95A0D4227");

                entity.ToTable("asignado");

                entity.Property(e => e.IdAsignado).HasColumnName("Id_Asignado");

                entity.Property(e => e.IdEnfermero).HasColumnName("Id_Enfermero");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.HasOne(d => d.IdEnfermeroNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdEnfermero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Enf__719CDDE7");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Med__72910220");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Pac__70A8B9AE");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.HasKey(e => e.IdEnfer)
                    .HasName("PK__enfermer__3E83A9A2B95AC1E7");

                entity.ToTable("enfermero");

                entity.Property(e => e.IdEnfer).HasColumnName("Id_Enfer");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Registro)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Enfermeros)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermero__Id_Pe__5D95E53A");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.HasKey(e => e.IdFamiliar)
                    .HasName("PK__familiar__1A397581C9519C8A");

                entity.ToTable("familiar");

                entity.Property(e => e.IdFamiliar).HasColumnName("Id_Familiar");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__Id_Pac__607251E5");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__Id_Per__6166761E");
            });

            modelBuilder.Entity<Historium>(entity =>
            {
                entity.HasKey(e => e.IdHistoria)
                    .HasName("PK__historia__7DBFFDCD2782CD7F");

                entity.ToTable("historia");

                entity.Property(e => e.IdHistoria).HasColumnName("Id_Historia");

                entity.Property(e => e.Diagnostico)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Historia)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__historia__Id_Pac__6442E2C9");

                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__7BA5D81035A324E2");

                entity.ToTable("medico");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Registro)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__Id_Perso__57DD0BE4");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPac)
                    .HasName("PK__paciente__51E3D4C0BA4249F0");

                entity.ToTable("paciente");

                entity.Property(e => e.IdPac).HasColumnName("Id_Pac");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__Id_Per__5AB9788F");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__C95634AFE3A77A1F");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__persona__Id_Usua__55009F39");
            });

            modelBuilder.Entity<SignosPaciente>(entity =>
            {
                entity.HasKey(e => e.IdSignoPaciente)
                    .HasName("PK__signos_p__690ACC198DC5BC16");

                entity.ToTable("signos_pacientes");

                entity.Property(e => e.IdSignoPaciente).HasColumnName("Id_SignoPaciente");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.IdSigno).HasColumnName("Id_Signo");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Pa__6DCC4D03");

                entity.HasOne(d => d.IdSignoNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdSigno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Si__6CD828CA");
            });

            modelBuilder.Entity<SignosVitale>(entity =>
            {
                entity.HasKey(e => e.IdSigno)
                    .HasName("PK__signos_v__EFF6D61F91D86911");

                entity.ToTable("signos_vitales");

                entity.Property(e => e.IdSigno).HasColumnName("Id_Signo");

                entity.Property(e => e.DescripSignoVital)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Descrip_SignoVital");

                entity.Property(e => e.RangoMax).HasColumnName("Rango_Max");

                entity.Property(e => e.RangoMin).HasColumnName("Rango_Min");
            });

            modelBuilder.Entity<Sugerencia>(entity =>
            {
                entity.HasKey(e => e.IdSugerencia)
                    .HasName("PK__sugerenc__6E863219084126B6");

                entity.ToTable("sugerencias");

                entity.Property(e => e.IdSugerencia).HasColumnName("Id_Sugerencia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Pa__671F4F74");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Me__681373AD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
