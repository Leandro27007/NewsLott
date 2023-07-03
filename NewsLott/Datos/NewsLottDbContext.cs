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
        DbSet<EstadoResultado> estadoResultado { get; set; }
        DbSet<EstadoConsumidor> estadoConsumidor { get; set; }
        DbSet<Consumidor> consumidor { get; set; }


    }
}
