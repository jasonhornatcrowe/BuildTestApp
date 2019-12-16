using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildTestApp.Pages
{
	public class IndexModel : PageModel
	{
		public void OnGet()
		{

		}
		public object TriggerSecurityWarning(string connection, string name, string password)
		{
			SqlConnection someConnection = new SqlConnection(connection);
			SqlCommand someCommand = new SqlCommand();
			someCommand.Connection = someConnection;

			someCommand.CommandText = "SELECT SecretInfo FROM USERS " +
			                          "WHERE Username='" + name +
			                          "' AND Password='" + password + "'";

			someConnection.Open();
			object secretInfo = someCommand.ExecuteScalar();
			someConnection.Close();
			return secretInfo;
		}
	}
}
