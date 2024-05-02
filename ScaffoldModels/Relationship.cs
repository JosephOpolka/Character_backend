using System;
using System.Collections.Generic;

namespace Character_backend.ScaffoldModels;

public partial class Relationship
{
    public int RelationshipId { get; set; }

    public int? CharacterId1 { get; set; }

    public int? CharacterId2 { get; set; }

    public string? RelationshipStatus { get; set; }
}
