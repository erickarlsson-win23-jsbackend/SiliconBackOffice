using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SiliconBackOffice.Services;

//Min plan var att använda samma identity-databas som min frontend-applikation (Silicon),
//och lägga till roller endast för backoffice-applikationen. Sedan tänkte jag lägga 
//@attribute [Authorize(Roles = "Admin")] på alla sidor förutom inloggning.


public class RoleService(RoleManager<IdentityRole> roleManager)
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<bool> CreateRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return false;
        }

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        return result.Succeeded;

    }
    public async Task<List<IdentityRole>> GetAllRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }
}
