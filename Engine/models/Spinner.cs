using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.models
{
    public class Spinner
    {
        public Spinner(List<Wheel> wheelSet)
        {
            WheelSet = wheelSet;
        }

        public List<Wheel> WheelSet { get; set; }
    }
        
    public class Wheel
    {
        public Wheel(List<WheelFace> wheelFaces)
        {
            WheelFaces = wheelFaces;
        }

        public List<WheelFace> WheelFaces { get; set; }
    }

    public class WheelFace
    {
        public WheelFace(Symbol symbol, int value, bool xpBonus)
        {
            Symbol = symbol;
            Value = value;
            XpBonus = xpBonus;
        }

        public Symbol Symbol { get; set; }
        public int Value { get; set; }
        public bool XpBonus { get; set; }
    }

    public enum Symbol
    {
        Wall,
        FigureOne,
        FigureTwo
    }
}
