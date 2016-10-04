using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum DMLResultType
    {
        [EnumMember(Value = "SUCCEED")]
        SUCCEED,

        [EnumMember(Value = "FAILED")]
        FAILED
    }
}
