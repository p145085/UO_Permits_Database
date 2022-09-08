using Newtonsoft.Json;
using System;

namespace UO_Permits_Database.Classes
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
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Abbreviation = Abbreviation;
            WebsiteURL = WebURL;
            this.ForumsURL = ForumsURL;
            this.DiscordURL = DiscordURL;
            ShardLaunch = shardLaunch;
        }

        public override string ToString()
        {
            return "ID: " + Id + "\n"
                    + "Name: " + Name + "\n"
                    + "Abbreviation: " + Abbreviation + "\n"
                    + "Website: " + WebsiteURL + "\n"
                    + "Forums: " + ForumsURL + "\n"
                    + "Discord: " + DiscordURL + "\n"
                    + "ShardLaunch: " + ShardLaunch + "\n";
        }

        public static void forEachServer(List<Server> allServers)
        {
            foreach (Server server in allServers)
            {
                if (server.Equals(null))
                {
                    throw new InvalidOperationException("selected server was null.");
                }
                string url = MainMethod.fullPath + "/json/servers.json";
                string serialized = JsonConvert.SerializeObject(server, Formatting.Indented);

                //Console.WriteLine(guild.ToString());

                if (!File.Exists(url)) // If file NOT found.
                {
                    Console.WriteLine("First snapshot created at: " + DateTime.Now);
                    File.WriteAllText(url, serialized);
                }
                else if (File.Exists(url)) // If file found.
                {
                    Console.WriteLine("Snapshot created at: " + DateTime.Now);
                    File.AppendAllText(url, serialized);
                }
            }
        }
    }
}