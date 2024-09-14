using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApi.Models
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User_Id { get; set; }

        // Navigation property for relationship
        [ForeignKey("User_Id")]
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNo { get; set; }
        public string PropertySize { get; set; }
        public string PropertyConfiguration { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Aminities { get; set; }
    }
}
