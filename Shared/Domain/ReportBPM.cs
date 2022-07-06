using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class ReportBPM : BaseDomainModel
	{
		public int below60 { get; set; }
		public int below50 { get; set; }
		public int below45 { get; set; }
		public int below40 { get; set; }
		public int below35 { get; set; }
	}
}
