using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.Models
{
    public class TodosModel
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string? Job { get; set; }

        public Boolean IsDone { get; set; } = false;
    }
}
