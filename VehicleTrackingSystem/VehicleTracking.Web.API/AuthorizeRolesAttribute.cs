using Domain;
using System.Linq;
using System.Web.Http;

namespace Web.API
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserRoles[] roles) : base()
        {
            var allowedRoles = roles.Select(r => r.ToString("d"));
            Roles = string.Join(",", allowedRoles);
        }
    }
}