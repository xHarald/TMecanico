using System;
using System.Collections.Generic;

namespace TMECANICO.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Modelo { get; set; }

    public string? Color { get; set; }

    public string? Reparacion { get; set; }

    public int? IdMecanico { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Mecanicco? IdMecanicoNavigation { get; set; }
}
