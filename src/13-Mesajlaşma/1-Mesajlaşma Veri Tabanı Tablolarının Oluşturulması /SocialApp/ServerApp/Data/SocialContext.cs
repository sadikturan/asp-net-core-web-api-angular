using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Data
{
    public class SocialContext: IdentityDbContext<User,Role,int>
    {
        public SocialContext(DbContextOptions<SocialContext> options):base(options)
        {
            
        }  

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserToUser> UserToUser { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<UserToUser>()
                .HasKey(k=> new {k.UserId,k.FollowerId});

            builder.Entity<UserToUser>()
                .HasOne(l=> l.User)
                .WithMany(a=>a.Followers)
                .HasForeignKey(l=>l.FollowerId);

            builder.Entity<UserToUser>()
                .HasOne(l=> l.Follower)
                .WithMany(a=>a.Followings)
                .HasForeignKey(l=>l.UserId);

            builder.Entity<Message>()
                .HasOne(i=>i.Sender)
                .WithMany(i=>i.MessagesSent)
                .HasForeignKey(i=>i.SenderId);

            builder.Entity<Message>()
                .HasOne(i=>i.Recipient)
                .WithMany(i=>i.MessagesReceived)
                .HasForeignKey(i=>i.RecipientId);
        }

    }
}