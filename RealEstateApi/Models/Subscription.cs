using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Property_Id")]
        public int Property_Id { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
