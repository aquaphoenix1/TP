namespace TProject.Way
{
    public class TrafficLight : Entity
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        public bool IsGreen { get; set; }
        public bool IsRun { get; set; }

        public int CurrentTime { get; set; }

        /// <summary>
        /// Создание светофора
        /// </summary>
        /// <param name="greenSeconds">Время зеленой фазы</param>
        /// <param name="redSeconds">Время красной фазы</param>
        public TrafficLight(int greenSeconds, int redSeconds) : base()
        {
            IsGreen = false;
            IsRun = false;

            this.GreenSeconds = greenSeconds;
            this.RedSeconds = redSeconds;
            this.CurrentTime = 0;
        }

        private TrafficLight() { }

        /// <summary>
        /// Увеличение тика светофора
        /// </summary>
        /// <param name="val">Количество тиков</param>
        public void Inc(int val = 1)
        {
            while (val-- != 0)
            {
                int time = CurrentTime++;
                if (IsGreen && (time + 1) > GreenSeconds || !IsGreen && (time + 1) > RedSeconds)
                {
                    CurrentTime = 0;
                    IsGreen = !IsGreen;
                }
            }
        }

        /// <summary>
        /// Создание светофора. Фабрика.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="green">Время зеленой фазы</param>
        /// <param name="red">Время красной фазы</param>
        /// <returns></returns>
        public static TrafficLight CreateTrafficLight(long ID, int green, int red)
        {
            return new TrafficLight
            {
                ID = ID,
                GreenSeconds = green,
                RedSeconds = red
            };
        }
    }
}
