using System.Reflection;

namespace Engine
{
    public class PlayerStats
    {
        public Crown Crown { get; set; }
        public Wall Wall { get; set; }
        public Figure LeftFigure { get; set; }
        public Figure RightFigure { get; set; }
    }

    public class Figure
    {
        public Level CurrentLevel { get; set; }
        public int CurrentXp { get; set; }
        public int XpRequired { get; set; }
        public Dictionary<Level, LevelStats> FigureStats { get; set; }
    }

    public class LevelStats
    {
        public int PointsToAct { get; set; }
        public int DamageToCrown { get; set; }
        public int DamageToWall { get; set; }
    }

    public enum Level
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3
    }

    public class Crown
    {
        public int Health { get; set; }
    }

    public class Wall
    {
        public int Height { get; set; }
    }
}
