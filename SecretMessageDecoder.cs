using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class SecretMessageDecoder
{
    public void DecodeFromTextFile(string path)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (!File.Exists(path))
        {
            Console.WriteLine($"File not found: {path}");
            return;
        }

        string[] lines = File.ReadAllLines(path);
        var entries = ParseEntriesFromText(lines);
        PrintCharacterGrid(entries);
    }

    private List<(char symbol, int x, int y)> ParseEntriesFromText(string[] lines)
    {
        var entries = new List<(char, int, int)>();

        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3) continue;

            bool parsedX = int.TryParse(parts[0], out int x);
            bool parsedY = int.TryParse(parts[2], out int y);
            string symbolText = parts[1];

            if (symbolText.Length == 1 && parsedX && parsedY)
            {
                char symbol = symbolText[0];
                entries.Add((symbol, x, y));
            }
        }

        return entries;
    }

    private void PrintCharacterGrid(List<(char symbol, int x, int y)> entries)
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No valid block characters found.");
            return;
        }

        int maxX = entries.Max(e => e.x);
        int maxY = entries.Max(e => e.y);

        int width = maxX + 1;
        int height = maxY + 1;

        char[,] grid = new char[height, width];

        // Use a Braille blank so terminal output does not collapse empty spaces.
        char blank = '⠀';

        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                grid[y, x] = blank;

        foreach (var (symbol, x, y) in entries)
        {
            // Flip the Y axis so the message appears upright when printed.
            int gridY = height - 1 - y;
            int gridX = x;
            grid[gridY, gridX] = symbol;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
                Console.Write(grid[y, x]);
            Console.WriteLine();
        }
    }
}
