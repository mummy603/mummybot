﻿using mummybot.Models;
using Microsoft.EntityFrameworkCore;

namespace mummybot
{
    public class mummybotDbContext : DbContext
    {
        public mummybotDbContext(DbContextOptions<mummybotDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAudit> UsersAudit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Guild).HasColumnName("guild");

                entity.Property(e => e.IsCommand).HasColumnName("iscommand");

                entity.Property(e => e.LastUsedBy).HasColumnName("lastusedby");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12);

                entity.Property(e => e.Uses).HasColumnName("uses");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserId)
                    .HasName("users_userid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.GuildId).HasColumnName("guildid");

                entity.Property(e => e.GuildName)
                    .IsRequired()
                    .HasColumnName("guildname");

                entity.Property(e => e.Joined).HasColumnName("joined");

                entity.Property(e => e.Nickname).HasColumnName("nickname");

                entity.Property(e => e.TagBanned)
                    .HasColumnName("tagbanned")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UsersAudit>(entity =>
            {
                entity.ToTable("users_audit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangedOn)
                    .HasColumnName("changedon")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GuildId).HasColumnName("guildid");

                entity.Property(e => e.Nickname).HasColumnName("nickname");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.Property(e => e.Username).HasColumnName("username");
            });
        }
    }
}