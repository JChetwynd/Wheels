using Xunit;

using ConsoleRunner;
using Engine.models;
using System.Collections.Generic;
using System.Text.Json;

namespace EngineTests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenICallBuildBoardIGetTheCorrectBoard()
        {
            Runner runner = new Runner();
            GameBoard board = runner.BuildBoard();

            Assert.NotNull(board);

            Assert.True(board.Player1 != null);
            Assert.True(board.Player2 != null);

            Assert.True (board.Player1.Crown != null);
            Assert.True (board.Player1.Wall != null);
            Assert.True (board.Player1.Figures.Count() == 2);
            Assert.True (board.Player1.PlayerSpinner != null);

            Assert.True (board.Player2.Crown != null);
            Assert.True (board.Player2.Wall != null);
            Assert.True (board.Player2.Figures.Count() == 2);
            Assert.True (board.Player2.PlayerSpinner != null);

        }

        [Fact]
        public void JsonGenerator()
        {
            Dictionary<Level, LevelStats> warriorDictionary = new Dictionary<Level, LevelStats>
            {
                { Level.Level1, new LevelStats(3, 3, 3, 5, [0]) },
                { Level.Level2, new LevelStats(3, 5, 3, 5, [0]) },
                { Level.Level3, new LevelStats(3, 7, 3, 5, [0]) },
            };

            Figure warrior = new Figure(Level.Level1, 0, warriorDictionary);

            Dictionary<Level, LevelStats> mageDictionary = new Dictionary<Level, LevelStats>
            {
                { Level.Level1, new LevelStats(5, 2, 2, 5, [0]) },
                { Level.Level2, new LevelStats(4, 3, 3, 5, [0]) },
                { Level.Level3, new LevelStats(4, 3, 5, 5, [0, 6]) }
            };
            Figure mage = new Figure(Level.Level1, 0, mageDictionary);

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
            Spinner spinner = new Spinner(wheelList);

            Player player1 = new Player(new Crown(5), new Wall(5), [warrior, mage], spinner);

             
            string json = JsonSerializer.Serialize(player1);
        }

        [Fact]
        public void UseJsonForBoard()
        {
           string tes = Directory.GetCurrentDirectory();

            //Player player1 = 
        }
    }
}