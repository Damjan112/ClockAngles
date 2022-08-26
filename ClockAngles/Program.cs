using System;

namespace ClockAngles
{
    class Program
    {
        private static int hours;
        private static int minutes;

        // Function to calculate the angle
        static int calcAngle(double hours, double minutes)
        {
            if (hours == 12)
                hours = 0;

            if (minutes == 60)
            {
                minutes = 0;
                hours += 1;
                if (hours > 12)
                    hours = hours - 12;
            }

            // calculate the angles moved by hour and
            // minute hands with reference to 12:00
            int calc_hour_angle = (int)(0.5 * (hours * 60 + minutes));
            int calc_minute_angle = (int)(6 * minutes);

            // find the angle between hour and minute arrow 
            int calculated_angle = Math.Abs(calc_hour_angle - calc_minute_angle);

            // this returns the smaller angle, if angle is > 180

            calculated_angle = Math.Min(360 - calculated_angle, calculated_angle);

            return calculated_angle;
        }


        public static void Main()
        {

            Console.WriteLine("Enter hours: ");

            hours = int.Parse(Console.ReadLine());
            if (hours < 0 || hours > 12)
            {
                Console.Write("Enter valid hours ");
                return;
            }
            Console.WriteLine("Enter minutes: ");
            minutes = int.Parse(Console.ReadLine());
            if (minutes < 0 || minutes > 60)
            {
                Console.Write("Enter valid minutes ");
                return;
            }

            Console.WriteLine($"Calculated angle is:{calcAngle(hours, minutes)}°");

        }
    }
}
