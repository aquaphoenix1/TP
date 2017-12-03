using System;
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

        internal static Sign GetSignByName(string name)
        {
            List<object> sign = ListSigns.FirstOrDefault(sgn => sgn[0].ToString().Equals(name));

            return (sign != null) ? CreateSign(sign[0].ToString(), double.Parse(sign[1].ToString())) : null;
        }
    }
}
