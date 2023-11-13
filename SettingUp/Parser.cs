namespace SettingUp;

public class Parser
{
    private readonly string[] _mapBuffer;

    private struct EmptySpace
    {
        public const char InputValue = '.';
        public const int InnerValue = 1;
    }

    private struct Obstacle
    {
        public const char InputValue = 'o';
        public const int InnerValue = 0;
    }

    public Parser(string filepath)
    {
        _mapBuffer = ReadMapFromFile(filepath);
    }

    private string[] ReadMapFromFile(string filepath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filepath);

            // If the first line is a number, it is the number of lines in the map.
            if (int.TryParse(lines[0], out int numberOfLines))
            {
                // If the number of lines is not equal to the number of lines in the array, the file is invalid.
                if (numberOfLines != lines.Length - 1)
                {
                    throw new InvalidFileException(filepath);
                }

                // Remove the first line from the array.
                lines = lines[1..];
            }
            return lines;
        } catch (Exception)
        {
            throw new InvalidFileException(filepath);
        }
    }

    private int CharToInt(char c)
    {
        switch (c)
        {
            case EmptySpace.InputValue:
                return EmptySpace.InnerValue;
            case Obstacle.InputValue:
                return Obstacle.InnerValue;
            default:
                throw new InvalidCharacterException(c);
        }
    }

    public int[][] MapToIntArray()
    {
        int numberOfLines = _mapBuffer.Length;
        int[][] map = new int[numberOfLines][];

        for(int rowIndex = 0; rowIndex < numberOfLines; rowIndex++)
        {
            int[] rowOfInt = new int[_mapBuffer[rowIndex].Length];

            for (int columnIndex = 0; columnIndex < _mapBuffer[rowIndex].Length; columnIndex++)
            {
                rowOfInt[columnIndex] = CharToInt(_mapBuffer[rowIndex][columnIndex]);
            }
            map[rowIndex] = rowOfInt;
        }
        return map;
    }
}