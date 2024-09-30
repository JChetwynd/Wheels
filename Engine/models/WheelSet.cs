using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Engine.models
{
    public class WheelSet
    {
        public WheelSet(List<Wheel> wheels, Random random)
        {
            Wheels = wheels;
            _random = random;
        }

        public List<Wheel> Wheels { get; set; }

        private Random _random;

        public List<Wheel> SpinWheels()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.SpinWheel(_random);
            }
            return Wheels;
        }
    }
    public class Wheel
    {
        public Wheel(List<WheelFace> wheelFaces)
        {
            WheelFaces = wheelFaces;
        }

        public List<WheelFace> WheelFaces { get; set; }

        public void SpinWheel(Random random)
        {
            if(!WheelFaces.Any(wf => wf.InPlay.IsHeld))
            {
                ResetWheel();
                var bar = WheelFaces[random.Next(1, WheelFaces.Count())];
                bar.FaceUp();
            }
        }

        private void ResetWheel()
        {
            foreach (WheelFace wf in WheelFaces)
            {
                wf.Reset();
            }
        }
    }

    public class WheelFace
    {
        public WheelFace(Symbol symbol, int value, bool xpBonus)
        {
            Symbol = symbol;
            Value = value;
            XpBonus = xpBonus;
            InPlay = new InPlay();
        }

        public Symbol Symbol { get; set; }
        public int Value { get; set; }
        public bool XpBonus { get; set; }
        public InPlay InPlay { get; private set; }

        public void FaceUp()
        {
            InPlay.IsFacingUp = true;
        }
        public void HoldWheel()
        {
            if (InPlay.IsFacingUp)
            {
                InPlay.IsHeld = true;
            }
        }
        public void Reset()
        {
            InPlay.IsFacingUp = false;
            InPlay.IsHeld = false;
        }
    }

    public class InPlay
    {
        public InPlay()
        {
            IsFacingUp = false;
            IsHeld = false;
        }

        public bool IsFacingUp { get; set; }
        public bool IsHeld { get; set; }
    }

    public enum Symbol
    {
        Wall,
        FigureOne,
        FigureTwo
    }

}
