using System;
using System.Collections.Generic;

namespace AvaloniaApplication4.Models;

public partial class Client
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientSurname { get; set; } = null!;

    public string ClientLastname { get; set; } = null!;

    public int? PassportId { get; set; }

    public string Address { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public virtual Passport? Passport { get; set; }
}
