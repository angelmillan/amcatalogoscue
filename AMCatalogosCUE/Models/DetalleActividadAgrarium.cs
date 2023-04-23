using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class DetalleActividadAgrarium
{
    public int Codigo { get; set; }

    public string? ActividadAgraria { get; set; }

    public int SubCodigo { get; set; }

    public string? Ambito { get; set; }

    public string? DetalleActividadAgraria { get; set; }

    public string? Observaciones { get; set; }
}
