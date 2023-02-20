using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Passport
{
    public int Id { get; set; }

    public string Series { get; set; } = null!;

    public string Number { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
