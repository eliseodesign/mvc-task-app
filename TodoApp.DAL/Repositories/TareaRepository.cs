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

        public async Task<bool> CambiarEstado(int id)
        {
            try
            {
                // Obtener la tarea por su ID
                Tarea tarea = await _dbContext.Tareas.FindAsync(id);

                if (tarea == null)
                {
                    // Si la tarea no se encuentra, retorna falso (no se pudo cambiar el estado)
                    return false;
                }

                // Cambiar el estado de Completada (si es true, cambiará a false, y viceversa)
                tarea.Completada = !tarea.Completada;

                // Guardar los cambios en la base de datos
                await _dbContext.SaveChangesAsync();

                // Retorna true (cambio de estado exitoso)
                return true;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí y retornar false en caso de error
                return false;
            }
        }
    }
}
