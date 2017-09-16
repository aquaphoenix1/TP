using System;

namespace TProject
{
    class TooManySecondsException : ApplicationException
    {
        public TooManySecondsException(string trafficLight) :
            base("Превышено максимальное значение " + trafficLight + " светофора.")
        { }
    }
}
