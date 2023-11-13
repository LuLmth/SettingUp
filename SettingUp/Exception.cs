namespace SettingUp;

public class MapNotInitializedException : Exception
{
    public MapNotInitializedException() : base("Map is not initialized.") {}
}

public class InvalidFileException : Exception
{
    public InvalidFileException(string filepath) : base($"Invalid file: {filepath}.") {}
}

public class InvalidCharacterException : Exception
{
    public InvalidCharacterException(char c) : base($"Invalid character in map: {c}.") {}
}