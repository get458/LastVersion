using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Purсhase
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int? BuyTypeYd { get; set; }

    public virtual Buytype? BuyTypeYdNavigation { get; set; }

    public virtual Product? Product { get; set; }
}
