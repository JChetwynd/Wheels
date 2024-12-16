using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Engine.models;

namespace ConsoleRunner
{
    public class Runner
    {
        public WheelSet WheelSetP1 { get; private set; }

        public Runner(WheelSet wheelSetP1)
        {
            WheelSetP1 = wheelSetP1;
        }

        public void run()
        {

            Console.WriteLine("Welcome to wheels");
            while (true) 
            {
                SpinWheels(WheelSetP1);

            }
        }

        public void SpinWheels(WheelSet wheelSet)
        {
            Console.WriteLine("Player 1 spinner, press enter to spin the wheels");
            Console.ReadLine();

            List<WheelFace?> currentWheels = wheelSet.SpinWheels().Select(w => w.WheelFaces.Where(wf => wf.InPlay.IsFacingUp == true).FirstOrDefault()).ToList();


            var stringToWrite = string.Join("", currentWheels.Select(
                x => x.XpBonus ? 
                $"{currentWheels.IndexOf(x) + 1}: ** {x.Symbol.ToString()} x {x.Value} **\n" : 
                $"{currentWheels.IndexOf(x) + 1}: {x.Symbol.ToString()} x {x.Value}\n"));

            Console.WriteLine(stringToWrite);

            //Ask the player to spin = DONE
            //Player spins = DONE
            //Show Player what comes up = DONE
            //ask player to hold or not hold

            //Loop untill either all held, or player spins 3 times.

        }
    }
}
