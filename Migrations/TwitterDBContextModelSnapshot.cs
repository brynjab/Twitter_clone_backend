// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter_clone_backend.Data;

#nullable disable

namespace Twitter_clone_backend.Migrations
{
    [DbContext(typeof(TwitterDBContext))]
    partial class TwitterDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Twitter_clone_backend.Models.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsLiked")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Retweets")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int?>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://pbs.twimg.com/media/FTXvYNSXoAAqJ8Q.jpg:large",
                            IsLiked = false,
                            Likes = 12700,
                            PostedTime = new DateTime(2022, 5, 30, 22, 40, 31, 385, DateTimeKind.Local).AddTicks(2065),
                            Retweets = 2082,
                            Text = "The points scorers in Barcelona",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://pbs.twimg.com/media/FTXunk6XoAIeBwQ?format=jpg&name=small",
                            IsLiked = false,
                            Likes = 13200,
                            PostedTime = new DateTime(2022, 5, 30, 22, 40, 31, 385, DateTimeKind.Local).AddTicks(2076),
                            Retweets = 2342,
                            Text = "We have a NEW Championship leader!",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Image = "https://pbs.twimg.com/media/FTiiuh4XEAEtRQr?format=jpg&name=small",
                            IsLiked = false,
                            Likes = 1012,
                            PostedTime = new DateTime(2022, 5, 30, 22, 40, 31, 385, DateTimeKind.Local).AddTicks(2090),
                            Retweets = 162,
                            Text = "After the 'Teletubies' show ended, the landowner removed the hill used as the set and flooded the field due to the number of fans trespassing to see Teletubbieland",
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            IsLiked = false,
                            Likes = 1862,
                            PostedTime = new DateTime(2022, 5, 30, 22, 40, 31, 385, DateTimeKind.Local).AddTicks(2096),
                            Retweets = 211,
                            Text = "In a bar, turning up the music can cause customers to talk less, resulting in them drinking more",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Twitter_clone_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Followers")
                        .HasColumnType("int");

                    b.Property<int>("Following")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TwitterHandle")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1950, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Followers = 7800000,
                            Following = 79,
                            Location = "London",
                            ProfilePhotoURL = "https://static-s.aa-cdn.net/img/ios/835022598/0927a357a0700023fce753ab37adf24a?v=1",
                            TwitterHandle = "F1",
                            UserName = "Formula 1"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996),
                            Followers = 13600000,
                            Following = 1,
                            Location = "Earth",
                            ProfilePhotoURL = "https://pbs.twimg.com/profile_images/1340165521992372226/zJ0Zo4rD_400x400.jpg",
                            TwitterHandle = "UberFacts",
                            UserName = "UberFacts"
                        });
                });

            modelBuilder.Entity("Twitter_clone_backend.Models.Tweet", b =>
                {
                    b.HasOne("Twitter_clone_backend.Models.Tweet", null)
                        .WithMany("Replies")
                        .HasForeignKey("TweetId");

                    b.HasOne("Twitter_clone_backend.Models.User", "User")
                        .WithMany("Tweets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter_clone_backend.Models.Tweet", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("Twitter_clone_backend.Models.User", b =>
                {
                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
