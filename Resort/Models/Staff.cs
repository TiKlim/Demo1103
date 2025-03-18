using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class Staff
{
    public string StaffId { get; set; } = null!;

    public int? StaffPost { get; set; }

    public string? StaffName { get; set; }

    public string? StaffLogin { get; set; }

    public string? StaffPassword { get; set; }

    public DateTime? StaffLastLogIn { get; set; }

    public bool? StaffLogInType { get; set; }

    public virtual Post? StaffPostNavigation { get; set; }
}
