using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class Enfermedade
{
    public int Id { get; set; }

    public string? NombreCientifico { get; set; }

    public string? Observaciones { get; set; }

    public string? Categoría { get; set; }

    public string? Codigo { get; set; }

    public string? EppoCd { get; set; }
}
