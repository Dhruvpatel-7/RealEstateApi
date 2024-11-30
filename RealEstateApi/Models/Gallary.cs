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
        [ForeignKey("PropertyId ")]
        public int PropertyId { get; set; }

        public Properties Property { get; set; }
    }
}
