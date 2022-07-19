using System.ComponentModel.DataAnnotations;

namespace Measurement.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public virtual int UserId { get; set; }

    }
}
