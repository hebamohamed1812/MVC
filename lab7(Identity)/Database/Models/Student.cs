using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab7_Identity_.Database;

public class Student : IdentityUser
{
    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }
}
