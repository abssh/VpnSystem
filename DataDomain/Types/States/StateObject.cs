namespace DataDomain.Types.States
{
    public class StateObject
    {
        public StateCode stateCode = StateCode.None;
        public string message = "";

        public StateObject(StateCode stateCode, string message)
        {
            this.stateCode = stateCode;
            this.message = message;
        }
        public static bool isState(StateObject one, StateObject two)
        {
            return one.stateCode == two.stateCode;
        }
    }
}
