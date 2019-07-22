using Abp.Authorization;
using Notes.WebApi.Authorization.Roles;
using Notes.WebApi.Authorization.Users;

namespace Notes.WebApi.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
