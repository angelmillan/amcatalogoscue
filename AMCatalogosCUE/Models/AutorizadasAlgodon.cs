using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class AutorizadasAlgodon
{
    public int CodigoAsociacion { get; set; }

    public string? Nif { get; set; }

    public string? RazonSocial { get; set; }

    public string? Detalle { get; set; }

    public string? AutoridadCompetente { get; set; }
}
