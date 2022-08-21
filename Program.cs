using System;
using System.Reflection;

namespace UO_Permits_Database;

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

        Character Populus = new Character(
            "Populus"
            );

        Character Loaf = new Character(
            "Trolliosis"
            );

        Character Lelouche = new Character(
            "rejected"
            );

        Guild cA = new Guild(
            "chumbucket & Associates",
            "cA"
            );

        Permit LoafTableBarrier = new Permit(
            "Guildhouse Access",
            "Loaf is allowed behind the table barrier under supervision by appropriate guards.",
            Loaf,
            Lelouche,
            DateOnly.FromDateTime(DateTime.Now),
            DateOnly.Parse("01-01-2023")
            );

        UtilityClass.getProps(LoafTableBarrier);

    }
}