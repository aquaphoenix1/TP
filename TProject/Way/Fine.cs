using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    //Fine [ID] Integer , [NameFine] char(20), [CostFine] real 
    public class Fine : Type
    {
        public static long CurrentMaxID { private get; set; }
        public static List<List<object>> ListFine { get; set; }
        public double Count { get; set; }

        //Используется в "Работе с БД" для добавления 
        public Fine(string name, double count) : base(name)
        {
            var fine = Fine.ListFine.Select(i => i[0]).Max();
            CurrentMaxID = int.Parse(fine.ToString());
            this.ID = ++CurrentMaxID;
            this.Count = count;
        }
        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись 
        public Fine(int id, string name, double count) 
        {
            this.ID = ++CurrentMaxID;
            this.TypeName = name;
            this.Count = count;
        }
    }
}
