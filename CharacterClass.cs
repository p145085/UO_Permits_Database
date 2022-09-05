using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UO_Permits_Database
{
    public class Character
    { // Make better sense of the distinction between 'Account' and 'Character'.
        public string? Id { get; set; } // Identifier.
        public List<string>? Names { get; set; } = new List<string>(); // In-game identifier.
        // Figure out how to link together a 'Name[i]' with a 'Template'. 
        public Guild? Guild { get; set; } // In-game guild identifier.
        public List<Permit>? Permits { get; set; } = new List<Permit>();
        public string? Template { get; set; } // (i.e Tankmage, blacksmith, bard).
        public Boolean? IsRedNotBlue { get; set; } // True if red, false if blue.

        public Character()
        {
            this.Id = UtilityClass.createUUID();
        }
        public Character(Guild guild)
        {
            this.Id = UtilityClass.createUUID();
            this.Guild = Guild;
        }
        public Character(List<string> Names)
        {
            this.Id = UtilityClass.createUUID();
            this.Names = Names;
        }
        public Character(List<string> Names, Guild Guild)
        {
            this.Id = UtilityClass.createUUID();
            this.Names = Names;
            this.Guild = Guild;
        }
        public Character(List<string> Names, Guild Guild, List<Permit> Permits)
        {
            this.Id = UtilityClass.createUUID();
            this.Names = Names;
            this.Guild = Guild;
            this.Permits = Permits;
        }

        public Character(
            List<string> Names,
            Guild Guild,
            List<Permit> Permits,
            string? template,
            bool? isRedNotBlue
            )
        {
            this.Id = UtilityClass.createUUID();
            this.Names = Names;
            this.Guild = Guild;
            this.Permits = Permits;
            this.Template = template;
            this.IsRedNotBlue = isRedNotBlue;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Names: " + this.Names + "\n"
                    + "Guild: " + this.Guild + "\n"
                    + "Permits: " + this.Permits + "\n"
                    + "Template: " + this.Template + "\n"
                    + "IsRedNotBlue: " + this.IsRedNotBlue + "\n";
        }
        static public void printAllCharacters(List<Character> allCharList)
        { // Find a way to print the object name.
            UtilityClass.getProps(allCharList[0]);
        }
        static public void printAllNicks(List<Character> allCharList)
        {
            Console.WriteLine("**Beginning output of list of all nicks.**");
            foreach (Character character in allCharList)
            {
                for (var i = 0; i < character.Names.Count; i++)
                {
                    Console.WriteLine(character.Names[i].ToString());
                }
            }
            Console.WriteLine("**Finished outputting list of all nicks.**");
        }

        static public void forEachCharacterSerialize(List<Character> allCharList)
        {
            foreach (Character character in allCharList)
            {
                if (character.Equals(null))
                {
                    throw new InvalidOperationException("selected character was null.");
                }
                string url = MainMethod.fullPath + "characters.json";
                string serialized = JsonConvert.SerializeObject(character, Formatting.Indented);

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