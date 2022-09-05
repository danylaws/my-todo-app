using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.Domain.Entities
{
    public class Category
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}