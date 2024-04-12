using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace apisaude.Models;

public partial class Paciente
{
    public int? CodPaciente { get; set; }

    public int? Cpf { get; set; }

    public String? NomePaciente { get; set; } = null!;

    public int? CartaoSus { get; set; }

    public String? Rua { get; set; }

    public int? NumeroCasa { get; set; }

    public String? Bairro { get; set; }

    public String? Cidade { get; set; }

    public int? Telefone { get; set; }

    public String? Email { get; set; } = null!;

    public int? CodMed { get; set; }
[JsonIgnore]
    public virtual Medico? CodMedNavigation { get; set; }

    public virtual ICollection<Entrega> Entregas { get; } = new List<Entrega>();
}
