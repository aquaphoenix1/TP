using System;
using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Police : Type
    {
        public static List<List<object>> ListTypePolicemen { get; set; }
        public double Coeff { get; set; }


        public Police(string typeName) : base(typeName)
        {
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
                case "Супер-жадный":
                    {
                        this.Coeff = 2.5;
                        break;
                    }
            }
        }

        private Police() { }

        public static Police CreatePolice(string typeName)
        {
            Police police = new Police
            {
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
                case "Супер-жадный":
                    {
                        police.Coeff = 2.5;
                        break;
                    }
            }

            return police;
        }

        internal static Police GetPoliceByName(string name)
        {
            List<object> police = ListTypePolicemen.FirstOrDefault(pol => pol[0].ToString().Equals(name));

            return (police != null) ? CreatePolice(police[0].ToString()) : null;
        }
    }
}
