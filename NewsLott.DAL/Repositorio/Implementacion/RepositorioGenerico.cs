using Microsoft.EntityFrameworkCore;
using NewsLott.DAL.Repositorio.Interfaces;

using System.Linq.Expressions;


namespace NewsLott.DAL.Repositorio.Implementacion
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly NewsLottDbContext _contexto;
        internal DbSet<T> _dbset;

        public RepositorioGenerico(NewsLottDbContext contexto)
        {
            this._contexto = contexto;
            _dbset = _contexto.Set<T>();
        }


        public async Task<T> AgregarAsync(T modelo)
        {
            await _dbset.AddAsync(modelo);

            try
            {
                await this.GuardarCambiosAsync();
                return modelo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> AgregarRangoAsync(List<T> modelo)
        {
            await _dbset.AddRangeAsync(modelo);

            try
            {
                await this.GuardarCambiosAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> consulta;

            if (filtro == null)
            {
                consulta = _dbset.AsQueryable();
            }
            else
            {
                consulta = _dbset.Where(filtro).AsQueryable();
            }

            return consulta;
        }

        public async Task<bool> Editar(T modelo)
        {         
            _dbset.Update(modelo);

            try
            {
                await this.GuardarCambiosAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        public async Task<bool> EliminarAsync(T modelo)
        {
            try
            {
                var resultado = _dbset.Remove(modelo);
                await this.GuardarCambiosAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T?> ObtenerAsync(Expression<Func<T, bool>> filtro)
        {
            try
            {
                return await _dbset.FirstOrDefaultAsync(filtro);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<List<T>?> ObtenerTodoAsync()
        {
            try
            {
                return await _dbset.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<int?> GuardarCambiosAsync()
        {
            try
            {
                return await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
