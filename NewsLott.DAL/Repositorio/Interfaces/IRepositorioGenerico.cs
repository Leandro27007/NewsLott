using System.Linq.Expressions;

namespace NewsLott.DAL.Repositorio.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<T?> ObtenerAsync(Expression<Func<T, bool>> filtro);
        Task<List<T>?> ObtenerTodoAsync();
        Task<T> AgregarAsync(T modelo);
        Task<bool> Editar(T modelo);
        Task<bool> EliminarAsync(T modelo);
        Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null);
        Task<int?> GuardarCambiosAsync();
        Task<bool> AgregarRangoAsync(List<T> modelo);
    }
}
