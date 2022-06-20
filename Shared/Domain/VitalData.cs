using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SLeepApnea.Shared.Domain
{
	public class VitalData : BaseDomainModel
	{
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public int BPM { get; set; }
		public int BPMCount { get; set; }
		public int SpO2 { get; set; }
		public int SpO2Count { get; set; }
		public virtual Patient Patient { get; set; }
		public int? PatientID { get; set; }
		public virtual Doctor Doctor { get; set; }
		public int? DoctorID { get; set; }
	}
}
