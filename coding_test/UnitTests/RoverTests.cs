using Microsoft.VisualStudio.TestTools.UnitTesting;
using coding_test;
using System;

namespace UnitTests
{
    [TestClass]
    public class RoverTests
    {
        // Test SetFace method
        [TestMethod]
        public void CheckSetFace()
        {
            Rover rover = new Rover();
            char direction = 'N';
            int expected = 0;
            rover.SetFace(direction);
            Assert.AreEqual(expected, rover.facing);
            direction = 'E';
            expected = 1;
            rover.SetFace(direction);
            Assert.AreEqual(expected, rover.facing);
            direction = 'S';
            expected = 2;
            rover.SetFace(direction);
            Assert.AreEqual(expected, rover.facing);
            direction = 'W';
            expected = 3;
            rover.SetFace(direction);
            Assert.AreEqual(expected, rover.facing);
        }

        // Test SetPosition method
        [TestMethod]
        public void CheckSetPosition()
        {
            Rover rover = new Rover();
            int x = 3;
            int y = 4;
            rover.SetPosition(x, y);
            Assert.AreEqual(x, rover.x);
            Assert.AreEqual(y, rover.y);
            x = 0;
            y = 0;
            rover.SetPosition(x, y);
            Assert.AreEqual(x, rover.x);
            Assert.AreEqual(y, rover.y);
            x = -7;
            y = -3;
            rover.SetPosition(x, y);
            Assert.AreEqual(x, rover.x);
            Assert.AreEqual(y, rover.y);
        }

        // Test Rotate method
        [TestMethod]
        public void CheckRotate()
        {
            Rover rover = new Rover();
            rover.SetFace('N');
            string command = "RLRLRLLLRLL";
            for(int i = 0; i < command.Length; i++)
            {
                rover.Rotate(command[i]);
            }
            Assert.AreEqual(1, rover.facing);
            rover.SetFace('E');
            command = "RRRLRLLRLRLLRR";
            for (int i = 0; i < command.Length; i++)
            {
                rover.Rotate(command[i]);
            }
            Assert.AreEqual(3, rover.facing);
            rover.SetFace('S');
            command = "LLRRRRLRLRLRLLLLRLRLRLRLRRRRRL";
            for (int i = 0; i < command.Length; i++)
            {
                rover.Rotate(command[i]);
            }
            Assert.AreEqual(0, rover.facing);
        }
        // Test Walk method
        [TestMethod]
        public void CheckWalk()
        {
            Rover rover = new Rover();
            rover.SetFace('N');
            rover.SetPosition(6, 39);
            rover.Walk();
            Assert.AreEqual(6, rover.x);
            Assert.AreEqual(40, rover.y);
            rover.SetFace('E');
            rover.SetPosition(6, 39);
            rover.Walk();
            Assert.AreEqual(7, rover.x);
            Assert.AreEqual(39, rover.y);
            rover.SetFace('S');
            rover.SetPosition(6, 39);
            rover.Walk();
            Assert.AreEqual(6, rover.x);
            Assert.AreEqual(38, rover.y);
            rover.SetFace('W');
            rover.SetPosition(6, 39);
            rover.Walk();
            Assert.AreEqual(5, rover.x);
            Assert.AreEqual(39, rover.y);

        }
        // Test CheckValid method
        [TestMethod]
        public void TestCheckValid()
        {
            Rover rover = new Rover();
            rover.SetPosition(39, 20);
            Boolean result=rover.CheckValid(50, 50);
           
            Assert.AreEqual(false, result);
            result = rover.CheckValid(5, 5);
            Assert.AreEqual(true, result);
            result = rover.CheckValid(39, 20);
            Assert.AreEqual(false, result);
            result = rover.CheckValid(39, 40);
            Assert.AreEqual(false, result);
            result = rover.CheckValid(25, 20);
            Assert.AreEqual(true, result);
           


        }
    }
}
