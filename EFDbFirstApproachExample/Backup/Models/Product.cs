using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFDbFirstApproachExample.Custom_Validations;

namespace EFDbFirstApproachExample.Models
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Display(Name ="Product Name")]
        [Required(ErrorMessage = "Product Name Can't be blank")]
        [RegularExpression(@"^[A-Za-z ]*$",ErrorMessage ="Alpha Only")]
        [MaxLength(40,ErrorMessage ="Product Name Can't Exceed 40 Characters")]
        [MinLength(2, ErrorMessage = "Product Name Should atleast have 2 Characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price Name Can't be blank")]
        [Range(0,10000,ErrorMessage ="Price must be Rs 0-100000")]
        [DivisibleBy10(ErrorMessage ="Price must be in Multiples of 10")]
        public Nullable<decimal> Price { get; set; }

        [Column("DateOfPurchase",TypeName ="datetime")]
        [Display(Name ="Date Of Purchase")]
        [Required]
        public Nullable<System.DateTime> DOP { get; set; }
        [Display(Name ="Availability Status")]
        [Required(ErrorMessage = "Availability Status Can't be blank")]
        public string AvailabilityStatus { get; set; }
        [Display(Name ="Category ID")]
        [Required(ErrorMessage = "CategoryID Can't be blank")]
        public Nullable<long> CategoryID { get; set; }
        [Display(Name ="Brand ID")]
        [Required(ErrorMessage = "BrandID Can't be blank")]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}