namespace DataDomain.Types.States
{
    public enum StateCode{
        None,
        UnHandled,
        UsernameNotFound,
        WrongPassword,
        UniqueConstraintDefault,
        UsernameAlreadyExists,
        EmailAlreadyExists,
    }
}