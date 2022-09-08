using System;
namespace UO_Permits_Database;
public class Account
{
	public string? Id { get; set; }
	public string? Nickname { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
	public DateTime? RegistrationDate { get; set; } = DateTime.Now;

	public Account()
	{
		this.Id = UtilityClass.createUUID();
	}

	public Account(string Nickname, string Email, string Password)
    {
		this.Nickname = Nickname;
		this.Email = Email;
		this.Password = Password;
    }
}
