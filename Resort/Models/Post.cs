using System;
using System.Collections.Generic;

namespace Resort.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? PostTitle { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
