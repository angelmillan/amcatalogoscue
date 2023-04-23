using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class Senp
{
    public int CodigoSiex { get; set; }

    public string? Codigo { get; set; }

    public string? Tipo { get; set; }

    public string? Bcam8 { get; set; }

    public string? Edb { get; set; }

    public string? Ess { get; set; }

    public string? Eepp { get; set; }

    public string? Delimitacion { get; set; }

    public string? FactorConversion { get; set; }

    public double? FactorPonderacion { get; set; }

    public double? SuperficieEquivalente { get; set; }

    public string? Obsevaciones { get; set; }
}
