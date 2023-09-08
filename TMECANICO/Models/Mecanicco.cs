using System;
using System.Collections.Generic;

namespace TMECANICO.Models;

public partial class Mecanicco
{
    public int IdMecanico { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public string? Horario { get; set; }

    public int? Reparaciones { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
