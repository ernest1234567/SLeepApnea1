using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class ReportSpO2 : BaseDomainModel
	{
		public int below95 { get; set; }
		public int below90 { get; set; }
		public int below85 { get; set; }
		public int below80 { get; set; }
		public int below70 { get; set; }

	}
}
