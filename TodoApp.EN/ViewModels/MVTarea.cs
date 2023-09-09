using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.EN.ViewModels
{
    public class MVTarea
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public String? FechaRegistro { get; set; }

        public bool? Completada { get; set; }
    }
}
