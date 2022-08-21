using System;

namespace UO_Permits_Database
{
    public class Permit
    {
        public string Id { get; set; }
        public string? Type { get; set; } // Issuer-written type of permit. (i.e "Sheep-shearing", "Farming in Deceit").
        public string? Description { get; set; } // Issuer-written message.
        public Player? PermitHolder { get; set; } // Single Player.
        public Player? PermitIssuer { get; set; } // Single Player.
        public DateTime PermitCreated { get; set; } = DateTime.Now; // Set to DateTime.Now;
        public DateTime PermitExpiration { get; set; } // Set to date of choice.

        public Permit()
        {
            this.Id = UtilityClass.createUUID();
        }
    }
}