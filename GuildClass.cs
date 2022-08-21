using System;

namespace UO_Permits_Database
{
    public class Guild
    {
        public string Id { get; set; }
        public string? Name { get; set; } // Name of Guild. (i.e "chumbucket & Associates").
        public string? Tag { get; set; } // Tag of Guild. (i.e "[cA]").
        public List<Character>? Members { get; set; } // Array of characters.


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
    }
}