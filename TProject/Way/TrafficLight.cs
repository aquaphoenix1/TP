using System;

namespace TProject.Way
{
    public class TrafficLight : Entity
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        public delegate void TLightTurnMethod();
        public static event TLightTurnMethod TLightTurn;

        public bool IsGreen { get; set; }

        private int CurrentTime { get; set; }

        public TrafficLight(int greenSeconds, int redSeconds) : base()
        {
            Random rand = new Random();
            CurrentTime = rand.Next();
            IsGreen = false;

            this.GreenSeconds = greenSeconds;
            this.RedSeconds = redSeconds;
            this.CurrentTime = 0;
        }

        public void Inc()
        {
            int time = CurrentTime++;
            if (IsGreen && (time + 1) > GreenSeconds || !IsGreen && (time + 1) > RedSeconds)
            {
                TLightTurn();
                CurrentTime = 0;
                IsGreen = !IsGreen;
            }
        }

    }
}
