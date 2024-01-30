using System;
using Xunit;

public class QuadraticEquationSolver
{
    public static (double?, double?) Solve(double a, double b, double c)
    {
        double? x1 = null;
        double? x2 = null;
        double delta = b * b - 4 * a * c;

        if (delta > 0)
        {
            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
        }
        else if (delta == 0)
        {
            x1 = -b / (2 * a);
        }

        return (x1, x2);
    }
}

public class QuadraticEquationSolverTests
{
    [Fact]
    public void TestNoRealRoots()
    {
        var roots = QuadraticEquationSolver.Solve(1, 0, 1);
        Assert.Null(roots.Item1);
        Assert.Null(roots.Item2);
    }

    [Fact]
    public void TestOneRealRoot()
    {
        var roots = QuadraticEquationSolver.Solve(1, 0, 0);
        Assert.Equal(0, roots.Item1);
        Assert.Null(roots.Item2);
    }

    [Fact]
    public void TestTwoRealRoots()
    {
        var roots = QuadraticEquationSolver.Solve(1, -3, 2);
        Assert.Equal(1, roots.Item1);
        Assert.Equal(2, roots.Item2);
    }
}