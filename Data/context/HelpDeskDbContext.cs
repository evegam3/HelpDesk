using Domain.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.context
{
    public class HelpDeskDbContext : IdentityDbContext<User>
    {
        public HelpDeskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LogTime> LogTimes { get; set; }
        public DbSet<RecordTicket> RecordTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Config foreign keys
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
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
