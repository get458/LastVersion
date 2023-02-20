using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public int? CarId { get; set; }

    public string Color { get; set; } = null!;

    public int Count { get; set; }

    public decimal Price { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Purсhase> Purсhases { get; } = new List<Purсhase>();
}
