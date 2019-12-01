using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.Models;

namespace WebApplication1
{
	/// <summary>
	/// Summary description for UsersRetriever
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class UsersRetriever : System.Web.Services.WebService
	{
		FitnessContext db = new FitnessContext();

		[WebMethod]
		public List<User> RetrieveUsers()
		{
			List<User> users = db.Users.ToList();    
			foreach(var item in users)
			{
				item.password = "password cannot be retrieved";
			}
			return users;
		}
	}
}
