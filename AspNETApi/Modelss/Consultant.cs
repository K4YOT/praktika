using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class Consultant
{
    public int ConsultantId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Consultation? Consultation { get; set; }
}
