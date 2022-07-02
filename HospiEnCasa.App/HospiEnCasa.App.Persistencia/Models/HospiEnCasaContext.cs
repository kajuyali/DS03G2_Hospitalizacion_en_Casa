using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

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

        
        // Repositorio de configuracion
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
                    .HasName("PK__asignado__123B78A96DC03B15");

                entity.ToTable("asignado");

                entity.Property(e => e.IdAsignado).HasColumnName("Id_Asignado");

                entity.Property(e => e.IdEnfermero).HasColumnName("Id_Enfermero");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.HasOne(d => d.IdEnfermeroNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdEnfermero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Enf__05D8E0BE");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Med__06CD04F7");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Asignados)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignado__Id_Pac__04E4BC85");
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.HasKey(e => e.IdEnfer)
                    .HasName("PK__enfermer__3E83A9A29445873E");

                entity.ToTable("enfermero");

                entity.Property(e => e.IdEnfer).HasColumnName("Id_Enfer");

                entity.Property(e => e.DocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Documento_Persona");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Registro)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentoPersonaNavigation)
                    .WithMany(p => p.Enfermeros)
                    .HasForeignKey(d => d.DocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermero__Docum__75A278F5");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.HasKey(e => e.IdFamiliar)
                    .HasName("PK__familiar__1A39758151501D23");

                entity.ToTable("familiar");

                entity.Property(e => e.IdFamiliar).HasColumnName("Id_Familiar");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Documento_Persona");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentoPersonaNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.DocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__Docume__0A9D95DB");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__familiar__Id_Pac__09A971A2");
            });

            modelBuilder.Entity<Historium>(entity =>
            {
                entity.HasKey(e => e.IdHistoria)
                    .HasName("PK__historia__7DBFFDCD99A26EE1");

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
                    .HasConstraintName("FK__historia__Id_Pac__787EE5A0");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__7BA5D8100A446711");

                entity.ToTable("medico");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.DocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Documento_Persona");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Registro)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentoPersonaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.DocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__Document__6D0D32F4");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPac)
                    .HasName("PK__paciente__51E3D4C06887E162");

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

                entity.Property(e => e.DocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Documento_Persona");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentoPersonaNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.DocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__Docume__6FE99F9F");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Documento)
                    .HasName("PK__persona__A25B3E601D7EC475");

                entity.ToTable("persona");

                entity.Property(e => e.Documento)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<SignosPaciente>(entity =>
            {
                entity.HasKey(e => e.IdSignoPaciente)
                    .HasName("PK__signos_p__690ACC197D945261");

                entity.ToTable("signos_pacientes");

                entity.Property(e => e.IdSignoPaciente).HasColumnName("Id_SignoPaciente");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

                entity.Property(e => e.IdSigno).HasColumnName("Id_Signo");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Pa__02084FDA");

                entity.HasOne(d => d.IdSignoNavigation)
                    .WithMany(p => p.SignosPacientes)
                    .HasForeignKey(d => d.IdSigno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__signos_pa__Id_Si__01142BA1");
            });

            modelBuilder.Entity<SignosVitale>(entity =>
            {
                entity.HasKey(e => e.IdSigno)
                    .HasName("PK__signos_v__EFF6D61FD2C8534C");

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
                    .HasName("PK__sugerenc__6E863219EB8ECE3B");

                entity.ToTable("sugerencias");

                entity.Property(e => e.IdSugerencia).HasColumnName("Id_Sugerencia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdHistoria).HasColumnName("Id_Historia");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.HasOne(d => d.IdHistoriaNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdHistoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Hi__7B5B524B");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sugerenci__Id_Me__7C4F7684");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
