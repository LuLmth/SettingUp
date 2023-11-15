namespace SettingUp;

public class Parser
{
    private readonly string _filepath;

    private readonly Dictionary<char, int> _validCharacters = new()
    {
        { '.', 1 },
        { 'o', 0 }
    };

    public Parser(string filepath)
    {
        _filepath = filepath;
    }

    public string[] ReadFile()
    {
        try
        {
            string[] lines = File.ReadAllLines(_filepath);

            // If the first line is a number, it is the number of lines in the map.
            if (int.TryParse(lines[0], out int numberOfLines))
            {
                // If the number of lines is not equal to the number of lines in the array, the file is invalid.
                if (numberOfLines != lines.Length - 1)
                {
                    throw new InvalidFileException(_filepath);
                }

                // Remove the first line from the array.
                lines = lines[1..];
            }
            return lines;
        } catch (Exception) // TODO: Catch specific exceptions.
        {
            throw new InvalidFileException(_filepath);
        }
    }

    public int[][] MapFromBuffer(string[] buffer)
    {
        int numberOfLines = buffer.Length;
        int[][] map = new int[numberOfLines][];

        for(int rowIndex = 0; rowIndex < numberOfLines; rowIndex++)
        {
            int[] rowOfInt = new int[buffer[rowIndex].Length];

            for (int columnIndex = 0; columnIndex < buffer[rowIndex].Length; columnIndex++)
            {
                try
                {
                    rowOfInt[columnIndex] = _validCharacters[buffer[rowIndex][columnIndex]];
                } catch (KeyNotFoundException)
                {
                    throw new InvalidCharacterException(buffer[rowIndex][columnIndex]);
                }
            }
            map[rowIndex] = rowOfInt;
        }
        return map;
    }
}