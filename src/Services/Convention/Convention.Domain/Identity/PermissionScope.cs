using System.ComponentModel;

namespace Convention.Domain.Identity
{
    public enum PermissionScope
    {
        [Description("talk:create")]
        TalkCreate,
        [Description("talk:approve")]
        TalkApprove,
        [Description("convention:create")]
        ConventionCreate,
        [Description("profile")]
        Profile
    }
}