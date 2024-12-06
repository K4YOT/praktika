using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class User
{
    public int user_id { get; set; }

    public string? Name { get; set; }

    public string? polic { get; set; }

    public string password { get; set; } = null!;

}
