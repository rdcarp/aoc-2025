using System.Collections;

namespace PumpkinSoup.AOC2025.App.Domain.Forklifts.Entities;

public class HelpfulRollsOfPaperDiagram
{
    private readonly int _width;
    private readonly int _height;
    private readonly BitArray _paperRollLocations;
    private readonly int[] _paperRollProximities;

    public HelpfulRollsOfPaperDiagram(int width, int height)
    {
        _width = width;
        _height = height;

        _paperRollLocations = new BitArray(width * height);
        _paperRollProximities = new int[width * height];
    }

    public void PlacePaperRoll(int x, int y)
    {
        _paperRollLocations[y * _width + x] = true;

        for (int yShift = -1; yShift <= 1; yShift++)
        {
            for (int xShift = -1; xShift <= 1; xShift++)
            {
                if (yShift == 0 && xShift == 0)
                    continue;
                if (y + yShift >= 0 && y + yShift < _height && x + xShift >= 0 && x + xShift < _width)
                    _paperRollProximities[(y + yShift) * _width + (x + xShift)]++;
            }
        }
    }

    public void RemovePaperRoll(int x, int y)
    {
        _paperRollLocations[y * _width + x] = false;

        for (int yShift = -1; yShift <= 1; yShift++)
        {
            for (int xShift = -1; xShift <= 1; xShift++)
            {
                if (yShift == 0 && xShift == 0)
                    continue;
                if (y + yShift >= 0 && y + yShift < _height && x + xShift >= 0 && x + xShift < _width)
                    _paperRollProximities[(y + yShift) * _width + (x + xShift)]--;
            }
        }
    }

    public int AccessiblePaperRollsCount(int maxProximity)
    {
        var accessiblePaperRolls = AccessiblePaperRolls(maxProximity);
        return accessiblePaperRolls.Count();
    }
    
    private IEnumerable<int> AccessiblePaperRolls(int maxProximity)
    {
        for(int index = 0; index < _paperRollLocations.Length; index++)
            if(_paperRollLocations[index] && _paperRollProximities[index] <= maxProximity)
                yield return index;
    }
    
    public int RemovedAccessibleRolls(int maxProximity)
    {
        var accessiblePaperRolls = AccessiblePaperRolls(maxProximity).ToArray();
        foreach (var accessiblePaperRoll in accessiblePaperRolls)
        {
            RemovePaperRoll(accessiblePaperRoll % _width, accessiblePaperRoll / _width);
        }

        return accessiblePaperRolls.Length;
    }
    
    public void Print()
    {
        for(int y = 0; y < _height; y++)
        {
            for(int x = 0; x < _width; x++)
            {
                if(_paperRollLocations[y * _width + x])
                    System.Console.Write("@");
                else
                    System.Console.Write(".");
            }
            System.Console.WriteLine();
        }
    }

    public void PrintProximities()
    {
        for(int y = 0; y < _height; y++)
        {
            for(int x = 0; x < _width; x++)
            {
                System.Console.Write(_paperRollProximities[y * _width + x]);
            }
            System.Console.WriteLine();
        }
    }
}
