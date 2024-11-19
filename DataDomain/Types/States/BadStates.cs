namespace DataDomain.Types.States
{
    public static class BadStates
    {
        public static StateObject None = new StateObject(StateCode.None, "");
        public static StateObject UnHandled = new StateObject(StateCode.UnHandled, "un handled error");

        public static StateObject UsernameNotFound = new StateObject(StateCode.UsernameNotFound, "Username was not found");
        public static StateObject WrongPassword = new StateObject(StateCode.WrongPassword, "password is incorrect");
        public static StateObject WrongCode = new StateObject(StateCode.WrongCode, "code is incorrect");

        public static StateObject UniqueConstraintDefault = new StateObject(StateCode.UniqueConstraintDefault, "unique constraint reached");
        public static StateObject UsernameAlreadyExists = new StateObject(StateCode.UsernameAlreadyExists, "username already exists");
        public static StateObject EmailAlreadyExists = new StateObject(StateCode.EmailAlreadyExists, "email already exists");

        public static StateObject ClientNotFound = new StateObject(StateCode.ClientNotFound, "client was not found");
        public static StateObject CodeNotFound = new StateObject(StateCode.CodeNotFound, "code object was not found");

        public static StateObject ClientAlreadyActivated = new StateObject(StateCode.ClientAlreadyActivated, "client has already been activated");
        public static StateObject WrongSMTPConfig = new StateObject(StateCode.WrongSMTPConfig, "smtp configs where wrong");

        public static StateObject TooFast = new StateObject(StateCode.TooFast, "action was repreformed too fast");
    }
}