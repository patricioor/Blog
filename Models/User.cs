using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogg.Models;

[Table("User")]
public class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(80)]
    [MinLength(3)]
    [Column("Name", TypeName = "NVARCHAR")]
    public string Name { get; set; }
    public string Email {get; set;}
    public string PasswordHash { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }

    [Required]
    [MaxLength(80)]
    [MinLength(3)]
    [Column("Slug", TypeName = "VARCHAR")]
    public string Slug { get; set; }
}