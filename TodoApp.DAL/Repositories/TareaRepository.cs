using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.DataContext;
using TodoApp.EN;

namespace TodoApp.DAL.Repositories
{
    public class TareaRepository : IGenericRepository<Tarea>
    {
        private readonly MvcTodoContext _dbContext; 
        public TareaRepository(MvcTodoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Eliminar(int id)
        {
            Tarea tarea = _dbContext.Tareas.First(t => t.Id == id);
            _dbContext.Tareas.Remove(tarea);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Tarea model)
        {
            _dbContext.Tareas.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Tarea>> ObtenerTodos()
        {
            IQueryable<Tarea> query = _dbContext.Tareas;
            return query;
        }
    }
}
