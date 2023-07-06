using Microsoft.EntityFrameworkCore;
using NewsLott.Datos.Modelos;
using System.ComponentModel;

namespace NewsLott.Datos
{
    public class NewsLottDbContext : DbContext
    {
        public NewsLottDbContext(DbContextOptions<NewsLottDbContext> opciones) : base(opciones)
        {

        }

        DbSet<Loteria> loteria { get; set; }
        DbSet<ResultadoQuiniela> resultadoQuiniela { get; set; }
        DbSet<EstadoConsumidor> estadoConsumidor { get; set; }
        DbSet<Consumidor> consumidor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Loteria> listaLoteria = new List<Loteria>() 
            { 
                new Loteria() 
                {
                    IdLoteria = "gana-mas",
                    NombreLoteria = "Gana Mas",
                    FechaRegistro = DateTime.Now
                },
                new Loteria()
                {
                    IdLoteria = "loteria-nacional",
                    NombreLoteria = "Loteria Nacional",
                    FechaRegistro = DateTime.Now
                }
            };


            modelBuilder.Entity<Loteria>()
                        .HasData(listaLoteria);


            base.OnModelCreating(modelBuilder);
        }


    }
}
