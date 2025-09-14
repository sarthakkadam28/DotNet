namespace Index
{
    public class Books
    {
        private string[] titles = new string[100];
        //The indexer is declared using the keyword this followed by an index parameter 
        //inside square brackets [int index].
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= 100)
                    return "0";                                //int number = 123;
                                                               // return = 0.ToString(); 
                else
                    return titles[index];
            }
            set
            {
                if (index < 0 || index >= 100)
                    return;
                else
                    titles[index] = value;
            }

        }
    }
}