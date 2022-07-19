using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.Models
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}