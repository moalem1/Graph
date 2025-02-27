﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void ToPrintPoint()
        {
            Console.WriteLine("(" + this.X + ", " + this.Y + ")");
        }

        public static List<Point> culc_points(Equation e)
        {
            List<Point> Points = new List<Point>();
            double a = 0;
            double b = 0;
            double c = 0;

            //משוואה עם שתי איברים מלאים
            if (e.Count == 2 && e.Class == 1)
            {
                double a1 = e.Parameters[0].Value;
                double b1 = e.Parameters[1].Value;
                double x = (-b1 / a1);
                Points.Add(new Point(x, 0));
                Points.Add(new Point(0, b1));
            }


            //משוואה עם שלושה איברים מלאים
            else if (e.Count == 3 && e.Class == 2)
            {
                a = e.Parameters[0].Value; //להכפיל באופרטור
                b = e.Parameters[1].Value;//להכפיל באופרטור
                c = e.Parameters[2].Value; //להכפיל באופרטור

            }

            //משוואה עם שתי איברים ממעלה שניה - a, b
            else if (e.Count == 2 && e.Class == 2 && e.Parameters[1].Class == 1)
            {
                a = e.Parameters[0].Value;
                b = e.Parameters[1].Value;
                c = 0;

            }

            //משוואה עם שתי איברים ממעלה שניה - a, c
            else if (e.Count == 2 && e.Class == 2 && e.Parameters[1].Class == 0)
            {
                a = e.Parameters[0].Value;
                b = 0;
                c = e.Parameters[1].Value;
            }


            Console.WriteLine();
            Console.WriteLine("print a, b, c");
            Console.WriteLine("a= " + a + "\nb= " + b + "\nc= " + c);
            Console.WriteLine();

            //חישוב טרינום -נקודות חיתוך עם ציר האיקס
            double x1 = ((-b) + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            double x2 = ((-b) - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            Points.Add(new Point(x1, 0));
            Points.Add(new Point(x2, 0));
            Console.WriteLine("print Cutting points");

            Console.WriteLine();

            //חישוב קודקוד הפונקציה - נקודת קיצון
            double Xkodkod = (-b) / (2 * a);
            double Ykodkod = (a * Math.Pow(Xkodkod, e.Parameters[0].Class)
                + (b * Math.Pow(Xkodkod, e.Parameters[1].Class))
                + (c * Math.Pow(Xkodkod, e.Parameters[2].Class)));
            Console.WriteLine("kodkod");
            Points.Add(new Point(Xkodkod, Ykodkod));
            //Console.WriteLine("(" + Xkodkod + ", " + Ykodkod + ")");

            //חישוב נגזרת הפונקציה
            string derivative = (a * (Convert.ToInt32(e.Parameters[0].Class.ToString()))).ToString();//נגזרת
            derivative = derivative += "x " + e.Parameters[1].Value;
            //Console.WriteLine("f(x) = " + strGraph);
            Console.WriteLine("f'(x) = " + derivative);
            Console.WriteLine();
            return Points;
        }


    }
    
}
