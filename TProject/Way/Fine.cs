using System.Collections.Generic;

namespace TProject.Way
{
    public class Fine : Type
    {
        public static List<List<object>> ListFine { get; set; }
        public double Count { get; set; }

        public Fine(string name, double count) : base(name)
        {
            this.Count = count;
        }
    }
}
