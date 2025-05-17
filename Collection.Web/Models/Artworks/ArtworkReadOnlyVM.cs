using System.ComponentModel.DataAnnotations;

namespace Collection.Web.Models.Artworks
{
    public class ArtworkReadOnlyVM : BaseArtworkVM
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Size in mm - H x W")]
        public string Size { get; set; } = string.Empty;
    }
}
