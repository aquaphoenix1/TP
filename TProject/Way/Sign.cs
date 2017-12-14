using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Sign
    {
        /// <summary>
        /// Список знаков
        /// </summary>
        public static List<List<object>> ListSigns { get; set; }

        public int Count { get; set; }

        private Sign() { }

        /// <summary>
        /// Создание знака. Фабрика.
        /// </summary>
        /// <param name="count">Ограничение максимальной скорости</param>
        /// <returns></returns>
        public static Sign CreateSign(int count)
        {
            return new Sign
            {
                Count = count
            };
        }

        /// <summary>
        /// Получение знака по ограничению максимальной скорости
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <returns></returns>
        public static Sign GetSignBySpeed(int speed)
        {
            List<object> sign = ListSigns.FirstOrDefault(sgn => int.Parse(sgn[0].ToString()) == speed);

            return (sign != null) ? CreateSign(int.Parse(sign[0].ToString())) : null;
        }
    }
}
