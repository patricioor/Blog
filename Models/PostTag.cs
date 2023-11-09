using System.ComponentModel.DataAnnotations.Schema;

namespace Blogg.Models;

[Table("PostTag")]
public class PostTag 
{
    public int PostId { get; set; }
    public int TagId { get; set; }
}