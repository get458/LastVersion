using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Carmodel
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
