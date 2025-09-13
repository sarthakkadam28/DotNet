namespace Singleton
{
    public class OfficeBoy
    {
        private static OfficeBoy _ref = null;
        private int _val;
        private OfficeBoy()
        {
            _val= 10;
        }
        public int value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }
        public static OfficeBoy GetObject()
        {
            if (_ref == null)
                _ref = new OfficeBoy();
            return _ref;
        }
    }
}