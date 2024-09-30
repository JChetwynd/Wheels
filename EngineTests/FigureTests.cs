using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.models;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace EngineTests
{
    public class FigureTests
    {
        [Fact]
        public void WarriorTests()
        {
            Player opponent = TestHelpers.GetPlayer();

            Dictionary<Level, LevelStats> warriorDictionary = new Dictionary<Level, LevelStats>
            {
                { Level.Level1, new LevelStats(3, 5, [new Attack(2, 3, 1)]) },
                { Level.Level2, new LevelStats(3, 5, [new Attack(5, 3, 1)]) },
                { Level.Level3, new LevelStats(3, 5, [new Attack(7, 3, 1)]) }
            };

            Warrior warrior = new Warrior(warriorDictionary);


            //WHEN XP is increased...
            Assert.Equal(0, warrior.CurrentXp);
            warrior.IncreaseXp(2);

            //THEN XP increases
            Assert.Equal(2, warrior.CurrentXp);

            //WHEN Action Points are increased...
            Assert.Equal(0, warrior.CurrentActionPoints);
            warrior.IncreaseActionPoints(2, opponent);

            //THEN Action Points increase
            Assert.Equal(2, warrior.CurrentActionPoints);

            //WHEN Action Points hit the threshold...
            Assert.Equal(5, opponent.Wall.Height);
            warrior.IncreaseActionPoints(4, opponent);

            //THEN Wall height impacted
            Assert.Equal(3, opponent.Wall.Height);

            //AND Action Points Reset
            Assert.Equal(0, warrior.CurrentActionPoints);

            //AND XP increased
            Assert.Equal(4, warrior.CurrentXp);

            //WHEN XP hits Threshold

            //THEN Level increases to 2

            //WHEN Action Points hit the threshold with increased level...

            //THEN damage is higher and the wall height is 0

            //WHEN XP hits Threshold a second time

            //THEN Level increases to 3

            //AND damage is even higher

            //AND the crown is damaged
        }
    }
}
