using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int speed = int.Parse(Console.ReadLine());
        Console.Error.WriteLine($"Max speed {speed}");
        decimal speedms = (decimal) speed * 1000 / 3600;
        Console.Error.WriteLine($"Max speed m/s est {speedms}");
        int lightCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int distance = int.Parse(inputs[0]);
            int duration = int.Parse(inputs[1]);
            Console.Error.WriteLine($"distance {i} est {distance}");
            Console.Error.WriteLine($"duration {i} est {duration}");
            decimal decimalDistance = (decimal) distance;
            decimal decimalDuration = (decimal) duration;
            int ki = (int) Math.Floor((decimalDistance / (2 * speedms
*decimalDuration)));
            Console.Error.WriteLine($"K{i} initial est {ki}");

            decimal k= (decimal) ki; 
            decimal temps = decimalDistance / speedms;
            Console.Error.WriteLine($"Temps{i} initial est {temps}");

            while(!(k<=temps / (decimalDuration*2) && temps / (decimalDuration*2) < k+(decimal)0.5) && speedms > 0)
            {
                k= k + (decimal)1;
                Console.Error.WriteLine($"K{i} monte à  {k}");
                speedms = Math.Min( speedms
,decimalDistance / (decimal) (2 * k * decimalDuration));
                Console.Error.WriteLine($"Speed {i} au pas {k} m/s est {speedms}");
                temps = decimalDistance / speedms;
                Console.Error.WriteLine($"Temps {i} au pas {k} est {decimalDistance} / {speedms} = {temps}");
            }
            Console.Error.WriteLine($"Speed {i} m/s  est {speedms}");
            Console.Error.WriteLine($"Temps {i} est {decimalDistance} / {speedms} = {temps}");
        }
        Console.Error.WriteLine($"Speed m/s est {speedms}");
        speed = (int) Math.Floor((decimal)(speedms * 3600 / 1000));
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(speed);
    }
}