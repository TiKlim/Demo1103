using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class HistoryLogin
{
    public int IdLogin { get; set; }

    public string? UserLogin { get; set; }

    public string? UserName { get; set; }

    public DateTime? LoginDate { get; set; }

    public bool? LoginComplete { get; set; }
    
    public string CompleteLogin
    {
        get
        {
            if (LoginComplete == true)
            {
                return "Вход удачный";
            }
            else
            {
                return "Вход неудачный";
            }
        }
    }
}
