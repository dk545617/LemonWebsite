﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lemon.Data.Migrations
{
    public partial class addQuestionClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
