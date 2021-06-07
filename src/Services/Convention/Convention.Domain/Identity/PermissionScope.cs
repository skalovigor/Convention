using System.ComponentModel;

namespace Convention.Domain.Identity
{
    public enum PermissionScope
    {
        [Description("talk:create")]
        TalkCreate,
        [Description("talk:approve")]
        TalkApprove,
        [Description("talk:remove")]
        TalkRemove,
        [Description("manage:convention")]
        ConventionCreate,
        [Description("speaker:approve")]
        SpeakerApprove,
        [Description("speaker:remove")]
        SpeakerRemove,
    }
}