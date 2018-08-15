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
        float speedms = (float) speed * 1000 / 3600;
        Console.Error.WriteLine($"Max speed m/s est {speedms}");
        int lightCount = int.Parse(Console.ReadLine());
        var distanceList = new List<float>();
        var durationList = new List<float>();
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int distance = int.Parse(inputs[0]);
            int duration = int.Parse(inputs[1]);
            Console.Error.WriteLine($"distance {i} est {distance}");
            Console.Error.WriteLine($"duration {i} est {duration}");
            float decimalDistance = (float) distance;
            distanceList.Add(decimalDistance);
            float decimalDuration = (float) duration;
            durationList.Add(decimalDuration);
        }
        int ii = 0;
        while ( ii < lightCount )
        {
            float decimalDistance = (float) distanceList[ii];
            float decimalDuration = (float) durationList[ii];
            Console.Error.WriteLine($"distance {ii} est {decimalDistance}");
            Console.Error.WriteLine($"duration {ii} est {decimalDuration}");            
            float temps = decimalDistance / speedms;
            Console.Error.WriteLine($"Temps{ii} initial est {temps}");

            int ki = (int) Math.Floor(temps / (2 * decimalDuration));
            Console.Error.WriteLine($"K{ii} initial est {ki}");

            float k= (float) ki; 
            float speedmsi = speedms;
            Console.Error.WriteLine($"Speed {ii} initial m/s est {speedmsi}");
            while(!(k<=temps / (decimalDuration*2) && temps / (decimalDuration*2) < k+(float)0.5) && speedms > 0)
            {
                k= k + (float)1;
                Console.Error.WriteLine($"K{ii} monte à  {k}");
                float newSpeed = decimalDistance / (float) (2 * k * decimalDuration);
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
                float decimalDistanceJ = (float) distanceList[j];
                float decimalDurationJ = (float) durationList[j];
                Console.Error.WriteLine($"distance {j} est {decimalDistanceJ}");
                Console.Error.WriteLine($"duration {j} est {decimalDurationJ}");            
                float tempsj = decimalDistanceJ / speedms;
                Console.Error.WriteLine($"Temps {j} est {decimalDistanceJ} / {speedms} = {tempsj}");
                float kj = (float) Math.Floor(tempsj/ (2 *  decimalDurationJ));
                Console.Error.WriteLine($"K {j} est {kj}");
                if (!(kj<=tempsj / (decimalDurationJ*2) && tempsj / (decimalDurationJ*2) < kj+(float)0.5))
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
        speed = (int) Math.Round((float)(speedms * 3600 / 1000));
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(speed);
    }
}
}