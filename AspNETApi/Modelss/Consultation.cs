using System;
using System.Collections.Generic;

namespace AspNETApi.Modelss;

public partial class Consultation
{
    public int ConsultationId { get; set; }

    public int? ConsultantId { get; set; }

    public int? UserId { get; set; }

    public int? CarId { get; set; }

    public DateOnly Date { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Consultant? Consultant { get; set; }

    public virtual User? User { get; set; }
}
