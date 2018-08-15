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
        var distanceList = new List<decimal>();
        var durationList = new List<decimal>();
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int distance = int.Parse(inputs[0]);
            int duration = int.Parse(inputs[1]);
            Console.Error.WriteLine($"distance {i} est {distance}");
            Console.Error.WriteLine($"duration {i} est {duration}");
            decimal decimalDistance = (decimal) distance;
            distanceList.Add(decimalDistance);
            decimal decimalDuration = (decimal) duration;
            durationList.Add(decimalDuration);
        }
        int i = 0;
        while ( i < lightCount )
        {
            decimal decimalDistance = (decimal) distanceList(i);
            decimal decimalDuration = (decimal) durationList(i);
            decimal temps = decimalDistance / speedms;
            Console.Error.WriteLine($"Temps{i} initial est {temps}");

            int ki = (int) Math.Floor(temps / (2 * decimalDuration)));
            Console.Error.WriteLine($"K{i} initial est {ki}");

            decimal k= (decimal) ki; 

            while(!(k<=temps / (decimalDuration*2) && temps / (decimalDuration*2) < k+(decimal)0.5) && speedms > 0)
            {
                k= k + (decimal)1;
                Console.Error.WriteLine($"K{i} monte à  {k}");
                decimal newSpeed = decimalDistance / (decimal) (2 * k * decimalDuration);
                if (speedms > newSpeed)
                {
                    speedms = newSpeed;
                    Console.Error.WriteLine($"Speed {i} au pas {k} m/s est {speedms}");
                    temps = decimalDistance / speedms;
                    Console.Error.WriteLine($"Temps {i} au pas {k} est {decimalDistance} / {speedms} = {temps}");
                }
            }
            Console.Error.WriteLine($"Speed {i} m/s  est {speedms}");
            Console.Error.WriteLine($"Temps {i} est {decimalDistance} / {speedms} = {temps}");
            Console.Error.WriteLine($"Vérifier la nouvelle vitesse pour les précédents cas");
            var j=i-1;
            while (j>=0)
            {
                decimal decimalDistanceJ = (decimal) distanceList(j);
                decimal decimalDurationJ = (decimal) durationList(j);
                decimal tempsj = decimalDistanceJ / speedms;
                Console.Error.WriteLine($"Temps {j} est {decimalDistanceJ} / {speedms} = {tempsj}");
                decimal kj = (decimal) Math.Floor((tempsj/ (2 *  decimalDurationJ));
                if (!(kj<=tempsj / (decimalDuration*2) && tempsj / (decimalDuration*2) < kj+(decimal)0.5))
                {
                    Console.Error.WriteLine($"Temps {j} ne convient pas");
                    break;
                }
                //else
                j--;
            }
            if (j != -1)
                i=j;
            else
                i++;
        }
        Console.Error.WriteLine($"Speed m/s est {speedms}");
        speed = (int) Math.Floor((decimal)(speedms * 3600 / 1000));
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(speed);
    }
}