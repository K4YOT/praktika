using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Consultation? Consultation { get; set; }

    public virtual Order? Order { get; set; }
}
