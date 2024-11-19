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

        ClientAlreadyActivated,
        WrongSMTPConfig,

        TooFast
    }
}