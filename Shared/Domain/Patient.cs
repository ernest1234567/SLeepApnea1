using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Shared.Domain
{
	public class Patient : BaseDomainModel
	{
		public string Name { get; set; }
		public int Phone { get; set; }
		public string Email { get; set; }
		public int? DoctortID { get; set; }
		public virtual Doctor Doctor { get; set; }
		public int? DataID { get; set; }
		public virtual DataCollected DataCollected { get; set; }
	}
}
