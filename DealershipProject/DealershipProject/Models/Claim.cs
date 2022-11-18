using System;
using System.Collections.Generic;

namespace DealershipProject.Models;

public partial class Claim
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly Date { get; set; }

    public Guid VehicleId { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
