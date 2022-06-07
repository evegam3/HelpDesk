using Domain.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.context
{
    public class HelpDeskDbContext : IdentityDbContext<
        User, Rol, string,
        IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
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
             .HasMany(c => c.LogTimes)
             .WithOne(e => e.Ticket)
            );

            builder.Entity<User>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                // Maps to the AspNetUsers table
                b.ToTable("Users");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Rol>(b =>
            {
                b.ToTable("Roles");
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
            builder.Entity<UserRole>(b =>
            {
                b.HasKey(p => new { p.UserId, p.RoleId });
                // Maps to the AspNetUserRoles table
                b.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {

                options.UseSqlServer("Data Source=DESKTOP-VLO808K;Initial Catalog=HelpDesk;Integrated Security=True");

            }

        }
    }
}
