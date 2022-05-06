using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Shared.Domain
{
	public class VitalData : BaseDomainModel
	{
		public DateTime Date { get; set; }
		public int BPM { get; set; }
		public int BPMCount { get; set; }
		public int SpO2 { get; set; }
		public int SpO2Count { get; set; }
		public int time { get; set; }

	}
}
