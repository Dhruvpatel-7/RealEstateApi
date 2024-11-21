using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [ForeignKey("User_id")]
        public int User_id { get; set; }
        public string Report_message { get; set; }
    }
}
