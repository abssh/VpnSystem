namespace DataDomain.Types.States
{
    public enum StateCode{
        None,
        UsernameNotFound,
        WrongPassword,
        UniqueConstraintDefault,
        UsernameAlreadyExists,
        EmailAlreadyExists,
    }
}