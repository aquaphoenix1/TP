using System.Collections.Generic;

namespace TProject.Way
{
    public class Sign : Type
    {
        public static List<List<object>> ListSigns { get; set; }
        public double Count { get; set; }

        public Sign(double count, string text) : base(text)
        {
            this.Count = count;
        }

        /*public override string ToString()
        {
            return String.Format("Ограничение скорости {0} км/ч", MaxSpeed);
        }*/
    }
}
