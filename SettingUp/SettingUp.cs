namespace SettingUp;

public class SettingUp
{
    private readonly string _filepath;

    private string[] _buffer;
    private int[][] _map;

    /*
     * _biggestSquareSize is the size of the biggest square found in the map.
     * _biggestSquareRowIndex is the row index of the top left corner of the biggest square found in the map.
     * _biggestSquareColumnIndex is the column index of the top left corner of the biggest square found in the map.
     */
    private int _biggestSquareSize;
    private int _biggestSquareRowIndex;
    private int _biggestSquareColumnIndex;

    public SettingUp(string filepath)
    {
        _filepath = filepath;
        _buffer = Array.Empty<string>();
        _map = Array.Empty<int[]>();
    }

    public void Run()
    {
        Parser parser = new Parser(_filepath);

        _buffer = parser.ReadFile();
        _map = parser.MapFromBuffer(_buffer);

        FindBiggestSquare();
        DisplayMap();
    }

    private void FindBiggestSquare()
    {
        for (int rowIndex = 1; rowIndex < _map.Length; rowIndex++)
        {
            for (int columnIndex = 1; columnIndex < _map[rowIndex].Length; columnIndex++)
            {
                if (_map[rowIndex][columnIndex] != 0)
                {
                    int minimum = Math.Min(Math.Min(_map[rowIndex - 1][columnIndex], _map[rowIndex][columnIndex - 1]), _map[rowIndex - 1][columnIndex - 1]);
                    _map[rowIndex][columnIndex] = ProcessNewMapValue(minimum, rowIndex, columnIndex);
                }
            }
        }
    }
    
    private int ProcessNewMapValue(int minimum, int rowIndex, int columnIndex)
    {
        if (minimum >= _biggestSquareSize)
        {
            _biggestSquareSize = minimum + 1;
            _biggestSquareRowIndex = rowIndex;
            _biggestSquareColumnIndex = columnIndex;
        }
        return minimum + 1;
    }

    private void DisplayMap()
    {
        for (int rowIndex = 0; rowIndex < _buffer.Length; rowIndex++)
        {
            if (rowIndex >= (_biggestSquareRowIndex - _biggestSquareSize) && rowIndex < _biggestSquareRowIndex)
            {
                _buffer[rowIndex] = _buffer[rowIndex].Remove(_biggestSquareColumnIndex - _biggestSquareSize + 1, _biggestSquareSize).Insert(_biggestSquareColumnIndex - _biggestSquareSize + 1, new string('x', _biggestSquareSize));
            }
            Console.WriteLine(_buffer[rowIndex]);
        }
    }
}