using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class GameGenre
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int GenreId { get; set; }

    public virtual Game Genre { get; set; } = null!;

    public virtual Genre GenreNavigation { get; set; } = null!;
}
