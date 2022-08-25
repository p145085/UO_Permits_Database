using System;

namespace UO_Permits_Database
{
    public class Server
    {
        public string Id { get; set; }
        public string? Name { get; set; } // (i.e "Ultima Online Second Age").
        public string? Abbreviation { get; set; } // (i.e "UOSA", "UOO", "UOF", "UOR").
        public string? WebsiteURL { get; set; }
        public string? ForumsURL { get; set; }
        public string? DiscordURL { get; set; }
        public string? ExpansionRuleset { get; set; } // (i.e "T2A", "UOR", "AoS").
        public DateOnly? ShardLaunch { get; set; } // Date the server launched.

        public Server(string Name, string Abbr, string WebURL, string ForumsURL, string DiscordURL, string ExpRules, DateOnly? shardLaunch)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Abbreviation = Abbr;
            this.WebsiteURL = WebURL;
            this.ForumsURL = ForumsURL;
            this.DiscordURL = DiscordURL;
            this.ShardLaunch = shardLaunch;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Name: " + this.Name + "\n"
                    + "Abbreviation: " + this.Abbreviation + "\n"
                    + "Website: " + this.WebsiteURL + "\n"
                    + "Forums: " + this.ForumsURL + "\n"
                    + "Discord: " + this.DiscordURL + "\n"
                    + "ShardLaunch: " + this.ShardLaunch + "\n";
        }

    }
}