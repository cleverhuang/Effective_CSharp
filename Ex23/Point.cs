using System;

namespace Ex23
{
    public class Point
    {

        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(System.IO.TextReader reader)
        {
            string line = reader.ReadLine();
            string[] fields = line.Split(',');
            if (fields.Length != 2)
            {
                throw new InvalidOperationException("Input format incorrect");
            }
            double value;
            if (!double.TryParse(fields[0], out value))
            {
                throw new InvalidOperationException("Could not parse X value");
            }
            else
            {
                X = value;
            }

            if (!double.TryParse(fields[1], out value))
            {
                throw new InvalidOperationException("Could not parse Y value");
            }
            else
            {
                Y = value;
            }
        }
    }
}
