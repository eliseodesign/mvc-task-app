using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.EN;

namespace TodoApp.BLL.Service
{
    public interface ITareaService
    {
        Task<bool> Insertar(Tarea model);
        Task<bool> Eliminar(int id);
        Task<IQueryable<Tarea>> ObtenerTodos();
    }
}
