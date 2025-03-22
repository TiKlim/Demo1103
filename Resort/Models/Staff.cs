using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;

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

    public string? StaffImage { get; set; }

    public virtual Post? StaffPostNavigation { get; set; }
    
    public Bitmap? Image => StaffImage != null ? new Bitmap($@"Assets\{StaffImage}") : null;

    public string? PostName
    {
        get
        {
            if (StaffPost == 1)
            {
                return "Продавец";
            }
            else if (StaffPost == 2)
            {
                return "Администратор";
            }
            else if (StaffPost == 3)
            {
                return "Старший смены";
            }

            return "не известно";
        }
    }
}
