using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLeepApnea.Shared.Domain
{
	public class ReportBPM : BaseDomainModel
	{
		public int _100to95 { get; set; }
		public int _95to90 { get; set; }
		public int _90to85 { get; set; }
		public int _85to80 { get; set; }
		public int _80to75 { get; set; }
		public int _75to70 { get; set; }
		public int _70to65 { get; set; }
		public int _65to60 { get; set; }
		

	}
}
