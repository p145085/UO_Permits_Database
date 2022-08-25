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
    }
}