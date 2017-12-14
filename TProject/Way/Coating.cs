using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Coating : Type
    {
        /// <summary>
        /// Список дорожных покрытий
        /// </summary>
        public static List<List<object>> ListSurface { get; set; }

        public double Coeff { get; set; }

        /// <summary>
        /// Создание дорожного покрытия
        /// </summary>
        /// <param name="typeName">Название</param>
        /// <param name="coefficient">Коэффициент скольжения</param>
        public Coating(string typeName, double coefficient) : base(typeName)
        {
            this.Coeff = coefficient;
        }

        private Coating() { }

        /// <summary>
        /// Создание дорожного покрытия. Фабрика.
        /// </summary>
        /// <param name="typeName">Название</param>
        /// <param name="coefficient">Коэффициент скольжения</param>
        /// <returns></returns>
        public static Coating CreateCoating(string typeName, double coefficient)
        {
            return new Coating
            {
                Coeff = coefficient,
                TypeName = typeName
            };
        }

        /// <summary>
        /// Получение дорожного покрытия по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Дорожное покрытие</returns>
        public static Coating GetCoatingByName(string name)
        {
            List<object> coat = ListSurface.First(coating => coating[0].ToString().Equals(name));

            return CreateCoating(coat[0].ToString(), double.Parse(coat[1].ToString()));
        }
    }
}
