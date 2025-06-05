using Microsoft.AspNetCore.Identity;

namespace MarketPanel.Models.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
