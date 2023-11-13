# SettingUp

This project is a C# console application that finds the largest square in a 2D map. The map is represented as a 2D array, where each cell can either be empty (represented by '.') or filled (represented by 'o'). The goal of the program is to find the largest square that can be formed using only empty cells.

## Getting Started

To get started with this project, you will need to have .NET Core installed on your machine. Once you have .NET Core installed, you can clone this repository and open the solution in your preferred IDE.

## Usage

To run the program, navigate to the project directory in your terminal and run the following command:

```bash
dotnet run <path-to-map-file>
```

This will start the program. The program will prompt you to enter the path to a text file that contains the map. The map should be represented as a grid of '.' and 'o' characters.

Input map example:

```
......
....o.
......
.o.oo.
......
......
```

Output map example:

```
XXX...
XXX.o.
XXX...
.o.oo.
......
......
```

## Contributing

If you have suggestions for how to improve the project, please open an issue or a pull request.
