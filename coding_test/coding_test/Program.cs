using System;
using System.IO;
using System.Collections;
namespace coding_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //string[] input = System.IO.File.ReadAllLines("/Users/brian/Downloads/coding_test/coding_test/sample_test.txt");
            // Read input from txt file
            string[] input = System.IO.File.ReadAllLines("../../../sample_test.txt");

            // Get the boundary
            string[] size = input[0].Split(' ');
            int GridLength = Int32.Parse(size[0]);
            int GridWidth = Int32.Parse(size[1]);

            // Using Hashtable to convert back the numeric direction to character
            Hashtable DirectionInverseMap = new Hashtable() { { 0, 'N' }, { 1, 'E' }, { 2, 'S' }, { 3, 'W' } };

            // Iterate through all the command. Assume that the input are always a initial information followed by a series command.
            for (int row = 1; row < input.Length; row += 2)
            {
                string[] InitialInfo = input[row].Split(' ');
                string command = input[row + 1];

                // Construct a rover object 
                Rover rover = new Rover();
                // Set initial information
                rover.SetFace(InitialInfo[2].ToCharArray()[0]);
                rover.SetPosition(Int32.Parse(InitialInfo[0]), Int32.Parse(InitialInfo[1]));

                // A flag indicates that the position is valid or not
                int OutofBound = 0;

                // Iterate through command
                for(int index = 0; index < command.Length; index++)
                {
                    char signal = command[index];
                    
                    // Check if the current position is valid
                    if(rover.CheckValid(GridLength, GridWidth))
                    {
                        Console.WriteLine("The rover is out of bound");
                        OutofBound = 1;
                        break;
                    }

                    // Assume the command is only consist of 'M','L' and 'R'.
                    if (signal.Equals('M'))
                    {
                        rover.Walk();
                        
                    }
                    // Rotate the head
                    else
                    {
                    
                        rover.Rotate(signal);
                    }
                }
                // If all the command is valid, print the info.
                if (OutofBound == 0)
                {
                    Console.WriteLine(rover.x.ToString() + ' ' + rover.y.ToString() + ' ' + DirectionInverseMap[rover.facing].ToString());
                }
                
            }
        }
    }
}
