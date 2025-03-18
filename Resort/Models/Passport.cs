using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class Passport
{
    public int PassId { get; set; }

    public int? PassOwner { get; set; }

    public string? PassSeria { get; set; }

    public string? PassNumber { get; set; }

    public virtual Client? PassOwnerNavigation { get; set; }
}
