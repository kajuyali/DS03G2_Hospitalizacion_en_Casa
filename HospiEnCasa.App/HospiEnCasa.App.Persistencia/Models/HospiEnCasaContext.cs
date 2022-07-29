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
            modelBuilder.Entity<Asignado>(entity =>
            {
                entity.HasKey(e => e.IdAsignado)
                    .HasName("PK__asignado__123B78A9D5C9D9BE");

                entity.ToTable("asignado");

                entity.Property(e => e.IdAsignado).HasColumnName("Id_Asignado");

                entity.Property(e => e.IdEnfermero).HasColumnName("Id_Enfermero");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.HasOne(d => d.IdEnfermeroNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdEnfermero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Enf__3493CFA7");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Med__3587F3E0");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Pac__339FAB6E");
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.HasKey(e => e.IdEnfer)
                    .HasName("PK__enfermer__3E83A9A21E47336A");

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
                    .HasConstraintName("FK__enfermero__Id_Pe__208CD6FA");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.HasKey(e => e.IdFamiliar)
                    .HasName("PK__familiar__1A3975817FFC1F3D");

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
                    .HasConstraintName("FK__familiar__Id_Pac__236943A5");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__Id_Per__245D67DE");
            });

            modelBuilder.Entity<Historium>(entity =>
            {
                entity.HasKey(e => e.IdHistoria)
                    .HasName("PK__historia__7DBFFDCDB5851F3C");

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
                    .HasConstraintName("FK__historia__Id_Pac__2739D489");

                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("Fecha");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__7BA5D810F8F40E16");

                entity.ToTable("medico");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

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
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__Id_Perso__1AD3FDA4");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPac)
                    .HasName("PK__paciente__51E3D4C079873DFA");

                entity.ToTable("paciente");

                entity.Property(e => e.IdPac).HasColumnName("Id_Pac");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__Id_Per__1DB06A4F");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__C95634AF4170690E");

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

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SignosPaciente>(entity =>
            {
                entity.HasKey(e => e.IdSignoPaciente)
                    .HasName("PK__signos_p__690ACC1929F3901E");

                entity.ToTable("signos_pacientes");

                entity.Property(e => e.IdSignoPaciente).HasColumnName("Id_SignoPaciente");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.IdSigno).HasColumnName("Id_Signo");

                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("Fecha");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Pa__395884C4");

                entity.HasOne(d => d.IdSignoNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdSigno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Si__3864608B");
            });

            modelBuilder.Entity<SignosVitale>(entity =>
            {
                entity.HasKey(e => e.IdSigno)
                    .HasName("PK__signos_v__EFF6D61F52C33A48");

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
                    .HasName("PK__sugerenc__6E863219567B6325");

                entity.ToTable("sugerencias");

                entity.Property(e => e.IdSugerencia).HasColumnName("Id_Sugerencia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdHistoria).HasColumnName("Id_Historia");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.HasOne(d => d.IdHistoriaNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdHistoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Hi__3C34F16F");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Me__3D2915A8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
