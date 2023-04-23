using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class RegimenesCalidad
{
    public int IdTipoIg { get; set; }

    public string? TipoIigg { get; set; }

    public int IdIigg { get; set; }

    public string? IiggnombreComercial { get; set; }

    public string? NumeroExpedienteUe { get; set; }

    public int IdCategoria { get; set; }

    public string? Categoria { get; set; }

    public int IdClase { get; set; }

    public string? Clase { get; set; }

    public int IdSubclase { get; set; }

    public string? SubClase { get; set; }

    public string? InecodigoCa { get; set; }

    public string? IneCa { get; set; }

    public string? AmbitoTerritorial { get; set; }

    public string? IdIgCcaa { get; set; }

    public string? IgCcaa { get; set; }

    public string? InecodigoProvincia { get; set; }

    public string? Ineprovincia { get; set; }

    public string? Dgcexplotacion { get; set; }
}
