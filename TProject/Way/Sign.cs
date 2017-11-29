using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Sign : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListSigns { get; set; }
        public double Count { get; set; }

        //Используется в "Работе с БД" для добавления.Даниил
        public Sign(string text,double count) : base(text)
        {
            this.ID = ++CurrentMaxID;
            this.Count = count;
        }

        private Sign() { }

        public static Sign CreateSign(long id, string text, double count)
        {
            return new Sign
            {
                ID = id,
                Count = count,
                TypeName = text
            };
        }
    }
}
