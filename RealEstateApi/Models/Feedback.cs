using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User_id")]
        public int User_id { get; set; }
        [Required]
        [ForeignKey("Inquiry_id")]
        public int Inquiry_id { get; set; }
        public int Ratings { get; set; }
    }
}
