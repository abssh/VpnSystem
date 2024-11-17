namespace DataDomain.Types.States
{
    public static class BadStates
    {
        public static StateObject None = new StateObject(StateCode.None, "");
        public static StateObject UnHandled = new StateObject(StateCode.UnHandled, "un handled error");

        public static StateObject UsernameNotFound = new StateObject(StateCode.UsernameNotFound, "Username was not found");
        public static StateObject WrongPassword = new StateObject(StateCode.WrongPassword, "password is incorrect");

        public static StateObject UniqueConstraintDefault = new StateObject(StateCode.UniqueConstraintDefault, "unique constraint reached");
        public static StateObject UsernameAlreadyExists = new StateObject(StateCode.UsernameAlreadyExists, "username already exists");
        public static StateObject EmailAlreadyExists = new StateObject(StateCode.EmailAlreadyExists, "email already exists");
    }
}