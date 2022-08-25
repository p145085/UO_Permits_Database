using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace UO_Permits_Database;

// To-Do: 
// Save objects in corresponding JSON files for persistent storage. Alternatively MySQL database. ("Why not both?"). Online and offline storage.
// Webpage with login functionality for authorized associates to CRUD manage the database.
public class MainMethod
{
    static void Main(string[] args)
    {
        Server UOSA = new Server(
            "Ultima Online: Second Age",
            "UOSA",
            "https://uosecondage.com",
            "https://forums.uosecondage.com/",
            "https://discord.gg/bub8b7vT",
            "T2A",
            DateOnly.Parse("01-01-2007") // Unconfirmed.
            );

        Server UOO = new Server(
            "Ultima Online: Outlands",
            "UOO",
            "https://uooutlands.com/",
            "https://forums.uooutlands.com/index.php",
            "https://discord.com/invite/M6pNQn2",
            "Custom",
            DateOnly.Parse("10-01-2018") // Unconfirmed.
            );

        Server UOR = new Server(
            "Ultima Online: Renaissance",
            "UOR",
            "https://uorenaissance.com/",
            "https://uorforum.com/",
            "https://discord.com/invite/9JtUTdP",
            "UOR",
            DateOnly.Parse("06-16-2012") // Unconfirmed.
            );

        List<Server> allServers = new List<Server>(); // Lista som ska hålla alla 'Server' klasser.
        allServers.Add(UOR);
        allServers.Add(UOO);
        allServers.Add(UOSA);

        foreach (Server server in allServers)
        {
            Console.WriteLine(server.ToString());
            File.AppendAllText(@"C:\Users\emila\source\repos\UO_Permits_Database\servers.json", server.ToString());

        }
        Console.WriteLine("End of Server.");

        // End of Server.

        Guild cA = new Guild(
            "chumbucket & Associates",
            "cA"
            );

        List<Guild> allGuilds = new List<Guild>();
        allGuilds.Add(cA);

        foreach (Guild guild in allGuilds)
        {
            Console.WriteLine(guild.ToString());
            File.AppendAllText(@"C:\Users\emila\source\repos\UO_Permits_Database\guilds.json", guild.ToString());

        }
        Console.WriteLine("End of Guild.");

        // End of Guild.

        Character Populus = new Character(
            "Populus",
            cA
            );

        Character Loaf = new Character(
            "Trolliosis",
            cA
            );

        Character Lelouche = new Character(
            "rejected",
            cA
            );

        List<Character> allCharacters = new List<Character>();
        allCharacters.Add(Populus);
        allCharacters.Add(Loaf);
        allCharacters.Add(Lelouche);

        foreach (Character character in allCharacters)
        {
            Console.WriteLine(character.ToString());
            File.AppendAllText(@"C:\Users\emila\source\repos\UO_Permits_Database\characters.json", character.ToString());

        }
        Console.WriteLine("End of Character.");

        // End of Character.

        Permit LoafTableBarrier = new Permit(
            "Guildhouse Access",
            "Loaf is allowed behind the table-barrier under supervision by appropriate guards.",
            Loaf,
            Lelouche,
            DateOnly.Parse("08-22-2022"),
            DateOnly.Parse("01-01-2023")
            );

        List<Permit> allPermits = new List<Permit>(); // Need to convert into List<Permit>.
        allPermits.Add(LoafTableBarrier);

        foreach (Permit permit in allPermits)
        {
            Console.WriteLine(permit.ToString());
            File.AppendAllText(@"C:\Users\emila\source\repos\UO_Permits_Database\permits.json", permit.ToString());

        }
        Console.WriteLine("End of Permits.");

        // End of Permits.

    }
}