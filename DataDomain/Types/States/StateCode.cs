namespace DataDomain.Types.States
{
    public enum StateCode{
        None,
        UnHandled,

        UsernameNotFound,
        WrongPassword,
        WrongCode,

        UniqueConstraintDefault,
        UsernameAlreadyExists,
        EmailAlreadyExists,

        ClientNotFound,
        CodeNotFound,
        CodeExpired,

        ClientAlreadyActivated,
        WrongSMTPConfig,

        TooFast
    }
}