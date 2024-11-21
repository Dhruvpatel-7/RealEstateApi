using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class Gallary
    {
        [Key]
        public int Id { get; set; }
        public string Img_name { get; set; }
        public string Path { get; set; }
        [Required]
        [ForeignKey("Property_Id")]
        public int Property_Id { get; set; }
    }
}
