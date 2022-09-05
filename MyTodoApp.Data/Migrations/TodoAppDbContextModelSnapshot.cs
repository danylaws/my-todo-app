using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MyTodoApp.Data.Migrations
{
    [DbContext(typeof(TodoAppDbContext))]
    internal class TodoAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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