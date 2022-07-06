using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Roles { get; set; }

	}
}
