using System;

public class Admin: User
{
	public Admin()
	{
		private DateTime loginDate;

		public DateTime LoginDate
		{
				get { return loginDate; }
				set { loginDate = value; }
		}
    // Constructor
    public Admin(string username, string password, DateTime loginDate): base(username, password)
		{
			this.loginDate = loginDate;
		}
	}
}
