using System;
using System.ComponentModel.DataAnnotations;

namespace Measurement.Entities
{
    public class Measurement
    {
        [Key]
        public int MesId { get; set; }
        public virtual int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Neck { get; set; }
        public double Chest { get; set; }
        public double Stomach { get; set; }
        public double Biceps { get; set; }
        public double Hips { get; set; }
        public double Thigh { get; set; }
        public double Calf { get; set; }
    }
}
