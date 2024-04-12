using System;
using System.Collections.Generic;

namespace apisaude.Models;

public partial class Medico
{
    public int CodMed { get; set; }

    public int CodCrm { get; set; }

    public String? NomeMedico { get; set; } 

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();
}
