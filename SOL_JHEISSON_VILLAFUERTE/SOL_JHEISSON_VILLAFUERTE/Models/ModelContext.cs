using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SOL_JHEISSON_VILLAFUERTE.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<DetMatricula> DetMatricula { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=localhost)(Port=1521)))(CONNECT_DATA=(SID=xe))); User Id=BDEXAMENUPC;Password=Banco123");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BDEXAMENUPC")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => new { e.CodLineaNegocio, e.CodCurso })
                    .HasName("CURSO_PK");

                entity.ToTable("CURSO");

                entity.Property(e => e.CodLineaNegocio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COD_LINEA_NEGOCIO")
                    .IsFixedLength(true);

                entity.Property(e => e.CodCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COD_CURSO");

                entity.Property(e => e.DescCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESC_CURSO");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_CREACION");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.UsuarioCreador)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_CREADOR");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_MODIFICACION");
            });

            modelBuilder.Entity<DetMatricula>(entity =>
            {
                entity.HasKey(e => new { e.MatriculaIdMatricula, e.CursoCodLineaNegocio, e.CursoCodCurso })
                    .HasName("DET_MATRICULA_PK");

                entity.ToTable("DET_MATRICULA");

                entity.Property(e => e.MatriculaIdMatricula)
                    .HasPrecision(15)
                    .HasColumnName("MATRICULA_ID_MATRICULA");

                entity.Property(e => e.CursoCodLineaNegocio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURSO_COD_LINEA_NEGOCIO")
                    .IsFixedLength(true);

                entity.Property(e => e.CursoCodCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CURSO_COD_CURSO");

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_CREACION");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRUPO")
                    .IsFixedLength(true);

                entity.Property(e => e.Seccion)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SECCION");

                entity.Property(e => e.UsuarioCreador)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_CREADOR");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_MODIFICACION");

                entity.HasOne(d => d.MatriculaIdMatriculaNavigation)
                    .WithMany(p => p.DetMatricula)
                    .HasForeignKey(d => d.MatriculaIdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DET_MATRICULA_MATRICULA_FK");

                entity.HasOne(d => d.CursoCod)
                    .WithMany(p => p.DetMatricula)
                    .HasForeignKey(d => new { d.CursoCodLineaNegocio, d.CursoCodCurso })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DET_MATRICULA_CURSO_FK");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("MATRICULA_PK");

                entity.ToTable("MATRICULA");

                entity.Property(e => e.IdMatricula)
                    .HasPrecision(15)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MATRICULA");

                entity.Property(e => e.CodAlumno)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("COD_ALUMNO");

                entity.Property(e => e.CodLineaNegocio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COD_LINEA_NEGOCIO")
                    .IsFixedLength(true);

                entity.Property(e => e.CodModalEst)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COD_MODAL_EST")
                    .IsFixedLength(true);

                entity.Property(e => e.CodPeriodo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("COD_PERIODO")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_CREACION");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.UsuarioCreador)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_CREADOR");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_MODIFICACION");
            });

            modelBuilder.HasSequence("SEQ_MATALUMNO").IncrementsBy(10);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
