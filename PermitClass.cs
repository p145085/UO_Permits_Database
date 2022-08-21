using System;

namespace UO_Permits_Database
{
    public class Permit
    {
        public string Id { get; set; }
        public string? Type { get; set; } // Issuer-written type of permit. (i.e "Sheep-shearing", "Farming in Deceit").
        public string? Description { get; set; } // Issuer-written message.
        public Character? PermitHolder { get; set; } // Single Player.
        public Character? PermitIssuer { get; set; } // Single Player.
        public DateOnly PermitCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Set to DateTime.Now;
        public DateOnly PermitExpiration { get; set; } // Set to date of choice.

        public Permit(
            string Type,
            string Description,
            Character PermitHolder,
            Character PermitIssuer,
            DateOnly PermitCreated,
            DateOnly PermitExpiration
            )
        {
            this.Id = UtilityClass.createUUID();
            this.Type = Type;
            this.Description = Description;
            this.PermitHolder = PermitHolder;
            this.PermitIssuer = PermitIssuer;
            this.PermitCreated = PermitCreated;
            this.PermitExpiration = PermitExpiration;

        }
    }
}