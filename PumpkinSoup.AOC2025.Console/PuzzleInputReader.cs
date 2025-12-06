namespace PumpkinSoup.AOC2025.Console;

public class PuzzleInputReader
{
    public string ReadPuzzleInput(int day)
    {
        var inputFile = $"Inputs\\day{day.ToString().PadLeft(2, '0')}.txt";
        if(!File.Exists(inputFile))
            throw new FileNotFoundException($"File {inputFile} does not exist.");

        return File.ReadAllText(inputFile);
    }
}
