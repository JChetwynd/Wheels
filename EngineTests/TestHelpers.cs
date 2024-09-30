using Engine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EngineTests
{
    public static class TestHelpers
    {
        public static GameBoard GetBoard(string jsonFilePath)
        {
            string boardConfigLocation = jsonFilePath;

            string playerConfig = File.ReadAllText(boardConfigLocation);
            Player player1 = JsonSerializer.Deserialize<Player>(playerConfig);
            Player player2 = JsonSerializer.Deserialize<Player>(playerConfig);
            return new GameBoard(player1, player2);
        }

        public static GameBoard GetBoard()
        {
            return new GameBoard(GetPlayer(), GetPlayer());
        }

        public static Player GetPlayer()
        {
            Dictionary<Level, LevelStats> warriorDictionary = new Dictionary<Level, LevelStats>
            {
                { Level.Level1, new LevelStats(3, 5, [new Attack(3, 3, 0)]) },
                { Level.Level2, new LevelStats(3, 5, [new Attack(5, 3, 0)]) },
                { Level.Level3, new LevelStats(3, 5, [new Attack(7, 3, 0)]) }
            };

            Warrior warrior = new Warrior(warriorDictionary);

            Dictionary<Level, LevelStats> mageDictionary = new Dictionary<Level, LevelStats>
            {
                { Level.Level1, new LevelStats(5, 5, [new Attack(2, 2, 0)]) },
                { Level.Level2, new LevelStats(4, 5, [new Attack(3, 3, 0)]) },
                { Level.Level3, new LevelStats(4, 5, [new Attack(3, 5, 0), new Attack(3, 5, 6)]) }
            };
            Mage mage = new Mage(mageDictionary);

            return new Player(new Crown(5), new Wall(5), [warrior, mage], GetWheelSet());
        }

        public static WheelSet GetWheelSet()
        {
            List<Wheel> wheelList = new List<Wheel>
            {
                new Wheel(new List<WheelFace>
                {
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, true),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.Wall, 1, false),
                    new WheelFace(Symbol.FigureTwo, 2, true),
                    new WheelFace(Symbol.Wall, 1, false)
                }),
                new Wheel(new List<WheelFace>
                {
                    new WheelFace(Symbol.FigureOne, 1, true),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.FigureOne, 2, false),
                    new WheelFace(Symbol.FigureTwo, 1, true),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.Wall, 1, false),
                    new WheelFace(Symbol.FigureTwo, 2, false),
                    new WheelFace(Symbol.Wall, 2, false)
                }),
                new Wheel(new List<WheelFace>
                {
                    new WheelFace(Symbol.FigureOne, 1, true),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, true),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.Wall, 2, false),
                    new WheelFace(Symbol.FigureOne, 2, false),
                    new WheelFace(Symbol.Wall, 2, false)
                }),
                new Wheel(new List<WheelFace>
                {
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.FigureOne, 1, true),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.Wall, 2, false),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, true),
                    new WheelFace(Symbol.Wall, 2, false)
                }),
                new Wheel(new List<WheelFace>
                {
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.Wall, 1, false),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false),
                    new WheelFace(Symbol.Wall, 1, false),
                    new WheelFace(Symbol.FigureOne, 1, false),
                    new WheelFace(Symbol.FigureTwo, 1, false)
                })
            };

            return new WheelSet(wheelList, new Random());
        }
    }
}
