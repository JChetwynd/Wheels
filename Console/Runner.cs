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
        public WheelSet WheelSetP2 { get; private set; }

        public Runner(WheelSet wheelSetP1, WheelSet wheelSetP2)
        {
            WheelSetP1 = wheelSetP1;
            WheelSetP2 = wheelSetP2;
        }

        public void run()
        {
            Console.WriteLine("Welcome to wheels");

            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    SpinWheels(WheelSetP1, "Player 1");
                }
                Console.WriteLine("Player 1's Wheel Is Set");
                Console.WriteLine("--------------------------");

                for (int i = 0; i < 2; i++)
                {
                    SpinWheels(WheelSetP2, "Player 2");
                }
                Console.WriteLine("Player 2's Wheel Is Set");
            }
        }

        public void SpinWheels(WheelSet wheelSet, string playerName)
        {
            List<WheelFace?> currentWheels = wheelSet.SpinWheels().Select(w => w.WheelFaces.Where(wf => wf.InPlay.IsFacingUp == true).FirstOrDefault()).ToList();
            Console.WriteLine(FormatWheelString(currentWheels));

            Console.WriteLine($"{playerName}'s spinner, select a wheel to 'Hold', or press enter to spin the wheels");
            string? response = Console.ReadLine();
            if (response != "")
            {
                int wheelToHold = int.Parse(response);
                currentWheels[wheelToHold - 1].HoldWheel();

                Console.WriteLine($"{playerName}'s spinner. You have held wheel number {wheelToHold}");

            }

        }

        private string FormatWheelString(List<WheelFace?> currentWheels)
        {
            List<string> stringifiedWheels = new List<string>();

            foreach (var wheel in currentWheels)
            {
                string stringifiedWheel = $"{currentWheels.IndexOf(wheel) + 1}: {wheel.Symbol.ToString()} x {wheel.Value}";
                if (wheel.XpBonus)
                {
                    stringifiedWheel += " + BONUS";
                }
                if (wheel.InPlay.IsHeld)
                {
                    stringifiedWheel += " + HELD";
                }
                stringifiedWheel += " \n";

                stringifiedWheels.Add(stringifiedWheel);
            }

            return string.Join("", stringifiedWheels);
        }
    }
}
