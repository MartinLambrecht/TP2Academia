namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }

        private int _ID;

        public int ID
        { set { _ID = value; } get { return _ID; } }

        private States _State;

        public States State
        { set { _State = value; } get { return _State; } }

        public enum States
        {
            Deleted = 0, New = 1, Modified = 2, Unmodified = 3
        }
    }
}