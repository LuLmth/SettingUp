namespace SettingUp;

class Program
{
    private const int SuccessCode = 0;
    private const int ErrorCode = 84;

    static int Main(string[] arguments)
    {
        if (arguments.Length != 1)
        {
            Console.WriteLine("You must provide a path of a valid file.");
            return ErrorCode;
        }

        try
        {
            SettingUp settingUp = new SettingUp();

            settingUp.ParseMap(arguments[0]);
            settingUp.FindBiggestSquare();
            settingUp.DisplayMap();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during program execution: {e.Message}");
            return ErrorCode;
        }
        return SuccessCode;
    }
}
