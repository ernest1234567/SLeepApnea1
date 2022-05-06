using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Shared.Domain
{
	public class Doctor : BaseDomainModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public int Phone { get; set; }
	}
}
