using System;
using System.Collections.Generic;

namespace TMECANICO.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Numero { get; set; }

    public string? Direccion { get; set; }

    public int? IdVehiculo { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
