using System.Collections.Generic;

namespace TProject.Way
{
    public class Police : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListTypePolicemen { get; set; }
        public double Coeff { get; set; }


        public Police(string typeName) : base(typeName)
        {
            this.ID = ++CurrentMaxID;
            switch (typeName)
            {
                case "Добрый":
                    {
                        this.Coeff = 1.0;
                        break;
                    }
                case "Жадный":
                    {
                        this.Coeff = 1.5;
                        break;
                    }
                case "Супер-ажный":
                    {
                        this.Coeff = 2.5;
                        break;
                    }
            }
        }

        private Police() { }

        public static Police CreatePolice(long id, string typeName)
        {
            Police police = new Police
            {
                ID = id,
                TypeName = typeName
            };

            switch (typeName)
            {
                case "Добрый":
                    {
                        police.Coeff = 1.0;
                        break;
                    }
                case "Жадный":
                    {
                        police.Coeff = 1.5;
                        break;
                    }
                case "Супер-ажный":
                    {
                        police.Coeff = 2.5;
                        break;
                    }
            }

            return police;
        }
    }
}
