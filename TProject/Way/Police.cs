﻿using System.Collections.Generic;

namespace TProject.Way
{
    public class Police : Type
    {
        public static List<List<object>> ListTypePolicemen { get; set; }
        public double Coeff { get; set; }

        public Fine FineValue { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public class Fine
        {
            public static List<List<object>> ListFine { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }

            public Fine(string name, int count)
            {
                this.Name = name;
                this.Count = count;
            }
        }

        public Police(string typeName, double coefficient, Fine fine, int x, int y) : base(typeName)
        {
            this.Coeff = coefficient;
            this.FineValue = fine;
            this.X = x;
            this.Y = y;
        }
    }
}
