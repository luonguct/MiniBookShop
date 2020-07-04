using MiniShop.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Core.Entities
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [MaxLength(200)]
        [Required]
        [Column(TypeName = "nvarchar(200")]
        public string Title { get; set; }

        [MaxLength(4000)]
        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }

        public double Price { get; set; }

        [MaxLength(4000)]
        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        public string ImageUrl { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}