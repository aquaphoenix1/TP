using System;

namespace TProject
{
    class TooLowSecondsException:ApplicationException
    {
        public TooLowSecondsException(string trafficLight) :
            base("Слишком маленькое значение времени " + trafficLight + " светофора.")
        { }
    }
}
