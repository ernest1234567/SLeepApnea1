using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SLeepApnea.Client.Static
{
	public static class Endpoints
	{
		private static readonly string Prefix = "api";

		public static readonly string VitalDatasEndpoint = $"{Prefix}/VitalDatas";
		public static readonly string PatientsEndpoint = $"{Prefix}/Patients";
		public static readonly string DoctorsEndpoint = $"{Prefix}/Doctors";
		public static readonly string RolessEndpoint = $"{Prefix}/Roles";
	}
}
