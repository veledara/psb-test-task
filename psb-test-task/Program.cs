using System;
using System.Collections.Generic;

public class Program
{
    /// <summary>
    /// Основная точка входа для приложения. 
    /// </summary>
    public static void Main()
    {
        List<string> matches = new List<string> { "3:1", "2:2", "0:1", "4:2", "3:a", "3- 12" };

        var (homeTeamPoints, awayTeamPoints) = SummarizeMatchResults(matches);

        Console.WriteLine($"Очки домашней команды: {homeTeamPoints}");
        Console.WriteLine($"Очки гостевой команды: {awayTeamPoints}");
    }

    /// <summary>
    /// Подсчитывает и возвращает очки для домашней и гостевой команд на основе списка результатов матчей.
    /// </summary>
    /// <param name="matches">Список результатов матчей в формате "X:Y", где X - голы домашней команды, Y - голы гостевой команды.</param>
    /// <returns>Кортеж, содержащий суммарные очки домашней и гостевой команд.</returns>
    private static (int HomeTeamPoints, int AwayTeamPoints) SummarizeMatchResults(List<string> matches)
    {
        int homeTeamPoints = 0, awayTeamPoints = 0;

        foreach (var result in matches)
        {
            if (TryParseMatchResult(result, out int homeGoals, out int awayGoals))
            {
                if (homeGoals > awayGoals)
                {
                    homeTeamPoints += 3;
                }
                else if (homeGoals < awayGoals)
                {
                    awayTeamPoints += 3;
                }
                else
                {
                    homeTeamPoints += 1;
                    awayTeamPoints += 1;
                }
            }
        }

        return (homeTeamPoints, awayTeamPoints);
    }

    /// <summary>
    /// Пытается обработать строку результата матча, возвращая количество голов, забитых домашней и гостевой командами.
    /// </summary>
    /// <param name="result">Результат матча в формате "X:Y", где X и Y должны быть целыми числами.</param>
    /// <param name="homeGoals">Количество голов, забитых домашней командой.</param>
    /// <param name="awayGoals">Количество голов, забитых гостевой командой.</param>
    /// <returns>True, если обработка прошла успешно, иначе False.</returns>
    private static bool TryParseMatchResult(string result, out int homeGoals, out int awayGoals)
    {
        homeGoals = 0;
        awayGoals = 0;
        var parts = result.Split(':');
        if (parts.Length == 2 && int.TryParse(parts[0], out homeGoals) && int.TryParse(parts[1], out awayGoals))
        {
            return true;
        }

        return false;
    }
}
