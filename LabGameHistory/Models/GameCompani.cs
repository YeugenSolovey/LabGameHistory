using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class GameCompani
{
    public int Id { get; set; }

    public string CompaniName { get; set; } = null!;

    public int CompaniCountryId { get; set; }

    public virtual CountriName CompaniCountry { get; set; } = null!;

    public virtual ICollection<GameInfo> GameInfos { get; } = new List<GameInfo>();
}
