using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class ProductoVariedadEspecieTipo
{
    public int Codigo { get; set; }

    public string? Producto { get; set; }

    public int CodigoVariedad { get; set; }

    public string? VariedadEspecieTipo { get; set; }

    public string? Observaciones { get; set; }
}
