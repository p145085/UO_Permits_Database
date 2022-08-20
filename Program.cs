public class Player
{
    public int Id { get; set; }
    public Array? Names { get; set; } // Multiple nicknames should be possible.
    public Guild? Guilds { get; set; } // Multiple guilds should be possible.
    public Permit? Permits { get; set; } // Multiple permits should be possible.

}

public class Permit
{
    public int Id { get; set; }
    public string? Type { get; set; } // Issuer-written type of permit. (i.e "Sheep-shearing", "Farming in Deceit").
    public string? Description { get; set; } // Issuer-written message.
    public Player? PermitHolder { get; set; } // Single Player.
    public Player? PermitIssuer { get; set; } // Single Player.
    public DateTime PermitCreated { get; set; } = DateTime.Now; // Set to DateTime.Now;
    public DateTime PermitExpiration { get; set; } // Set to date of choice.
}

public class Guild
{
    public int Id { get; set; }
    public string? Name { get; set; } // Name of Guild. (i.e "chumbucket & Associates").
    public string? Tag { get; set; } // Tag of Guild. (i.e "[cA]").
    public Array? Members { get; set; } // Array of Players?
}

public class Server
{
    public int Id { get; set; }
    public string? Name { get; set; } // (i.e "Ultima Online Second Age").
    public string? Abbreviation { get; set; } // (i.e "UOSA", "UOO", "UOF", "UOR").
    public string? WebsiteURL { get; set; }
    public string? ForumsURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? ExpansionRuleset { get; set; } // (i.e "T2A", "UOR", "AoS").
}