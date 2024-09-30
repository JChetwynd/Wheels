using System.Reflection;

namespace Engine.models
{
    public class Player
    {
        public Player(Crown crown, Wall wall, List<Figure> figures, WheelSet wheelSet)
        {
            Crown = crown;
            Wall = wall;
            Figures = figures;
            WheelSet = wheelSet;
        }

        public Crown Crown { get; set; }
        public Wall Wall { get; set; }
        public List<Figure> Figures { get; set; }
        public WheelSet WheelSet { get; set; }

        public void Damage(List<Attack> attacks)
        {
            foreach (Attack attack in attacks)
            {
                if (attack.HeightOfAttack > Wall.Height)
                {
                    Crown.Health -= attack.DamageToCrown;
                }
                else
                {
                    Wall.DecreaseHeight(attack.DamageToWall);
                }
            }
        }
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
            Height = height;
        }

        public int Height { get; private set; }

        public void DecreaseHeight(int val)
        {
            Height -= val;

            if (Height < 0)
            {
                Height = 0;
            }
        }
    }
}
