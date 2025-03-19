using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class HistoryLogin
{
    public int IdLogin { get; set; }

    public string? UserLogin { get; set; }

    public string? UserName { get; set; }
}
