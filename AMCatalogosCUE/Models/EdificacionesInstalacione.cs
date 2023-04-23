using System;
using System.Collections.Generic;

namespace AMCatalogosCUE.Models;

public partial class EdificacionesInstalacione
{
    public int Codigo { get; set; }

    public string? Tipologia { get; set; }

    public int SubCodigo { get; set; }

    public string? EdificacionInstalacion { get; set; }
}
