using System;

namespace TProject.Way
{
    public class TrafficLight: Entity
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        public bool isGreen { get; set; }

        private int CurrentTime { get; set; }
        
        public TrafficLight(int greenSeconds, int redSeconds):base()
        {
            Random rand = new Random();
            CurrentTime = rand.Next();
            isGreen = false;

            this.GreenSeconds = greenSeconds;
            this.RedSeconds = redSeconds;
            this.CurrentTime = 0;
        }

        public void Inc()
        {
            int time = CurrentTime;
            if (isGreen && (time + 1) > GreenSeconds || !isGreen && (time + 1) > RedSeconds)
            {
                CurrentTime++;
                isGreen = !isGreen;
            }
        }

    }
}
