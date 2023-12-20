using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{Solution1()}");

    public override ValueTask<string> Solve_2() => new($"{Solution2()}");

    public Dictionary<string, int> MaxScores = new()
    {
        ["blue"] = 14,
        ["red"] = 12,
        ["green"] = 13
    };

    public Dictionary<string, int> MinScores = new()
    {
        ["blue"] = 0,
        ["red"] = 0,
        ["green"] = 0
    };

    public string Solution1()
    {
        var result = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            var draws = _input[i].Split(':')[1].Trim().Split(';');
            var isPossible = true;
            foreach (var draw in draws)
            {
                var hands = draw.Split(", ");
                foreach (var hand in hands)
                {
                    var values = hand.Trim().Split(' ');
                    if (MaxScores[values[1]] < int.Parse(values[0]))
                    {
                        isPossible = false;
                        break;
                    }
                }
                if (!isPossible)
                {
                    break;
                }
            }
            if (isPossible)
            {
                result += i + 1;
            }
        }

        return result.ToString();
    }

    public string Solution2()
    {
        var result = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            MinScores.Keys.ToList().ForEach(x => MinScores[x] = 0);
            var draws = _input[i].Split(':')[1].Trim().Split(';');
            foreach (var draw in draws)
            {
                var hands = draw.Split(", ");
                foreach (var hand in hands)
                {
                    var values = hand.Trim().Split(' ');
                    if (MinScores[values[1]] < int.Parse(values[0]))
                    {
                        MinScores[values[1]] = int.Parse(values[0]);
                    }
                }
            }
            var product = 1;
            MinScores.Keys.ToList().ForEach(x => product = MinScores[x] * product);
            result += product;
        }

        return result.ToString();
    }
}
