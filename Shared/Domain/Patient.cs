using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class Patient
	{
		public int PatientID { get; set; }
		public string Name { get; set; }
		public int Phone { get; set; }
		public string Email { get; set; }
		public int? DoctortId { get; set; }
		public virtual Doctor Doctor { get; set; }
		public int? DataId { get; set; }
		public virtual DataCollected Data { get; set; }
	}
}
