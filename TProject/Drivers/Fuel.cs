using System.Collections.Generic;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        /// <summary>
        /// Список топлива
        /// </summary>
        public static List<List<object>> ListFuel { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// СОздание топлива
        /// </summary>
        /// <param name="typeName">Название топлива</param>
        /// <param name="price">Цена</param>
        public Fuel(string typeName, double price) : base(typeName)
        {
            this.Price = price;
        }

        private Fuel() { }

        /// <summary>
        /// Создание топлива
        /// </summary>
        /// <param name="typeName">Название топлива</param>
        /// <param name="price">Цена</param>
        /// <returns></returns>
        public static Fuel CreateFuel(string typeName, double price)
        {
            return new Fuel
            {
                TypeName = typeName,
                Price = price
            };
        }
    }
}
