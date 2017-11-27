using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Sign : Type
    {
        public static long CurrentMaxID { private get; set; }
        public static List<List<object>> ListSigns { get; set; }
        public double Count { get; set; }

        //Используется в "Работе с БД" для добавления 
        public Sign(string text,double count) : base(text)
        {
            var sign = Sign.ListSigns.Select(i => i[0]).Max();
            CurrentMaxID = int.Parse(sign.ToString());
            this.ID = ++CurrentMaxID;
            this.Count = count;
        }
        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись 
        public Sign(int id, string text, double count) 
        {
            this.ID = id;
            this.Count = count;
        }
        public Sign newSign(int id, string text, double count)
        {
            this.ID = id;
            this.ID = ++CurrentMaxID;
            this.Count = count;
            return this ;
        }
        public Sign()
        {
           
        }


        /*public override string ToString()
        {
            return String.Format("Ограничение скорости {0} км/ч", MaxSpeed);
        }*/
    }
}
