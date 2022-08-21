using System;

namespace UO_Permits_Database
{
    public class Player
    {
        public string Id { get; set; }
        public Array? Names { get; set; } // Multiple nicknames should be possible.
        public Guild? Guilds { get; set; } // Multiple guilds should be possible.
        public Permit? Permits { get; set; } // Multiple permits should be possible.

        public Player()
        {
            this.Id = UtilityClass.createUUID();
        }
    }
}