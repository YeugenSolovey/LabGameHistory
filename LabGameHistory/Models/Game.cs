using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class Game
{
    public int Id { get; set; }

    public int GameInfoid { get; set; }

    public virtual ICollection<GameGenre> GameGenres { get; } = new List<GameGenre>();

    public virtual GameInfo GameInfo { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
