using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingPro.DataAccessLayer.Model
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? ContactNo { get; set; }
        public string? CompanyVatNo { get; set; }
        public string? CompanyEmail { get; set; }
        public string? Slogan1 { get; set; }
        public string? Slogan2 { get; set; }
        public string? Slogan3 { get; set; }
    }
}
