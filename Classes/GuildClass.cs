using Newtonsoft.Json;
using System;

namespace UO_Permits_Database
{
    public class Guild
    {
        public string Id { get; set; }
        public string? Name { get; set; } // Names of Guild. (i.e "chumbucket & Associates").
        public string? Tag { get; set; } // Tag of Guild. (i.e "[cA]").
        //public List<Character>? Members { get; set; } = new List<Character>(); // List of characters.
        public List<int[][]>? GuildHouseLocation { get; set; } = new List<int[][]>(); // X and Y coordinates.
        public Server? GuildHouseServer { get; set; } // Assign what server house is on.

        public Guild()
        {
            Id = UtilityClass.createUUID();
        }
        public Guild(string Name, string Tag)
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Tag = Tag;
        }
        public Guild(string Name, string Tag, List<Character> Members)
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Tag = Tag;
            //this.Members = Members;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Names: " + this.Name + "\n"
                    + "Tag: " + this.Tag + "\n"
                    //+ "Members: " + this.Members + "\n"
                    + "Guild-house location: " + this.GuildHouseLocation + "\n"
                    + "Guild-house server: " + this.GuildHouseServer + "\n"
                    ;
        }

        static public void printAllGuilds(List<Guild> allGuildsList)
        {
            Console.WriteLine("**Beginning output of list of all guilds.**");
            foreach (Guild guild in allGuildsList)
            {
                Console.WriteLine(guild.Name);
            }
            Console.WriteLine("**Finished outputting list of all guilds.**");

        }

        static public void forEachGuild(List<Guild> allGuilds)
        {
            foreach (Guild guild in allGuilds)
            {
                if (guild.Equals(null))
                {
                    throw new InvalidOperationException("selected guild was null.");
                }
                string url = MainMethod.fullPath + "/json/guilds.json";
                string serialized = JsonConvert.SerializeObject(guild, Formatting.Indented);
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