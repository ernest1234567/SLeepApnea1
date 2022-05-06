using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class User : BaseDomainModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public int Phone { get; set; }

	}
}
