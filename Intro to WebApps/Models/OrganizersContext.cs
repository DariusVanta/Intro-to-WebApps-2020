using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_to_WebApps.Models
{
    public class OrganizersContext : DbContext
    {
        public OrganizersContext(DbContextOptions<OrganizersContext> options)
            : base(options)
        {
            //OrganizerItems.
        }

        public DbSet<OrganizerItem> OrganizerItems { get; set; }
    }
}
