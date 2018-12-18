using System;

namespace ManoResourceConverter
{
    [Serializable]
    public class Serial
    {
        public char key;
        public string value;

        public Serial() { }

        public Serial(char k, string v)
        {
            key = k;
            value = v;
        }
    }
}
