using System;

namespace UO_Permits_Database
{
    public class Character
    {
        public string Id { get; set; } // Identifier.
        public string? Name { get; set; } // In-game identifier.
        public Guild? Guild { get; set; } // In-game guild identifier.
        public Permit[]? Permits { get; set; } // Array of issued permits.
        public string? Template { get; set; } // (i.e Tankmage, blacksmith, bard).
        public Boolean? isRedNotBlue { get; set; } // True if red, false if blue.

        public Character(string Name)
        { 
            this.Name = Name; 
        }

        public Character(
            string Name,
            Guild Guild,
            Permit[] Permits,
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
    }
}