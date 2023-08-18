using NewsLott.DAL.Repositorio.Interfaces;

using NewsLott.Entidades;


namespace NewsLott.DAL.Repositorio.Implementacion
{
    public class ResultadoLoteriaRepositorio : RepositorioGenerico<ResultadoDeLoteria>, IResultadoLoteriaRepositorio
    {
        public ResultadoLoteriaRepositorio(NewsLottDbContext context) : base(context)
        {            
        }

    }
}
