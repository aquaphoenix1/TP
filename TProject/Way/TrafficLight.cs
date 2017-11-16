﻿using System;
using System.Collections.Generic;

namespace TProject.Way
{
    public class TrafficLight : Entity
    {
        public int GreenSeconds { get; set; }
        public int RedSeconds { get; set; }

        public delegate void TLightTurnMethod();
        public static event TLightTurnMethod tLightTurn;

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
                tLightTurn();
                CurrentTime = 0;
                IsGreen = !IsGreen;
            }
        }

    }
}
