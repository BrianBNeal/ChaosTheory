using System.ComponentModel.DataAnnotations;

namespace ChaosTheory.Library.Data.Models;

public class User
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string? Bio { get; set; }

    [Phone]
    public string? Phone { get; set; }
}
