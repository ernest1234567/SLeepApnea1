using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SLeepApnea.Shared.Domain
{
	public class VitalData : BaseDomainModel
	{

		public int BPM { get; set; }
		public int Movement { get; set; }
		public int SpO2 { get; set; }
		public String Date { get; set; }
		public String Time { get; set; }

		
		}


	}

