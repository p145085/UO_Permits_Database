using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UO_Permits_Database
{
    public class Character
    {
        public string? Id { get; set; } // Identifier.
        public string? Name { get; set; } // In-game identifier.
        public Guild? Guild { get; set; } // In-game guild identifier.
        public List<Permit>? Permits { get; set; }
        public string? Template { get; set; } // (i.e Tankmage, blacksmith, bard).
        public Boolean? isRedNotBlue { get; set; } // True if red, false if blue.

        public Character(string Name)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
        }
        public Character(string Name, Guild Guild)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
        }
        public Character(string Name, Guild Guild, List<Permit> Permits)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
            this.Permits = Permits;
        }

        public Character(
            string Name,
            Guild Guild,
            List<Permit> Permits,
            string? template,
            bool? isRedNotBlue
            )
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
            this.Permits = Permits;
            this.Template = template;
            this.isRedNotBlue = isRedNotBlue;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Name: " + this.Name + "\n"
                    + "Guild: " + this.Guild + "\n"
                    + "Permits: " + this.Permits + "\n"
                    + "Template: " + this.Template + "\n"
                    + "isRedNotBlue: " + this.isRedNotBlue + "\n";
        }

        static public void printAllChars(List<Character> allCharList)
        {
            Console.WriteLine("**Beginning output of list of all nicks.**");
            foreach (Character character in allCharList)
            {
                Console.WriteLine(character.Name);
            }
            Console.WriteLine("**Finished outputting list of all nicks.**");
        }

        static public void forEachCharacter(List<Character> allCharList)
        {
            foreach (Character character in allCharList)
            {
                if (character.Equals(null))
                {
                    throw new InvalidOperationException("selected character was null.");
                }
                string url = MainMethod.fullPath + "characters.json";
                string serialized = JsonConvert.SerializeObject(character, Formatting.Indented);
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