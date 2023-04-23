using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class HerramientasDigitale
{
    public int? CodigoSiex { get; set; }

    public string? NombreComercialHeramienta { get; set; }

    public string? Entidad { get; set; }

    public string? Sector { get; set; }

    public string? SubSector { get; set; }

    public string? TecnologiaFuncionalidad { get; set; }

    public double? AlcanceNumeroAgricultores { get; set; }

    public string? Observaciones { get; set; }
}
