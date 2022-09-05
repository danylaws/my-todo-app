using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyTodoApp.Data.Migrations
{
    [DbContext(typeof(TodoAppDbContext))]
    [Migration("20220715141820_dbCreation")]
    public class dbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Categories", table => new
            {
                Id = table.Column<string>(),
                Name = table.Column<string>(nullable: true)
            }, constraints: (table => table.PrimaryKey("PK_Categories", x => x.Id)));
            migrationBuilder.CreateTable("Todos", table => new
            {
                Id = table.Column<string>(),
                Title = table.Column<string>(nullable: true),
                Description = table.Column<string>(nullable: true),
                CreatedAt = table.Column<DateTime>(),
                ScheduledFor = table.Column<DateTime>(),
                CategoryId = table.Column<string>(nullable: true)
            }, constraints: (table =>
            {
                table.PrimaryKey("PK_Todos", x => x.Id);
                table.ForeignKey("FK_Todos_Categories_CategoryId", x => x.CategoryId, "Categories", "Id", (string)null, ReferentialAction.NoAction, ReferentialAction.Restrict);
            }));
            migrationBuilder.CreateIndex("IX_Todos_CategoryId", "Todos", "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Todos");
            migrationBuilder.DropTable("Categories");
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", (object)"3.1.26").HasAnnotation("Relational:MaxIdentifierLength", (object)64);
            modelBuilder.Entity("MyTodoApp.Domain.Entities.Category", (Action<EntityTypeBuilder>)(b =>
            {
                b.Property<string>("Id").HasColumnType<string>("varchar(255) CHARACTER SET utf8mb4");
                b.Property<string>("Name").HasColumnType<string>("longtext CHARACTER SET utf8mb4");
                b.HasKey("Id");
                b.ToTable("Categories");
            }));
            modelBuilder.Entity("MyTodoApp.Domain.Entities.Todo", (Action<EntityTypeBuilder>)(b =>
            {
                b.Property<string>("Id").HasColumnType<string>("varchar(255) CHARACTER SET utf8mb4");
                b.Property<string>("CategoryId").HasColumnType<string>("varchar(255) CHARACTER SET utf8mb4");
                b.Property<DateTime>("CreatedAt").HasColumnType<DateTime>("datetime(6)");
                b.Property<string>("Description").HasColumnType<string>("longtext CHARACTER SET utf8mb4");
                b.Property<DateTime>("ScheduledFor").HasColumnType<DateTime>("datetime(6)");
                b.Property<string>("Title").HasColumnType<string>("longtext CHARACTER SET utf8mb4");
                b.HasKey("Id");
                b.HasIndex("CategoryId");
                b.ToTable("Todos");
            }));
            modelBuilder.Entity("MyTodoApp.Domain.Entities.Todo", (Action<EntityTypeBuilder>)(b => b.HasOne("MyTodoApp.Domain.Entities.Category", "Category").WithMany("Todos").HasForeignKey("CategoryId")));
        }
    }
}