using Cine.ConexionSql;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using MySql.Data.MySqlClient;
using static Cine.ConexionSql.CadenaConexion;

namespace Cine.Infraestructura
{
    public class Datacontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

             
            optionsBuilder.UseMySQL(ObtenerCadenaConexionMySqlFirestore);
 
             base.OnConfiguring(optionsBuilder);

        }


        protected override void OnModelCreating(ModelBuilder model)
        {

        }

    }
}
