using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength (maximumLength:30)]
        public string Title { get; set; }
        [StringLength(maximumLength: 300)]
        public string Description { get; set; }
        public string? Image { get; set; }
        public string REdirectUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
