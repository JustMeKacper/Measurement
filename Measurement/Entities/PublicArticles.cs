using System.ComponentModel.DataAnnotations;

namespace Measurement.Entities
{
    public class PublicArticles
    {
        [Key]
        public int ArtId { get; set; }
        public virtual int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool ToVerify { get; set; }
    }
}
