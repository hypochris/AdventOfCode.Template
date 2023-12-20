using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string[] _input;

    public Day03()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{Solution1()}");

    public override ValueTask<string> Solve_2() => new($"{Solution2()}");

    public string Solution1()
    {
        var result = 0;
        for (int i = 0; i < _input.Length; i++)
        {

        }

        return result.ToString();
    }

    public string Solution2()
    {
        var result = 0;
        for (int i = 0; i < _input.Length; i++)
        {

        }

        return result.ToString();
    }
}
