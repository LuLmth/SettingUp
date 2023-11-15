namespace SettingUp;

public class SettingUp
{
    private int[][]? _map;

    /*
     * _biggestSquareSize is the size of the biggest square found in the map.
     * _biggestSquareRowIndex is the row index of the top left corner of the biggest square found in the map.
     * _biggestSquareColumnIndex is the column index of the top left corner of the biggest square found in the map.
     */
    private int _biggestSquareSize;
    private int _biggestSquareRowIndex;
    private int _biggestSquareColumnIndex;

    public void ParseMap(string filepath)
    {
        Parser parser = new Parser(filepath);

        _map = parser.MapToIntArray();
    }

    private int ProcessNewMapValue(int[] arroundValues, int rowIndex, int columnIndex)
    {
        int minimum = arroundValues.Min();

        if (minimum >= _biggestSquareSize)
        {
            _biggestSquareSize = minimum + 1;
            _biggestSquareRowIndex = rowIndex;
            _biggestSquareColumnIndex = columnIndex;
        }
        return minimum + 1;
    }

    public void FindBiggestSquare()
    {
        if (_map == null)
        {
            throw new MapNotInitializedException();
        }

        for (int rowIndex = 1; rowIndex < _map.Length; rowIndex++)
        {
            for (int columnIndex = 1; columnIndex < _map[rowIndex].Length; columnIndex++)
            {
                if (_map[rowIndex][columnIndex] != 0)
                {
                    int[] arround = { _map[rowIndex - 1][columnIndex], _map[rowIndex][columnIndex - 1], _map[rowIndex - 1][columnIndex - 1] };

                    _map[rowIndex][columnIndex] = ProcessNewMapValue(arround, rowIndex, columnIndex);
                }
            }
        }
    }
    
    private bool IsInBiggestSquare(int rowIndex, int columnIndex)
    {
        return (rowIndex >= (_biggestSquareRowIndex - _biggestSquareSize + 1) &&
               rowIndex <= _biggestSquareRowIndex) &&
               (columnIndex >= (_biggestSquareColumnIndex - _biggestSquareSize + 1) &&
               columnIndex <= _biggestSquareColumnIndex);
    }
    
    public void DisplayMap()
    {
        if (_map == null)
        {
            throw new MapNotInitializedException();
        }

        for (int rowIndex = 0; rowIndex < _map.Length; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < _map[rowIndex].Length; columnIndex++)
            {
                if (IsInBiggestSquare(rowIndex, columnIndex))
                {
                    Console.Write("X");
                }
                else if (_map[rowIndex][columnIndex] == 0)
                {
                    Console.Write('o');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}