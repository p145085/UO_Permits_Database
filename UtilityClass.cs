using System;
namespace UO_Permits_Database;
public class UtilityClass
{
	static public string createUUID()
	{

		Guid myuuid = Guid.NewGuid();
		string myuuidAsString = myuuid.ToString();

		return myuuidAsString;

	}

	public UtilityClass()
	{
	}
}
