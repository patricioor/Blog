using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogg.Models;

[Table("Tag")]
public class Tag 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    [MinLength(3)]
    [Column("Name", TypeName = "NVARCHAR")]
    public string Name { get; set; }

    [Required]
    [MaxLength(80)]
    [MinLength(3)]
    [Column("Slug", TypeName = "VARCHAR")]
    public string Slug { get; set; }

    public IList<Post> Posts { get; set; }
}