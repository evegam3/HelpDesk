using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.models;

namespace HelpDesk.Data
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext (DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.models.Category>? Category { get; set; }
    }
}
