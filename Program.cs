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
        }

        foreach (Server server in allServers)
        {
            // Serialize to JSON. "Servers.json".
        }

        Console.WriteLine("End of Server.");


        Guild cA = new Guild(
            "chumbucket & Associates",
            "cA"
            );

        List<Guild> allGuilds = new List<Guild>();
        allGuilds.Add(cA);

        foreach (Guild guild in allGuilds)
        {
            Console.WriteLine(guild.ToString());
        }

        foreach (Guild guild in allGuilds)
        {
            // Serialize to JSON. "Guilds.json".
        }

        Console.WriteLine("End of Guild.");







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
        }

        Console.WriteLine("End of Character.");






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
        }

        foreach (Permit permit in allPermits)
        {
            // Serialize to JSON. "Permits.json". 
        }
        Console.WriteLine("End of Permits.");




        var options = new JsonSerializerOptions() { WriteIndented = true }; // Custom converter.
        options.Converters.Add(new CustomDateTimeConverter("MM-dd-yyyy")); // Custom converter.
        var jsonUOSA = JsonSerializer.Serialize(UOSA, options); // Custom converter.

        var options2 = new JsonSerializerOptions() { WriteIndented = true }; // Custom converter.
        options2.Converters.Add(new CustomDateTimeConverter("MM-dd-yyyy")); // Custom converter.
        var jsonUOO = JsonSerializer.Serialize(UOO, options); // Custom converter.

        var options3 = new JsonSerializerOptions() { WriteIndented = true }; // Custom converter.
        options3.Converters.Add(new CustomDateTimeConverter("MM-dd-yyyy")); // Custom converter.
        var jsonUOR = JsonSerializer.Serialize(UOR, options); // Custom converter.
        //Console.WriteLine(json);

        string folder = @"C:\Users\emila\source\repos\UO_Permits_Database\";
        string fileNameUOSA = "jsonUOSA.txt";
        string fullPathUOSA = folder + fileNameUOSA;

        string fileNameUOO = "jsonUOO.txt";
        string fullPathUOO = folder + fileNameUOO;

        string fileNameUOR = "jsonUOR.txt";
        string fullPathUOR = folder + fileNameUOR;

        //File.WriteAllText(fullPathUOSA, jsonUOSA);
        //File.WriteAllText(fullPathUOO, jsonUOO);
        //File.WriteAllText(fullPathUOR, jsonUOR);

        string a = SaveServer(@"C:\Users\emila\source\repos\UO_Permits_Database\", "jsonuosa.txt", UOSA);
        string b = SaveServer(@"C:\Users\emila\source\repos\UO_Permits_Database\", "jsonuoo.txt", UOO);
        string c = SaveServer(@"C:\Users\emila\source\repos\UO_Permits_Database\", "jsonuor.txt", UOR);


 

    }

    private static string SaveServer(string folder, string fileName, Server server)
    {
        string fullPath = folder + fileName;

        var options = new JsonSerializerOptions() { WriteIndented = true }; // Custom converter.
        options.Converters.Add(new CustomDateTimeConverter("MM-dd-yyyy")); // Custom converter.
        var json = JsonSerializer.Serialize(server, options); // Custom converter.

        File.WriteAllText(fullPath, json);

        return json;
    }






}