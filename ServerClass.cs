using System;

namespace UO_Permits_Database
{
    public class Server
    {
        public int Id { get; set; }
        public string? Name { get; set; } // (i.e "Ultima Online Second Age").
        public string? Abbreviation { get; set; } // (i.e "UOSA", "UOO", "UOF", "UOR").
        public string? WebsiteURL { get; set; }
        public string? ForumsURL { get; set; }
        public string? DiscordURL { get; set; }
        public string? ExpansionRuleset { get; set; } // (i.e "T2A", "UOR", "AoS").

        public Server()
        {
        }
    }
}