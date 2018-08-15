namespace Optimisation
{
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
        int ii = 0;
        while ( ii < lightCount )
        {
            decimal decimalDistance = (decimal) distanceList[ii];
            decimal decimalDuration = (decimal) durationList[ii];
            Console.Error.WriteLine($"distance {ii} est {decimalDistance}");
            Console.Error.WriteLine($"duration {ii} est {decimalDuration}");            
            decimal temps = decimalDistance / speedms;
            Console.Error.WriteLine($"Temps{ii} initial est {temps}");

            int ki = (int) Math.Floor(temps / (2 * decimalDuration));
            Console.Error.WriteLine($"K{ii} initial est {ki}");

            decimal k= (decimal) ki; 
            decimal speedmsi = speedms;
            Console.Error.WriteLine($"Speed {ii} initial m/s est {speedmsi}");
            while(!(k<=temps / (decimalDuration*2) && temps / (decimalDuration*2) < k+(decimal)0.5) && speedms > 0)
            {
                k= k + (decimal)1;
                Console.Error.WriteLine($"K{ii} monte à  {k}");
                decimal newSpeed = decimalDistance / (decimal) (2 * k * decimalDuration);
                if (speedmsi > newSpeed)
                {
                    speedmsi = newSpeed;
                    Console.Error.WriteLine($"Speed {ii} au pas {k} m/s est {speedmsi}");
                    temps = decimalDistance / speedmsi;
                    Console.Error.WriteLine($"Temps {ii} au pas {k} est {decimalDistance} / {speedmsi} = {temps}");
                }
            }
            Console.Error.WriteLine($"Speed {ii} m/s  est {speedmsi}");
            Console.Error.WriteLine($"Temps {ii} est {decimalDistance} / {speedmsi} = {temps}");
            if (speedmsi == speedms)
            {
                Console.Error.WriteLine($"Speed {ii} n'a pas changé");
                ii++;
                continue;
            }
            Console.Error.WriteLine($"Speed {ii} a changé. Vérifier la nouvelle vitesse pour les précédents cas");
            speedms = speedmsi;
            var j=ii-1;
            bool convientPourTousPrecedents = true;
            while (j>=0 && convientPourTousPrecedents)
            {
                decimal decimalDistanceJ = (decimal) distanceList[j];
                decimal decimalDurationJ = (decimal) durationList[j];
                Console.Error.WriteLine($"distance {j} est {decimalDistanceJ}");
                Console.Error.WriteLine($"duration {j} est {decimalDurationJ}");            
                decimal tempsj = decimalDistanceJ / speedms;
                Console.Error.WriteLine($"Temps {j} est {decimalDistanceJ} / {speedms} = {tempsj}");
                decimal kj = (decimal) Math.Floor(tempsj/ (2 *  decimalDurationJ));
                Console.Error.WriteLine($"K {j} est {kj}");
                if (!(kj<=tempsj / (decimalDurationJ*2) && tempsj / (decimalDurationJ*2) < kj+(decimal)0.5))
                {
                    Console.Error.WriteLine($"Temps {j} ne convient pas");
                    convientPourTousPrecedents = false;
                }
                else
                {
                    Console.Error.WriteLine($"Temps {j} convient");
                    j--;
                }
            }
            if (!convientPourTousPrecedents)
                ii=j;
            else
                ii++;
        }
        Console.Error.WriteLine($"Speed m/s est {speedms}");
        speed = (int) Math.Floor((decimal)(speedms * 3600 / 1000));
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(speed);
    }
}
}