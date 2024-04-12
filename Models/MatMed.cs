using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace apisaude.Models;

public partial class MatMed
{
    public int CodMed { get; set; }

    public string NomeMatmed { get; set; } = null!;

    public int? CodFab { get; set; }

    public string? UnidadeMedida { get; set; }

    public int? CodClasse { get; set; }
[JsonIgnore]
    public virtual ClassMed? CodClasseNavigation { get; set; }
[JsonIgnore]
    public virtual Fabricante? CodFabNavigation { get; set; }

    public virtual ICollection<Entrega> Entregas { get; } = new List<Entrega>();
}
