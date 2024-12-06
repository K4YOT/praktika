using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class Order
{
    public int OrderId { get; set; }

    public int CarId { get; set; }

    public int? UserId { get; set; }

    public int Price { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Manager? Manager { get; set; }

    public virtual Car PriceNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
