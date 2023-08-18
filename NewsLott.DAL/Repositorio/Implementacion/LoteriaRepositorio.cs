using NewsLott.DAL.Repositorio.Interfaces;
using NewsLott.Entidades;

namespace NewsLott.DAL.Repositorio.Implementacion
{
    public class LoteriaRepositorio : RepositorioGenerico<Loteria>, ILoteriaRepositorio
    {
        public LoteriaRepositorio(NewsLottDbContext context) : base(context)
        {
            
        }


    }
}
