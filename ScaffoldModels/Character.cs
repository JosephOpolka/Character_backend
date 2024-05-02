using System;
using System.Collections.Generic;

namespace Character_backend.ScaffoldModels;

public partial class Character
{
    public int CharacterId { get; set; }

    public string? Name { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Height { get; set; }

    public string? Race { get; set; }

    public string? HairColor { get; set; }

    public string? EyeColor { get; set; }

    public string? FavoriteColor { get; set; }

    public string? Occupation { get; set; }

    public string? Hobbies { get; set; }
}
