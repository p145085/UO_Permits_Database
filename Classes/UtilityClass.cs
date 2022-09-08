using MySql.Data.MySqlClient;
using System;
using System.Reflection;

namespace UO_Permits_Database;
public class UtilityClass
{

	static public string createUUID()
	{

		Guid myuuid = Guid.NewGuid();
		string myuuidAsString = myuuid.ToString();

		return myuuidAsString;

	}

	static public void getProps(object x)
	{ // https://stackoverflow.com/questions/852181/c-printing-all-properties-of-an-object/852235#852235
		Type t = x.GetType(); // Where obj is object whose properties you need.
		PropertyInfo[] pi = t.GetProperties();
		foreach (PropertyInfo p in pi)
		{
			System.Console.WriteLine(p.Name + " : " + p.GetValue(x));
		}
	}

    static public void printGuildsList(List<Guild> allGuildsList)
	{
		foreach (Guild guild in allGuildsList)
		{
			Console.WriteLine(guild.Name);
		}
	}

	public UtilityClass()
	{
	}
}
