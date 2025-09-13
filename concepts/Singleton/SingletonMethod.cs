namespace Singleton
{
    public class OfficeBoy
    {
        private static OfficeBoy _ref = null;
        private int _val;

        // Private constructor prevents external instantiation
        private OfficeBoy()
        {
            _val = 10;
        }

        // Public property to access _val
        public int Value
        {
            get { return _val; }
            set { _val = value; }
        }

        // ✅ This is the correct public static method
        public static OfficeBoy GetObject()
        {
            if (_ref == null)
                _ref = new OfficeBoy();
            return _ref;
        }
    }
}
