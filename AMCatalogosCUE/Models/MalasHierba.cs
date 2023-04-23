using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class MalasHierba
{
    public string Codigo { get; set; } = null!;

    public string? Categoria { get; set; }

    public string? NombreCientifico { get; set; }

    public string? Eppocd { get; set; }

    public string? Observaciones { get; set; }
}
