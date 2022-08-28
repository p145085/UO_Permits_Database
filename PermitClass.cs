﻿using Newtonsoft.Json;
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

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                    + "Type: " + this.Type + "\n"
                    + "Description: " + this.Description + "\n"
                    + "PermitHolder: " + this.PermitHolder + "\n"
                    + "PermitIssuer: " + this.PermitIssuer + "\n"
                    + "PermitCreated: " + this.PermitCreated + "\n"
                    + "PermitExpiration: " + this.PermitExpiration + "\n";
        }

        static public void forEachPermit(List<Permit> allPermits)
        {
            foreach (Permit permit in allPermits)
            {
                if (permit.Equals(null))
                {
                    throw new InvalidOperationException("selected permit was null.");
                }
                string url = MainMethod.fullPath + "permits.json";
                string serialized = JsonConvert.SerializeObject(permit, Formatting.Indented);
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