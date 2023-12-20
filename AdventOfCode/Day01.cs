using System.Numerics;
using System.Runtime.InteropServices;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    public enum Numbers
    {
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }

    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{Solution1()}");

    public override ValueTask<string> Solve_2() => new($"{Solution2()}");

    public string Solution1()
    {
        BigInteger solution = 0;
        foreach (var line in _input)
        {
            var chars = line.ToCharArray();
            var number1 = "";
            var number2 = "";

            for (int i = 0; i < chars.Length; i++)
            {
                if (int.TryParse(chars[i].ToString(), out var n1))
                {
                    number1 = n1.ToString();
                    break;
                }
            }
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(chars[i].ToString(), out var n2))
                {
                    number2 = n2.ToString();
                    break;
                }
            }
            solution += int.Parse($"{number1}{number2}");
        }
        return solution.ToString();
    }

    public string Solution2()
    {
        var solution = 0;
        foreach (var line in _input)
        {
            var chars = line.ToCharArray();
            var number1 = string.Empty;
            var number2 = string.Empty;

            for (int i = 0; i < chars.Length; i++)
            {
                if (int.TryParse(chars[i].ToString(), out var n1))
                {
                    number1 = n1.ToString();
                    break;
                }

                foreach (var num in Enum.GetValues<Numbers>())
                {
                    if (line[i..].StartsWith(num.ToString()))
                    {
                        number1 = ((int)num).ToString();
                        break;
                    }
                }
                if (number1 != string.Empty)
                    break;
            }
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(chars[i].ToString(), out var n2))
                {
                    number2 = n2.ToString();
                    break;
                }

                foreach (var num in Enum.GetValues<Numbers>())
                {
                    if (line[..i].EndsWith(num.ToString()))
                    {
                        number2 = ((int)num).ToString();
                        break;
                    }
                }
                if (number2 != string.Empty)
                    break;
            }
            solution += int.Parse($"{number1}{number2}");
        }
        return solution.ToString();
    }
}
