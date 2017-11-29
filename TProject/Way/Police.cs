using System.Collections.Generic;

namespace TProject.Way
{
    public class Police : Type
    {
        public static long CurrentMaxID {  get; set; }                    //максимальный id.Даниил
        public static List<List<object>> ListTypePolicemen { get; set; }  //лист покрытий.Даниил
        public double Coeff { get; set; }                                 // коэффициент.Даниил

        //Используется в "Работе с БД" для добавления.Даниил
        public Police(string typeName, double coefficient) : base(typeName)
        {
            this.ID = ++CurrentMaxID;
            this.Coeff = coefficient;
        }
        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись.Даниил 
        /*public Police(long id, string typeName, double coefficient)
        {
            this.ID = id;
            this.TypeName = typeName;
            this.Coeff = coefficient;
        }*/

        public static Police CreatePolice(long id, string typeName, double coefficient)
        {
            Police police = new Police
            {
                ID = id,
                TypeName = typeName,
                Coeff = coefficient
            };

            return police;
        }

        private Police()
        { }
    }
}
