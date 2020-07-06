using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniShop.Core.Entities
{
    [Table("BookCategories")]
    public class BookCategory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookCategoryId { get; set; }

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
    }
}
