using System.ComponentModel.DataAnnotations;

namespace Collection.Web.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        //[Required]
        //public string Artist { get; set; }
        //[Required]
        //public string Technique { get; set; }
        [Required]
        [Display(Name = "Size in mm, H x W")]
        public string Size { get; set; } = string.Empty;
        //[Required]
        //public string ImageUrl { get; set; }
    }
}
