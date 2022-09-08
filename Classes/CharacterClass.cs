﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UO_Permits_Database.Classes
{
    public class Character
    {
        public string? Id { get; set; } // Identifier.
        public List<string>? Name { get; set; } = new List<string>(); // In-game identifier.
        public Guild? Guild { get; set; } // In-game guild identifier.
        public List<Permit>? Permits { get; set; }
        public string? Template { get; set; } // (i.e Tankmage, blacksmith, bard).
        public bool? isRedNotBlue { get; set; } // True if red, false if blue.

        public Character()
        {
            Id = UtilityClass.createUUID();
        }
        public Character(Guild guild)
        {
            Id = UtilityClass.createUUID();
            Guild = Guild;
        }
        public Character(List<string> Name)
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
        }
        public Character(List<string> Name, Guild Guild)
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
        }
        public Character(List<string> Name, Guild Guild, List<Permit> Permits)
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
            this.Permits = Permits;
        }

        public Character(
            List<string> Name,
            Guild Guild,
            List<Permit> Permits,
            string? template,
            bool? isRedNotBlue
            )
        {
            Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Guild = Guild;
            this.Permits = Permits;
            Template = template;
            this.isRedNotBlue = isRedNotBlue;
        }

        public override string ToString()
        {
            return "ID: " + Id + "\n"
                    + "Name: " + Name + "\n"
                    + "Guild: " + Guild + "\n"
                    + "Permits: " + Permits + "\n"
                    + "Template: " + Template + "\n"
                    + "isRedNotBlue: " + isRedNotBlue + "\n";
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
                for (var i = 0; i < character.Name.Count; i++)
                {
                    Console.WriteLine(character.Name[i].ToString());
                }
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
                string url = MainMethod.fullPath + "/json/characters.json";
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