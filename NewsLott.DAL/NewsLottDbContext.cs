using NewsLott.Entidades;
using Microsoft.EntityFrameworkCore;

namespace NewsLott.DAL
{
    public class NewsLottDbContext : DbContext
    {
        public NewsLottDbContext(DbContextOptions<NewsLottDbContext> opciones) : base(opciones)
        {

        }

        DbSet<CompaniaDeLoteria> companiaDeLoteria { get; set; }
        DbSet<Loteria> loteria { get; set; }
        DbSet<ResultadoDeLoteria> resultadoDeLoteria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //El Id de la loteria sera el nombre de la loteria y en cada espacio se sustituira por un guin bajo


            List<CompaniaDeLoteria> listaCompania = new()
            {
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "nacional",
                    NombreCompania = "Nacional"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "leidsa",
                    NombreCompania = "Leidsa"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "real",
                    NombreCompania = "Real"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "loteka",
                    NombreCompania = "Loteka"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "americanas",
                    NombreCompania = "Americanas"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "la_suerte",
                    NombreCompania = "La Suerte"
                },
                new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "king_lottery",
                    NombreCompania = "King Lottery"
                },new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "anguila",
                    NombreCompania = "Anguila"
                },new CompaniaDeLoteria
                {
                    IdCompaniaDeLoteria = "primera",
                    NombreCompania = "Primera"
                },
            };


            List<Loteria> listaLoteria = new List<Loteria>()
            {
                new Loteria()
                {
                    IdLoteria = "gana_mas",
                    IdCompaniaDeLoteria = "nacional",
                    NombreLoteria = "Gana Mas",
                    FechaRegistro = DateTime.Now
                },
                new Loteria()
                {
                    IdLoteria = "loteria_nacional",
                    IdCompaniaDeLoteria = "nacional",
                    NombreLoteria = "Loteria Nacional",
                    FechaRegistro = DateTime.Now
                },
                new Loteria()
                {
                    IdLoteria = "juega_+_pega_+",
                    IdCompaniaDeLoteria = "nacional",
                    NombreLoteria = "Juega + Pega +",
                    FechaRegistro = DateTime.Now
                },
                new Loteria()
                {
                    IdLoteria = "pega_3_mas",
                    IdCompaniaDeLoteria = "leidsa",
                    NombreLoteria = "Pega 3 Mas",
                    FechaRegistro = DateTime.Now
                },
                 new Loteria()
                {
                    IdLoteria = "loto_pool",
                    IdCompaniaDeLoteria = "leidsa",
                    NombreLoteria = "Loto Pool",
                    FechaRegistro = DateTime.Now
                },
                 new Loteria()
                {
                    IdLoteria = "super_kino_tv",
                    IdCompaniaDeLoteria = "leidsa",
                    NombreLoteria = "Super Kino TV",
                    FechaRegistro = DateTime.Now
                },
                 new Loteria()
                {
                    IdLoteria = "quiniela_leidsa",
                    IdCompaniaDeLoteria = "leidsa",
                    NombreLoteria = "Quiniela Leidsa",
                    FechaRegistro = DateTime.Now
                },
                 new Loteria()
                {
                    IdLoteria = "loto_loto_mas",
                    IdCompaniaDeLoteria = "leidsa",
                    NombreLoteria = "Loto Mas",
                    FechaRegistro = DateTime.Now
                },
            };


            List<Loteria> listaLoteria2 = new()
            {
                 
                 new Loteria()
                {
                    IdLoteria = "quiniela_real",
                    IdCompaniaDeLoteria = "real",
                    NombreLoteria = "Quiniela Real"
                },new Loteria()
                {
                    IdLoteria = "real_loto_pool",
                    IdCompaniaDeLoteria = "real",
                    NombreLoteria = "Loto Pool",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "loto_real",
                    IdCompaniaDeLoteria = "real",
                    NombreLoteria = "Loto Real",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "quiniela_loteka",
                    IdCompaniaDeLoteria = "loteka",
                    NombreLoteria = "Quiniela Loteka",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "mega_chances",
                    IdCompaniaDeLoteria = "loteka",
                    NombreLoteria = "Mega Chance",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "new_york_3:30",
                    IdCompaniaDeLoteria = "americanas",
                    NombreLoteria = "New York 3:30",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "new_york_11:30",
                    IdCompaniaDeLoteria = "americanas",
                    NombreLoteria = "New York 11:30",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "florida_dia",
                    IdCompaniaDeLoteria = "americanas",
                    NombreLoteria = "Florida Dia",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "florida_noche",
                    IdCompaniaDeLoteria = "americanas",
                    NombreLoteria = "Florida Noche",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "la_primera",
                    IdCompaniaDeLoteria = "primera",
                    NombreLoteria = "La Primera",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "primera_noche",
                    IdCompaniaDeLoteria = "primera",
                    NombreLoteria = "La Primera Noche",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "loto_5",
                    IdCompaniaDeLoteria = "primera",
                    NombreLoteria = "Loto 5",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "la_suerte_md",
                    IdCompaniaDeLoteria = "la_suerte",
                    NombreLoteria = "La Suerte Medio Dia",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "la_suerte_6pm",
                    IdCompaniaDeLoteria = "la_suerte",
                    NombreLoteria = "La Suerte 6PM",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "quiniela_12:30",
                    IdCompaniaDeLoteria = "king_lottery",
                    NombreLoteria = "Quiniela 12:13",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "quiniela_7:30",
                    IdCompaniaDeLoteria = "king_lottery",
                    NombreLoteria = "Quiniela 7:30",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "anguila_10:30_am",
                    IdCompaniaDeLoteria = "anguila",
                    NombreLoteria = "Anguila 10:30 AM",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "anguila_1:00_pm",
                    IdCompaniaDeLoteria = "anguila",
                    NombreLoteria = "Anguila 1:00 PM",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "anguila_6:00_pm",
                    IdCompaniaDeLoteria = "anguila",
                    NombreLoteria = "Anguila 6:00 PM",
                    FechaRegistro = DateTime.Now
                },new Loteria()
                {
                    IdLoteria = "anguila_9:00_pm",
                    IdCompaniaDeLoteria = "anguila",
                    NombreLoteria = "Anguila 9:00 PM",
                    FechaRegistro = DateTime.Now
                }
            };


            modelBuilder.Entity<CompaniaDeLoteria>()
                        .HasData(listaCompania);
            modelBuilder.Entity<Loteria>()
                        .HasData(listaLoteria);

            modelBuilder.Entity<Loteria>()
                        .HasData(listaLoteria2);


            base.OnModelCreating(modelBuilder);
        }


    }
}
