using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Car
{
    public int Id { get; set; }

    public string CarName { get; set; } = null!;

    public int? MoedlId { get; set; }

    public virtual Carmodel? Moedl { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
