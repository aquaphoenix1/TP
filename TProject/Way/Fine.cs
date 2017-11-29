using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    //Fine [ID] Integer , [NameFine] char(20), [CostFine] real 
    public class Fine : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListFine { get; set; }
        public double Count { get; set; }

        //Используется в "Работе с БД" для добавления .Даниил
        public Fine(string name, double count) : base(name)
        {
            var fine = Fine.ListFine.Select(i => i[0]).Max();
            if (fine == null) { CurrentMaxID = 0;  } else { CurrentMaxID = int.Parse(fine.ToString()); }
            this.ID = ++CurrentMaxID;
            this.Count = count;
        }

        private Fine() { }

        public static Fine CreateFine(long id, string name, double count)
        {
            Fine fine = new Fine
            {
                ID = id,
                TypeName = name,
                Count = count
            };

            return fine;
        }
    }
}
