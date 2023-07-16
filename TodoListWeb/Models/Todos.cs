using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.Models
{
    public class Todos
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập công việc!")]
        public string? Job { get; set; }

        public Boolean IsDone { get; set; } = false;
    }
}
