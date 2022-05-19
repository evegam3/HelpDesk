using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.context
{
    public class HelpDeskDbContext : DbContext
    {
        public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LogTime> LogTimes { get; set; }
        public DbSet<RecordTicket> RecordTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Config foreign keys
            builder.Entity<Deparment>(x => x
                .HasMany(c => c.Users)
                .WithOne(e => e.Deparment)
            );
            builder.Entity<User>(x => x
                .HasMany(c => c.RolUsers)
                .WithOne(e => e.User)
            );
            builder.Entity<User>(x => x
                .HasMany(c => c.ReportedTickets)
                .WithOne(e => e.ReportedByUser)
            );
            builder.Entity<User>(x => x
                .HasMany(c => c.AssignedTickets)
                .WithOne(e => e.AssignedToUser)
            );
            builder.Entity<User>(x => x
               .HasMany(c => c.Comments)
               .WithOne(e => e.User)
            );
            builder.Entity<User>(x => x
               .HasMany(c => c.LogTimes)
               .WithOne(e => e.User)
            );
            builder.Entity<Rol>(x => x
               .HasMany(c => c.RolUsers)
               .WithOne(e => e.Rol)
            );
            builder.Entity<Category>(x => x
             .HasKey(c => c.CategoryId)
            );
            builder.Entity<Category>(x => x
              .HasMany(c => c.Tickets)
              .WithOne(e => e.Category)
            );
            builder.Entity<Status>(x => x
              .HasMany(c => c.Tickets)
              .WithOne(e => e.Status)
            );
            builder.Entity<Priority>(x => x
              .HasMany(c => c.Tickets)
              .WithOne(e => e.Priority)
            );
            builder.Entity<Ticket>(x => x
              .HasMany(c => c.Comments)
              .WithOne(e => e.Ticket)
            );
            builder.Entity<Ticket>(x => x
              .HasMany(c => c.Comments)
              .WithOne(e => e.Ticket)
            );
            builder.Entity<Ticket>(x => x
             .HasMany(c => c.LogTimes)
             .WithOne(e => e.Ticket)
           );
        }

    }
}
