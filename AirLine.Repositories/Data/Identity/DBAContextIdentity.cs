using AirLine.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Repositories.Data.Identity
{
	public class DBAContextIdentity : IdentityDbContext<AppUser>
	{
		public DBAContextIdentity(DbContextOptions<DBAContextIdentity> options) : base(options)
		{
		}
	}
}
