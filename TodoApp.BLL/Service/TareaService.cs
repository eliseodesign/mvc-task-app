using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Repositories;
using TodoApp.EN;

namespace TodoApp.BLL.Service
{
    public class TareaService : ITareaService
    {

        private readonly IGenericRepository<Tarea> _repo;
        public TareaService(IGenericRepository<Tarea> repo)
        {
            _repo = repo;
        }
        public async Task<bool> Eliminar(int id)
        {
            return await _repo.Eliminar(id);
        }

        public async Task<bool> Insertar(Tarea model)
        {
            return await _repo.Insertar(model);
        }

        public async Task<IQueryable<Tarea>> ObtenerTodos()
        {
            return await _repo.ObtenerTodos();
        }
    }
}
