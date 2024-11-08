namespace DataDomain.Types.States
{
    public static class BadStates
    {
        public static StateObject None = new StateObject(StateCode.None, "");
        public static StateObject UsernameNotFound = new StateObject(StateCode.UsernameNotFound, "Username was not found");
        public static StateObject WrongPassword = new StateObject(StateCode.WrongPassword, "password is incorrect");
    }
}