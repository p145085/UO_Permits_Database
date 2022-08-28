using Newtonsoft.Json;
using System;
using UO_Permits_Database;

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

        public Server(string Name, string Abbreviation, string WebURL, string ForumsURL, string DiscordURL, string ExpRules, DateOnly? shardLaunch)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Abbreviation = Abbreviation;
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

        public static void forEachServer(List<Server> allServers)
        {
            foreach (Server server in allServers)
            {
                if (server.Equals(null))
                {
                    throw new InvalidOperationException("selected server was null.");
                }
                string url = MainMethod.fullPath + "servers.json";
                string serialized = JsonConvert.SerializeObject(server, Formatting.Indented);
                serialized = serialized + "\n";

                //Console.WriteLine(guild.ToString());

                if (!File.Exists(url)) // If file NOT found.
                {
                    Console.WriteLine("No previous file found, continuing with creation.");
                    File.WriteAllText(url, serialized);
                }
                else if (File.Exists(url)) // If file found.
                {
                    Console.WriteLine("Previous file found, appending current data.");
                    File.AppendAllText(url, serialized);
                }
            }
        }
    }
}