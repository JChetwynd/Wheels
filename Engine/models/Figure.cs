using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.models
{
    public abstract class Figure
    {
        public Figure(Dictionary<Level, LevelStats> figureStats)
        {
            CurrentLevel = Level.Level1;
            CurrentXp = 0;
            CurrentActionPoints = 0;
            FigureStats = figureStats;
        }

        public Level CurrentLevel { get; private set; }
        public int CurrentXp { get; private set; }
        public int CurrentActionPoints { get; private set; }
        public Dictionary<Level, LevelStats> FigureStats { get; private set; }

        public void IncreaseXp(int val)
        {
            CurrentXp += val;
            if(CurrentXp >= FigureStats[CurrentLevel].XpToLevelUp)
            {
                IncreaseLevel();
            }
        }

        private void IncreaseLevel()
        {
            CurrentLevel++;
        }

        public void IncreaseActionPoints(int APToAdd, Player opponent)
        {
            CurrentActionPoints += APToAdd;
            if (CurrentActionPoints >= FigureStats[CurrentLevel].ActionPointsToAct)
            {
                CurrentActionPoints = 0;
                CurrentXp += 2;
                Action(opponent);
            }
        }
        public abstract void Action(Player opponent);
    }

    public class LevelStats
    {
        public LevelStats(int pointsToAct, int xpToLevelUp, List<Attack> attacks)
        {
            ActionPointsToAct = pointsToAct;
            XpToLevelUp = xpToLevelUp;
            Attacks = attacks;
        }

        public int ActionPointsToAct { get; set; }

        public int XpToLevelUp { get; set; }
        public List<Attack> Attacks { get; set; } //int is the height of the attack
    }

    public class Attack
    {
        public Attack(int damageToWall, int damageToCrown, int height)
        {
            DamageToWall = damageToWall;
            DamageToCrown = damageToCrown;
            HeightOfAttack = height;
        }

        public int DamageToCrown { get; set; }
        public int DamageToWall { get; set; }
        public int HeightOfAttack { get; set; }
    }

    public enum Level
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3
    }

    public class DamageFigure : Figure
    {
        public DamageFigure(Dictionary<Level, LevelStats> figureStats) : base(figureStats) { }

        public override void Action(Player opponent)
        {
            opponent.Damage(FigureStats[CurrentLevel].Attacks);
        }
    }

    public class Warrior : DamageFigure
    {
        public Warrior(Dictionary<Level, LevelStats> figureStats) : base(figureStats)   {   }
    }

    public class Mage : DamageFigure
    {
        public Mage(Dictionary<Level, LevelStats> figureStats) : base(figureStats) { }
    }
}
