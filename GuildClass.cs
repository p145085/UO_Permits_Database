using Newtonsoft.Json;
using System;

namespace UO_Permits_Database
{
    public class Guild
    {
        public string Id { get; set; }
        public string? Name { get; set; } // Name of Guild. (i.e "chumbucket & Associates").
        public string? Tag { get; set; } // Tag of Guild. (i.e "[cA]").
        public List<Character>? Members { get; set; } // List of characters.

        public Guild()
        {
            this.Id = UtilityClass.createUUID();
        }
        public Guild(string Name, string Tag)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Tag = Tag;
        }
        public Guild(string Name, string Tag, List<Character> Members)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Tag = Tag;
            this.Members = Members;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Name: " + this.Name + "\n"
                    + "Tag: " + this.Tag + "\n"
                    + "Members: " + this.Members + "\n";
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
                string url = MainMethod.fullPath + "guilds.json";
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