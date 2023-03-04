using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class Genre
{
    public int Id { get; set; }

    public int RecomendYear { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GameGenre> GameGenres { get; } = new List<GameGenre>();
}
