namespace AdventOfCode.Core
{
    public class DayOneFloorCount
    {
        public int CalculateFloor(string instructions)
        {
            int floor = 0;
            foreach (var instruction in instructions)
            {
                if (instruction == '(')
                    floor++;
                if (instruction == ')')
                    floor--;
            }
            return floor;
        }
    }
}