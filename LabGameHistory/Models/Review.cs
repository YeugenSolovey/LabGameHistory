using System;
using System.Collections.Generic;

namespace LabGameHistory.Models;

public partial class Review
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int Score { get; set; }

    public string Review1 { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
