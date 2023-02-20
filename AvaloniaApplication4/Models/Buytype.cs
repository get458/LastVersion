using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Buytype
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Purсhase> Purсhases { get; } = new List<Purсhase>();
}
