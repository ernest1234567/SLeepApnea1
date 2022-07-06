using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SLeepApnea.Server.Models;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
		public DbSet<Roles> Roless { get; set; }
		public DbSet<VitalData> VitalDatas { get; set; }
		public DbSet<Patient> Patients { get; set; }

		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<ReportBPM> ReportBPMs { get; set; }
		public DbSet<ReportSpO2> ReportSpO2s { get; set; }
	}
}
