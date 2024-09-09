using System.Reflection;

namespace Engine.models
{
    public class Player
    {
        public Player(Crown crown, Wall wall, List<Figure> figures, Spinner playerSpinner)
        {
            Crown = crown;
            Wall = wall;
            Figures = figures;
            PlayerSpinner = playerSpinner;
        }

        public Crown Crown { get; set; }
        public Wall Wall { get; set; }
        public List<Figure> Figures { get; set; }
        public Spinner PlayerSpinner { get; set; }
    }

    public class Figure
    {
        public Figure(Level currentLevel, int currentXp, Dictionary<Level, LevelStats> figureStats)
        {
            CurrentLevel = currentLevel;
            CurrentXp = currentXp;
            FigureStats = figureStats;
        }

        public Level CurrentLevel { get; set; }
        public int CurrentXp { get; set; }
        public Dictionary<Level, LevelStats> FigureStats { get; set; }
    }

    public class LevelStats
    {
        public LevelStats(int pointsToAct, int damageToCrown, int damageToWall, int xpToLevelUp, List<int> attacks)
        {
            PointsToAct = pointsToAct;
            DamageToCrown = damageToCrown;
            DamageToWall = damageToWall;
            XpToLevelUp = xpToLevelUp;
            Attacks = attacks;
        }

        public int PointsToAct { get; set; }
        public int DamageToCrown { get; set; }
        public int DamageToWall { get; set; }
        public int XpToLevelUp { get; set; }
        public List<int> Attacks { get; set; } //int is the height of the attack
    }

    public enum Level
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3
    }

    public class Crown
    {
        public Crown(int health)
        {
            Health = health;
        }

        public int Health { get; set; }
    }

    public class Wall
    {
        public Wall(int height)
        {
            MaxHeight = height;
        }

        public int MaxHeight { get; set; }
    }
}
