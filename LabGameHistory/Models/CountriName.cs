using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class CountriName
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<GameCompani> GameCompanis { get; } = new List<GameCompani>();
}
