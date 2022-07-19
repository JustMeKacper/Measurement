using System;
using System.ComponentModel.DataAnnotations;

namespace Measurement.Entities
{
    public class Progress
    {
        public virtual int UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual int MesId { get; set; }
        [Key]
        public int ProgressKey { get; set; }
        public string NameOfTask { get; set; }
        public double Limit { get; set; }
        public int Series { get; set; }

    }
}
