using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter_clone_backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterHandle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Following = table.Column<int>(type: "int", nullable: false),
                    Followers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Retweets = table.Column<int>(type: "int", nullable: false),
                    PostedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TweetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tweets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Followers", "Following", "Location", "ProfilePhotoURL", "TwitterHandle", "UserName" },
                values: new object[] { 1, new DateTime(1950, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7800000, 79, "London", "https://static-s.aa-cdn.net/img/ios/835022598/0927a357a0700023fce753ab37adf24a?v=1", "F1", "Formula 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Followers", "Following", "Location", "ProfilePhotoURL", "TwitterHandle", "UserName" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), 13600000, 1, "Earth", "https://pbs.twimg.com/profile_images/1340165521992372226/zJ0Zo4rD_400x400.jpg", "UberFacts", "UberFacts" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Image", "Likes", "PostedTime", "Retweets", "Text", "TweetId", "UserId" },
                values: new object[,]
                {
                    { 1, "https://pbs.twimg.com/media/FTXvYNSXoAAqJ8Q.jpg:large", 12700, new DateTime(2022, 5, 29, 11, 58, 25, 743, DateTimeKind.Local).AddTicks(295), 2082, "The points scorers in Barcelona", null, 1 },
                    { 2, "https://pbs.twimg.com/media/FTXunk6XoAIeBwQ?format=jpg&name=small", 13200, new DateTime(2022, 5, 29, 11, 58, 25, 743, DateTimeKind.Local).AddTicks(304), 2342, "We have a NEW Championship leader!", null, 1 },
                    { 6, "https://pbs.twimg.com/media/FTiiuh4XEAEtRQr?format=jpg&name=small", 1012, new DateTime(2022, 5, 29, 11, 58, 25, 743, DateTimeKind.Local).AddTicks(319), 162, "After the 'Teletubies' show ended, the landowner removed the hill used as the set and flooded the field due to the number of fans trespassing to see Teletubbieland", null, 2 },
                    { 7, null, 1862, new DateTime(2022, 5, 29, 11, 58, 25, 743, DateTimeKind.Local).AddTicks(325), 211, "In a bar, turning up the music can cause customers to talk less, resulting in them drinking more", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_TweetId",
                table: "Tweets",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TwitterHandle",
                table: "Users",
                column: "TwitterHandle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
