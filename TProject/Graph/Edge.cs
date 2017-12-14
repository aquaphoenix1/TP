using System;
using System.Collections.Generic;
using TProject.Way;

namespace TProject.Graph
{
    public class Edge : Entity
    {
        public static List<List<object>> StreetList { get; set; }

        /// <summary>
        /// Находится ли в маршруте текущая дуга
        /// </summary>
        public bool IsInWay = false;

        private Vertex HeadVertex { get; set; }
        private Vertex EndVertex { get; set; }

        /// <summary>
        /// Двусторонняя дорога
        /// </summary>
        public bool IsBilateral { get; set; }

        public Sign SignMaxSpeed { get; set; }

        public Police Policemen { get; set; }

        public string NameStreet { get; set; }

        public Coating Coat { get; set; }

        /// <summary>
        /// Получение длины дуги
        /// </summary>
        /// <param name="coefficient">Коэффициент масштабирования</param>
        /// <returns></returns>
        public double GetLength(double coefficient)
        {
            return coefficient * Math.Sqrt(Math.Pow(HeadVertex.X - EndVertex.X, 2) + Math.Pow(HeadVertex.Y - EndVertex.Y, 2));
        }

        public void SetEnd(Vertex B)
        {
            EndVertex = B;
        }

        /// <summary>
        /// Возвращение цены по критерию
        /// </summary>
        /// <param name="criterial">Критерий поиска</param>
        /// <param name="driver">Водитель</param>
        /// <returns></returns>
        internal double GetCriterialValue(Main.Criterial criterial, Driver.Driver driver)
        {
            switch (criterial)
            {
                case Main.Criterial.Length:
                    {
                        return GetLength(MakeMap.ViewPort.ScaleCoefficient);
                    }
                case Main.Criterial.Price:
                    {
                        return GetPrice(GetLength(MakeMap.ViewPort.ScaleCoefficient), driver);
                    }
                case Main.Criterial.Time:
                    {
                        return GetTime(driver);
                    }
            }

            return 0;
        }
        
        /// <summary>
        /// Цена дуги
        /// </summary>
        /// <param name="length">Длина дуги с учетом кожффициента</param>
        /// <param name="driver">Водитель</param>
        /// <returns></returns>
        private double GetPrice(double length, Driver.Driver driver)
        {
            double price = 0.0;

            price += (driver.Car.FuelConsumption / 100) * (length / 1000) * driver.Car.CarFuel.Price;

            //Если нарушитель превысил скорость на улице сполицейским
            if(driver.IsViolateTL && this.Policemen != null && SignMaxSpeed != null)
            {
                double different = driver.Car.Speed - SignMaxSpeed.Count;

                if (different > 19)
                {
                    if(different < 40)
                    {
                        price += this.Policemen.Coeff * 500;
                    }
                    else if (different < 60)
                    {
                        price += this.Policemen.Coeff * 1000;
                    }
                    else if (different < 80)
                    {
                        price += this.Policemen.Coeff * 2000;
                    }
                    else
                    {
                        price += this.Policemen.Coeff * 5000;
                    }
                }
            }

            return price;
        }

        /// <summary>
        /// Время дуги
        /// </summary>
        /// <param name="driver">Водитель</param>
        /// <returns></returns>
        public double GetTime(Driver.Driver driver)
        {
            Vertex end = this.EndVertex;
            int currentTime;
            bool isGreen;

            //Скорость с учетом типа водителя и знаков
            double price = 0;
            double speed = SignMaxSpeed != null ? SignMaxSpeed.Count : 60;
            speed = driver.IsViolateTL ? driver.Car.Speed : speed;

            //Перевод м/с в км/ч
            speed = speed * 1000 / 3600;

            double time = GetLength(MakeMap.ViewPort.ScaleCoefficient) / speed * Coat.Coeff;

            //Ожидание светофора на дуге
            if (end.TrafficLight != null)
            {
                end.TrafficLight.CurrentTime = new Random().Next(0, end.TrafficLight.GreenSeconds + 1);
                end.TrafficLight.IsGreen = true;
                
                currentTime = end.TrafficLight.CurrentTime;
                isGreen = end.TrafficLight.IsGreen;

                end.TrafficLight.Inc((int)(time * 60 * 60));

                if (!end.TrafficLight.IsGreen)
                {
                    price += end.TrafficLight.RedSeconds - end.TrafficLight.CurrentTime;
                }
                end.TrafficLight.CurrentTime = currentTime;
                end.TrafficLight.IsGreen = isGreen;
            }

            price += time;

            return price;
        }

        public Vertex GetHead()
        {
            return HeadVertex;
        }
        public Vertex GetEnd()
        {
            return EndVertex;
        }

        private Edge() : base() {
            IsBilateral = true;
        }

        /// <summary>
        /// Создание дуги
        /// </summary>
        /// <param name="v1">Первая вершина</param>
        /// <param name="v2">Вторая вершина</param>
        public Edge(Vertex v1, Vertex v2) : base()
        {
            IsBilateral = true;
            HeadVertex = v1;
            EndVertex = v2;
        }

        public bool IsConnected(Vertex vertex)
        {
            return this.EndVertex == vertex;
        }
        
        /// <summary>
        /// Создание дуги. Фабрика.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="head">Исходная вершина</param>
        /// <param name="end">Конечная вершина</param>
        /// <param name="coat">Дорожное покрытие</param>
        /// <param name="name">Название улицы</param>
        /// <param name="isBelaterial">Дусторонняя дорога</param>
        /// <param name="signMaxSpeed">Знак ограничения скорости</param>
        /// <param name="polieceman">Полицейский</param>
        /// <returns></returns>
        public static Edge CreateEdge(long ID, Vertex head, Vertex end, Coating coat, string name, bool isBelaterial, Sign signMaxSpeed, Police polieceman)
        {
            return new Edge
            {
                ID = ID,
                HeadVertex = head,
                EndVertex = end,
                NameStreet = name,
                Coat = coat,
                IsBilateral = isBelaterial,
                SignMaxSpeed = signMaxSpeed,
                Policemen = polieceman
            };
        }
    }
}
