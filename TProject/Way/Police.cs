using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Police : Type
    {
        /// <summary>
        /// Список полицейских
        /// </summary>
        public static List<List<object>> ListTypePolicemen { get; set; }

        public double Coeff { get; set; }

        private Police() { }

        /// <summary>
        /// Создание полицейского. Фабрика.
        /// </summary>
        /// <param name="typeName">Тип полицейского: Добрый, Жадный, Супер-жадный</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение полицейского по типу
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Полицейский</returns>
        public static Police GetPoliceByName(string name)
        {
            List<object> police = ListTypePolicemen.FirstOrDefault(pol => pol[0].ToString().Equals(name));

            return (police != null) ? CreatePolice(police[0].ToString()) : null;
        }
    }
}
