using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DAL.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insertar(TEntityModel model);
        Task<bool> Eliminar(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
        Task<bool> CambiarEstado(int id);

    }
}
