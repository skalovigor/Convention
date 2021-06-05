using System.ComponentModel;

namespace Convention.Domain.Identity
{
    public enum RoleType
    {
        Unknown = 0,
        [Description("Admin")] Admin = 1
    }
}