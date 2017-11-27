using System.Collections.Generic;

namespace TProject.Way
{
    public class Police : Type
    {
        public static long CurrentMaxID { private get; set; }             //максимальный id
        public static List<List<object>> ListTypePolicemen { get; set; }  //лист покрытий
        public double Coeff { get; set; }                                 // коэффициент

        //Используется в "Работе с БД" для добавления 
        public Police(string typeName, double coefficient) : base(typeName)
        {
            this.ID = ++CurrentMaxID;
            this.Coeff = coefficient;
        }
        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись 
        public Police(int id, string typeName, double coefficient)
        {
            this.ID = id;
            this.TypeName = typeName;
            this.Coeff = coefficient;
        }
    }
}
