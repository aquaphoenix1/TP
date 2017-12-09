using System;
using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Sign
    {
        public static List<List<object>> ListSigns { get; set; }
        public int Count { get; set; }

        public Sign(int count)
        {
            this.Count = count;
        }

        private Sign() { }

        public static Sign CreateSign(int count)
        {
            return new Sign
            {
                Count = count
            };
        }

        internal static Sign GetSignBySpeed(int speed)
        {
            List<object> sign = ListSigns.FirstOrDefault(sgn => int.Parse(sgn[0].ToString()) == speed);

            return (sign != null) ? CreateSign(int.Parse(sign[0].ToString())) : null;
        }
    }
}
