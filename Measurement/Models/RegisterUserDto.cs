using Measurement.Entities;
using System.ComponentModel.DataAnnotations;

namespace Measurement.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
        public string MonitorType { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
