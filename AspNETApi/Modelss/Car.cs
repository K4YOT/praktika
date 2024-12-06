using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class Car
{
    public int CarId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int YearOfIssue { get; set; }

    public string Body { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Engine { get; set; } = null!;

    public string Box { get; set; } = null!;

    public int Ownership { get; set; }

    public int Price { get; set; }

    public bool Isreserved { get; set; }

    public virtual Consultation? Consultation { get; set; }

    public virtual Order? OrderCar { get; set; }

    public virtual Order? OrderPriceNavigation { get; set; }
}
