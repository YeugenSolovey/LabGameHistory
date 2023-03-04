using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class GameInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GameCompaniId { get; set; }

    public string GameDesigner { get; set; } = null!;

    public string MainCharacter { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int YearRelease { get; set; }

    public virtual GameCompani GameCompani { get; set; } = null!;

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
