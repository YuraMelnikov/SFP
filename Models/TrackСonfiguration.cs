using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TrackСonfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTrack { get; set; }
        [Required]
        public int IdSeason { get; set; }
        [Required]
        public int IdImagesGpConfiguration { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int IdImageGp { get; set; }

        [ForeignKey("IdImageGp")]
        public ImageGP ImageGp { get; set; }
        [ForeignKey("IdTrack")]
        public  Track Track { get; set; }
        [ForeignKey("IdSeason")]
        public  Season Season { get; set; }
        [ForeignKey("IdImagesGpConfiguration")]
        public  ImageGPTrackConfiguration ImagesGpConfiguratione { get; set; }
    }
}
