using System.ComponentModel.DataAnnotations;

namespace Measurement.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MonitorType { get; set; }//ThingsToWatch
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
