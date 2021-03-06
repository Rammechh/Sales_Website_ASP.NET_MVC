using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company.DomainModels
{

    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Can't be blank")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alpha Only")]
        [MaxLength(40, ErrorMessage = "Product Name Can't Exceed 40 Characters")]
        [MinLength(2, ErrorMessage = "Product Name Should atleast have 2 Characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price Name Can't be blank")]
        [Range(0, 1000000, ErrorMessage = "Price must be Rs 0-1000000")]
        [DivisibleBy10(ErrorMessage = "Price must be in Multiples of 10")]
        public Nullable<decimal> Price { get; set; }

        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date Of Purchase")]
        [Required]
        [DisplayFormat(DataFormatString = "M/d/yyyy", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOP { get; set; }

        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Availability Status Can't be blank")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "CategoryID Can't be blank")]
        public long CategoryID { get; set; }

        [Display(Name = "Brand ID")]
        [Required(ErrorMessage = "BrandID Can't be blank")]
        public long BrandID { get; set; }

        public bool Active { get; set; }
        public string Photo { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
