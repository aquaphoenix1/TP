using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.Way
{
    public class Sign:Type
    {
        public static List<Sign> collection;

        public static string Text = "Ограничение скорости {0} км/ч";
        public int MaxSpeed;

        public static void Init(){}

        static Sign()
        {
            collection = new List<Sign>();
            collection.Add(new Sign(20));
            collection.Add(new Sign(40));
            collection.Add(new Sign(60));
        }

        public Sign(int speed):base(Text)
        {
            MaxSpeed = speed;
        }

        public override string ToString()
        {
            return String.Format(Text, MaxSpeed);
        }
    }
}
