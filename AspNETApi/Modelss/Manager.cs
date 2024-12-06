using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
