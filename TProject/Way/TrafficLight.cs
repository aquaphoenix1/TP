using System;

namespace TProject.Way
{
    public class TrafficLight : Entity
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        public delegate void TLightTurnMethod();
        public event TLightTurnMethod TLightTurn;

        public bool IsGreen { get; set; }
        public bool IsRun { get; set; }

        public int CurrentTime { get; set; }



        public TrafficLight(int greenSeconds, int redSeconds) : base()
        {
            Random rand = new Random();
            CurrentTime = rand.Next();
            IsGreen = false;
            IsRun = false;

            this.GreenSeconds = greenSeconds;
            this.RedSeconds = redSeconds;
            this.CurrentTime = 0;
        }

        private TrafficLight() { }

        public void Inc(int val = 1)
        {
            while (val-- != 0)
            {
                int time = CurrentTime++;
                if (IsGreen && (time + 1) > GreenSeconds || !IsGreen && (time + 1) > RedSeconds)
                {
                  //  TLightTurn?.Invoke();

                    CurrentTime = 0;
                    IsGreen = !IsGreen;
                }
            }
        }

        internal static TrafficLight CreateTrafficLight(long ID, int green, int red)
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
