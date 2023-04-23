using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class AgrupacionesGip
{
    public string? CodigoAsociacion { get; set; }

    public string Nif { get; set; } = null!;

    public string? RazonSocial { get; set; }

    public string? Detalle { get; set; }

    public string? Ca { get; set; }
}
