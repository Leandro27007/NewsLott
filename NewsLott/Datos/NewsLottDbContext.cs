using Microsoft.EntityFrameworkCore;
using NewsLott.Datos.Modelos;

namespace NewsLott.Datos
{
    public class NewsLottDbContext : DbContext
    {
        public NewsLottDbContext(DbContextOptions<NewsLottDbContext> opciones) : base(opciones)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        DbSet<Loteria> loteria { get; set; }
        DbSet<ResultadoQuiniela> resultadoQuiniela { get; set; }


    }
}
