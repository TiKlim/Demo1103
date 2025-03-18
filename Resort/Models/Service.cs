using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class Service
{
    public string? ServiceName { get; set; }

    public string? ServiceCode { get; set; }

    public decimal? ServiceCost { get; set; }

    public int ServiceId { get; set; }
}
