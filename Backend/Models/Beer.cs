using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Beer
    {
        // indicamos pk Entity Framework
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")] // para decimal debemos indicar q es decimal, largo de 18, tomara 2 para decimales
        public decimal Alcohol { get; set; }

        // relacionamos con brand:
        public int BrandID { get; set; }
        
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }

    }
}
