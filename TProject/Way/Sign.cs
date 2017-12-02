using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Sign : Type
    {
        public static List<List<object>> ListSigns { get; set; }
        public double Count { get; set; }

        public Sign(string text, double count) : base(text)
        {
            this.Count = count;
        }

        private Sign() { }

        public static Sign CreateSign(string text, double count)
        {
            return new Sign
            {
                Count = count,
                TypeName = text
            };
        }
    }
}
