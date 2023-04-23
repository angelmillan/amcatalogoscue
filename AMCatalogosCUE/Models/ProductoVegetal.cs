using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class ProductoVegetal
{
    public string Codigo { get; set; } = null!;

    public string? Producto { get; set; }

    public string? CodigoSiex { get; set; }

    public string? ProductoSiex { get; set; }

    public string? ObservacionesTragsaTec { get; set; }
}
