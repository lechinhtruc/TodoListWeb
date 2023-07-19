using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TodoListWeb.Models
{
    public class TodoModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập công việc!")]
        public required string JobName { get; set; }

        public bool IsDone { get; set; }


        [JsonIgnore]
        public DateTime? StartDate { get; set; }

        [JsonIgnore]
        public DateTime? EndDate { get; set; }
    }
}
