using System;

namespace UO_Permits_Database
{
    public class Guild
    {
        public string Id { get; set; }
        public string? Name { get; set; } // Name of Guild. (i.e "chumbucket & Associates").
        public string? Tag { get; set; } // Tag of Guild. (i.e "[cA]").
        public Array? Members { get; set; } // Array of Players?

        public Guild(string Name, string Tag, Array Members)
        {
            this.Id = UtilityClass.createUUID();
            this.Name = Name;
            this.Tag = Tag;
            this.Members = Members;
        }
    }
}