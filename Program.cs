using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using UO_Permits_Database.Classes;

namespace UO_Permits_Database;

// To-Do: 
// Save objects in corresponding JSON files for persistent storage. Alternatively MySQL database. ("Why not both?"). Online and offline storage.
// Webpage with login functionality for authorized associates to CRUD manage the database.
public class MainMethod
{
    public const string fullPath = "C:\\Users\\emila\\source\\repos\\UO_Permits_Database\\";
    
    static void Main(string[] args)
    {
        string fullPath = MainMethod.fullPath;

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

        Server.forEachServer(allServers);

        //Console.WriteLine("End of Server.");

        // End of Server.

        Guild cA = new Guild(
            "chumbucket & Associates",
            "cA"
            );
        Guild foo = new Guild();

        List<Guild> allGuilds = new List<Guild>();
        allGuilds.Add(cA);
        allGuilds.Add(foo);

        Guild.forEachGuild(allGuilds);

        //Console.WriteLine("End of Guild.");

        // End of Guild.

        Character Populus = new Character();
        Character Loaf = new Character();
        Character Lelouche = new Character();
        Character Matron = new Character();
        Character chumbucket = new Character();
        Character Franz = new Character();
        Character Downs = new Character();
        Character Miller = new Character();
        Character applejack = new Character();
        Character hicha = new Character();
        Character chainsoar = new Character();
        Character Freeza = new Character();
        Character clarkkent = new Character();
        Character Pacifico = new Character();
        Character Jada = new Character();




        List<Character> allCharacters = new List<Character>();
        allCharacters.Add(Populus);
        allCharacters.Add(Loaf);
        allCharacters.Add(Lelouche);

        // Manual Entry.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Populus.Name.Add("Populus");
        Populus.Name.Add("Ugodatwayigohome");
        Populus.Name.Add("Jennifer");
        Populus.Guild = cA;
        Loaf.Name.Add("Trolliosis");
        Lelouche.Name.Add("rejected");
        Matron.Name.Add("MatronDeWinter");
        chumbucket.Name.Add("chumbucket");
        Franz.Name.Add("");
        Downs.Name.Add("Downs");
        Miller.Name.Add("Lebron James");
        applejack.Name.Add("");
        hicha.Name.Add("");
        chainsoar.Name.Add("");
#pragma warning restore CS8602 // Dereference of a possibly null reference.


        Character.forEachCharacter(allCharacters);

        //Console.WriteLine("End of Character.");

        // End of Character.

        Permit LoafTableBarrier = new Permit(
            "Guildhouse Access",
            "Loaf is allowed behind the table-barrier under supervision by appropriate guards.",
            Loaf,
            Lelouche,
            DateOnly.Parse("08-22-2022"),
            DateOnly.Parse("01-01-2023")
            );
        Permit SP5134 = new Permit(
            "Sheep",
            "N/A",
            Jada,
            hicha,
            DateOnly.Parse("04-17-2010"),
            DateOnly.Parse("01-01-2023")
            );

        List<Permit> allPermits = new List<Permit>();
        allPermits.Add(LoafTableBarrier);
        allPermits.Add(SP5134);


        Permit.forEachPermit(allPermits);

        //Console.WriteLine("End of Permits.");

        // End of Permits.

        // Shenanigans starts here.
        //Guild.printAllGuilds(allGuilds);
        //Character.printAllNicks(allCharacters);
        //Permit.printAllPermits(allPermits);

        //Character.printAllCharacters(allCharacters);
        // End of Shenanigans.
    }
}