using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class DataCollected
	{
		public int DataID { get; set; }
		public DateTime Date { get; set; }
		public int BPM { get; set; }
		public int SpO2 { get; set; }
		public int? PatientId { get; set; }
		public virtual Patient Patient { get; set; }
	}
}
