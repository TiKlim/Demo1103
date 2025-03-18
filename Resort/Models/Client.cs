using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? ClientName { get; set; }

    public string? ClientCode { get; set; }

    public DateOnly? ClientBirthday { get; set; }

    public string? ClientAdres { get; set; }

    public string? ClientEmail { get; set; }

    public string? ClientPassword { get; set; }

    public virtual ICollection<Passport> Passports { get; set; } = new List<Passport>();
}
