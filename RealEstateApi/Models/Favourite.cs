using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApi.Models
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        [Required]
        [ForeignKey("Property_Id")]
        public int Property_Id { get; set; }
    }
}
