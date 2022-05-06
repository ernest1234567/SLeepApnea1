using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Shared.Domain
{
	public class DataCollected : BaseDomainModel
	{
		public DateTime Date { get; set; }
		public int BPM { get; set; }
		public int SpO2 { get; set; }
		public int? PatientID { get; set; }
		public virtual Patient Patient { get; set; }
	}
}
