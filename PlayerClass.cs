using System;

namespace UO_Permits_Database
{
    public class Player
    {
        public string Id { get; set; }
        public Array? Names { get; set; } // Multiple nicknames should be possible.
        public Guild? Guilds { get; set; } // Multiple guilds should be possible.
        public Permit? Permits { get; set; } // Multiple permits should be possible.

        public Player(Array Names, Guild Guilds, Permit Permits)
        {
            this.Id = UtilityClass.createUUID();
            this.Names = Names;
            this.Guilds = Guilds;
            this.Permits = Permits;
        }
    }
}