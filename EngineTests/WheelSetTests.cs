using Xunit;

using ConsoleRunner;
using Engine.models;
using System.Collections.Generic;
using System.Text.Json;
using Engine;
using System;

namespace EngineTests
{
    public class WheelSetTests
    {

        [Fact]
        public void WhenISpinTheWheelIGetARandomResultFromThePreconfiguredSet()
        {
            Random r = new Random();
            Wheel wheel = TestHelpers.GetWheelSet().Wheels.FirstOrDefault();

            wheel.SpinWheel(r);

            string wfs1 = JsonSerializer.Serialize(wheel.WheelFaces);
            
            wheel.SpinWheel(r);

            string wfs2 = JsonSerializer.Serialize(wheel.WheelFaces);

            Assert.NotEqual(wfs1, wfs2);
            Assert.Contains(true, wheel.WheelFaces.Select(wf => wf.InPlay.IsFacingUp));
            Assert.DoesNotContain(true, wheel.WheelFaces.Select(wf => wf.InPlay.IsHeld));
            Assert.True(wheel.WheelFaces.Where(wf => wf.InPlay.IsFacingUp).Count() == 1);
        }

        [Fact]
        public void WhenISpinTheWheelsOnlyTheUnheldWheelsChange()
        {
            List<bool> randomBools = new List<bool>(new bool[5].Select(_ => new Random().Next(2) == 1));

            WheelSet ws = TestHelpers.GetWheelSet();

            ws.SpinWheels();

            List<WheelFace?> wfs = ws.Wheels.Select(w => w.WheelFaces.Where(wf => wf.InPlay.IsFacingUp == true).FirstOrDefault()).ToList();
            List<string> wheelAsString1 = new List<string>();
            List<string> wheelAsString2 = new List<string>();

            for (int i = 0; i < ws.Wheels.Count; i++)
            {
                if (randomBools[i])
                {
                    ws.Wheels[i].WheelFaces.FirstOrDefault(wf => wf.InPlay.IsFacingUp == true).HoldWheel();
                }
            }

            wheelAsString1.AddRange(ws.Wheels.Select(w => JsonSerializer.Serialize(w)));

            ws.SpinWheels();

            wheelAsString2.AddRange(ws.Wheels.Select(w => JsonSerializer.Serialize(w)));

            for (int i = 0; i < ws.Wheels.Count; i++)
            {
                if (randomBools[i])
                {
                    Assert.Equal(wheelAsString1[i], wheelAsString2[i]);
                }
                else
                {
                    Assert.NotEqual(wheelAsString1[i], wheelAsString2[i]);
                }
            }
        }
    }
}