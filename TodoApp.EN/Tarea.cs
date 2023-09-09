using System;
using System.Collections.Generic;

namespace TodoApp.EN;

public partial class Tarea
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Completada { get; set; }
}
