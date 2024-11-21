using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class Inquiry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User_id")]
        public int User_id { get; set; }
        [Required]
        [ForeignKey("Property_Id")]
        public int Property_Id { get; set; }
        public int Message { get; set; }
    }
}
