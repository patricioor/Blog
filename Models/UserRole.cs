using System.ComponentModel.DataAnnotations.Schema;

namespace Blogg.Models;

[Table("UserRole")]
public class UserRole
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}