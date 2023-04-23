using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class EntidadCertificacion
{
    public string CodigoAsociacion { get; set; } = null!;

    public string? Nif { get; set; }

    public string? RazonSocial { get; set; }

    public string? Detalle { get; set; }

    public string? ZonaControl { get; set; }
}
