using Cine.ConexionSql;
using Microsoft.EntityFrameworkCore;
 using MySql.Data.MySqlClient;
using System.Linq;
using static Cine.ConexionSql.CadenaConexion;
using Cine.Dominio._4._1_Entidades;
using Cine.Dominio._4._1_Entidades.Entrada;
using Cine.Dominio._4._1_Entidades.Horarios;
using Cine.Dominio._4._1_Entidades.Pelicula;
using Cine.Dominio._4._1_Entidades.Sala;
using Cine.Dominio._4._2_MetaData.Cine;
using Cine.Dominio._4._2_MetaData;
using Cine.Dominio._4._2_MetaData.Entrada;
using Cine.Dominio._4._2_MetaData.Horarios;
using Cine.Dominio._4._2_MetaData.Pelicula;
using Cine.Dominio._4._2_MetaData.Sala;
using Cine.Dominio._4._2_MetaData.Usuario;
using Cine.Dominio._4._1_Entidades.Usuario;
using System.Threading.Tasks;
using System.Threading;

namespace Cine.Infraestructura
{
    public class Datacontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
             
            optionsBuilder.UseMySql(ObtenerCadenaConexionMySqlFirestore);
 
             base.OnConfiguring(optionsBuilder);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
               .GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Configuracion de las entidades

            //Cine

            modelBuilder.Entity<Dominio._4._1_Entidades.Cine.Cine>().HasMany(x => x.Salas)
                .WithOne(x => x.Cine).HasForeignKey(x => x.CineId).HasConstraintName("FK_Cine_Salas");

            //Cronograma

            modelBuilder.Entity<Dominio._4._1_Entidades.Cronograma>().HasOne(x => x.Dia)
                .WithMany(x => x.Cronogramas).HasForeignKey(x => x.DiaId).HasConstraintName("FK_Cronogramas_Dia");

            modelBuilder.Entity<Cronograma>().HasOne(x => x.Horarios)
                .WithMany(x => x.Cronogramas).HasForeignKey(x => x.HorarioId)
                .HasConstraintName("FK_Horario_Cronograma");

            modelBuilder.Entity<Cronograma>().HasOne(x => x.Funcion)
                .WithOne(x => x.Cronograma).HasForeignKey<Cronograma>(x => x.FuncionId).HasConstraintName("FK_Cronograma_Funcion");


            //Dia

            modelBuilder.Entity<Dia>().HasMany(x => x.Cronogramas)
                .WithOne(x => x.Dia).HasForeignKey(x => x.DiaId).HasConstraintName("FK_Dia_Cronogramas");

            //Entrada

            modelBuilder.Entity<Entrada>().HasOne(x => x.Funcion)
                .WithOne(x => x.Entrada).HasForeignKey<Funcion>(x => x.EntradaId).HasConstraintName("FK_Entrada_Funcion");

            //Funcion

            modelBuilder.Entity<Funcion>().HasOne(x => x.Entrada).WithOne(x => x.Funcion)
                .HasForeignKey<Funcion>(x => x.EntradaId).HasConstraintName("FK_Funcion_Entrada");

            modelBuilder.Entity<Funcion>().HasOne(x => x.Pelicula).WithMany(x => x.Funciones)
                .HasForeignKey(x => x.PeliculaId).HasConstraintName("FK_Funciones_Pelicula");

            modelBuilder.Entity<Funcion>().HasOne(x => x.Sala).WithMany(x => x.Funciones)
                .HasForeignKey(x => x.SalaId).HasConstraintName("FK_Funciones_Sala");

            modelBuilder.Entity<Funcion>().HasOne(x => x.Cronograma).WithOne(x => x.Funcion).HasForeignKey<Cronograma>(x => x.FuncionId)
                .HasConstraintName("FK_Funcion_Cronograma");

            //Horario

            modelBuilder.Entity<Horarios>().HasMany(x => x.Cronogramas).WithOne(x => x.Horarios)
                .HasForeignKey(x => x.HorarioId).HasConstraintName("FK_Horario_Cronogramas");

            //Pelicula

            modelBuilder.Entity<Pelicula>().HasMany(x => x.Funciones).WithOne(x => x.Pelicula)
                .HasForeignKey(x => x.PeliculaId).HasConstraintName("FK_Pelicula_Funciones");

            //Sala

            modelBuilder.Entity<Sala>().HasOne(x => x.Cine).WithMany(x => x.Salas).HasForeignKey(x => x.CineId)
                .HasConstraintName("FK_Salas_Pelicula");

            modelBuilder.Entity<Sala>().HasMany(x => x.Funciones)
                .WithOne(x => x.Sala)
                .HasForeignKey(x => x.SalaId)
                .HasConstraintName("FK_Sala_Funciones");


            //Aplicando Configuracion
            modelBuilder.ApplyConfiguration<Cine.Dominio._4._1_Entidades.Cine.Cine>(new CineMetaData());
            modelBuilder.ApplyConfiguration<Cronograma>(new CronogramaMetaData());
            modelBuilder.ApplyConfiguration<Dia>(new DiaMetaData());
            modelBuilder.ApplyConfiguration<Entrada>(new EntradaMetaData());
            modelBuilder.ApplyConfiguration<Funcion>(new FuncionMetaData());
            modelBuilder.ApplyConfiguration<Horarios>(new HorarioMetaData());
            modelBuilder.ApplyConfiguration<Pelicula>(new PeliculaMetaData());
            modelBuilder.ApplyConfiguration<Sala>(new SalaMetaData());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMetaData());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("EstaBorrado"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChangesAsync();
        }


        //Configurando el DBSet

        public DbSet<Dominio._4._1_Entidades.Cine.Cine> Cines;

        public DbSet<Cronograma> Cronogramas;

        public DbSet<Dia> Dias;

        public DbSet<Entrada> Entradas;

        public DbSet<Funcion> Funciones;

        public DbSet<Horarios> Horarios;

        public DbSet<Pelicula> Peliculas;

        public DbSet<Sala> Salas;

        public DbSet<Usuario> Usuarios;
    }
}
