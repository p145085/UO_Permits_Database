using Newtonsoft.Json;
using System;

namespace UO_Permits_Database
{
    public class Permit
    {
        public string Id { get; set; }
        public string? Type { get; set; } // Issuer-written type of permit. (i.e "Sheep-shearing", "Farming in Deceit").
        public string? Description { get; set; } // Issuer-written message.
        public Character? PermitHolder { get; set; } // Single Account.
        public Guild? PermitHolderGuild { get; set; } // If guild purchases permit, not player.
        public Character? PermitIssuer { get; set; } // Single Account.
        public List<Character>? PermitIssuerCollaborative { get; set; } = new List<Character>();
        public DateOnly? PermitCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Set to DateTime.Now;
        public DateOnly? PermitExpiration { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)); // Default: 1 month. Use set for custom date.

        public Permit(
            string Type,
            string Description,
            Character PermitHolder,
            Guild PermitHolderGuild,
            Character PermitIssuer,
            List<Character> PermitIssuerCollaborative,
            DateOnly PermitCreated,
            DateOnly PermitExpiration
            )
        {
            Id = UtilityClass.createUUID();
            this.Type = Type;
            this.Description = Description;
            this.PermitHolder = PermitHolder;
            this.PermitHolderGuild = PermitHolderGuild;
            this.PermitIssuer = PermitIssuer;
            this.PermitIssuerCollaborative = PermitIssuerCollaborative;
            this.PermitCreated = PermitCreated;
            this.PermitExpiration = PermitExpiration;
        }
        public Permit(
            string Type,
            string Description,
            Character PermitHolder,
            Character PermitIssuer,
            DateOnly PermitCreated,
            DateOnly PermitExpiration
            )
        {
            Id = UtilityClass.createUUID();
            this.Type = Type;
            this.Description = Description;
            this.PermitHolder = PermitHolder;
            this.PermitIssuer = PermitIssuer;
            this.PermitCreated = PermitCreated;
            this.PermitExpiration = PermitExpiration;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Type: " + this.Type + "\n"
                    + "Description: " + this.Description + "\n"
                    + "PermitHolder: " + this.PermitHolder + "\n"
                    + "PermitHolderGuild: " + this.PermitHolderGuild + "\n"
                    + "PermitIssuerCollaboration: " + this.PermitIssuerCollaborative + "\n"
                    + "PermitIssuer: " + this.PermitIssuer + "\n"
                    + "PermitCreated: " + this.PermitCreated + "\n"
                    + "PermitExpiration: " + this.PermitExpiration + "\n";
        }

        static public void printAllPermits(List<Permit> allPermitsList)
        {
            Console.WriteLine("**Beginning output of list of all permits.**");
            foreach (Permit permit in allPermitsList)
            {
                Console.WriteLine(permit.Description);
            }
            Console.WriteLine("**Finished outputting list of all permits.**");
        }

        static public void forEachPermit(List<Permit> allPermits)
        {
            foreach (Permit permit in allPermits)
            {
                if (permit.Equals(null))
                {
                    throw new InvalidOperationException("selected permit was null.");
                }
                string url = MainMethod.fullPath + "/json/permits.json";
                string serialized = JsonConvert.SerializeObject(permit, Formatting.Indented);

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