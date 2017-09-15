namespace TProject
{
    class TrafficLight
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        private int CurrentTime { get; }
        
        public TrafficLight(int greenSeconds, int redSeconds)
        {
            this.GreenSeconds = greenSeconds;
            this.RedSeconds = redSeconds;
            this.CurrentTime = 0;
        }
    }
}
