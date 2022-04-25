using System;
using static System.Console;
using static System.Math;

class main {
	public static void Main() {
		WriteLine($"Testing my implementation on some examples:");
		WriteLine();

		WriteLine("Testing function f(x) = x^2:");
		WriteLine("Finding extemum of f(x) by searching for the roots of the gradient f'(x) = 2x");
		var x01 = new vector(0.5);
		Func<vector,vector> f1 = delegate(vector x) {
			vector fx = new vector(1);
			fx[0] = 2*x[0];
			return fx;
		};
		var res1 = roots.newton(f1, x01);
		res1.print("The extremum is found at x = ");
		WriteLine($"The analytical extremum is found at x = 0");
		WriteLine($"");

		WriteLine("Testing Rosenbrock's valley function f(x,y) = (1-x)^2 + 100(y-x^2)^2:");
		WriteLine("Finding extemum of f(x) by searching for the roots of the gradient f'(x,y) = (-2(1-x) - 400x(y - x^2), 200(y - x^2))");
		var x02 = new vector(0.5, 0.5);
		Func<vector,vector> f2 = delegate(vector x) {
			vector fx = new vector(2);
			fx[0] = -2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0]);
			fx[1] = 200*(x[1] - x[0]*x[0]);
			return fx;
		};
		var res2 = roots.newton(f2, x02);
		WriteLine($"The extremum is found at x = ({res2[0]}, {res2[1]})");
		WriteLine("The analytical extremum is at x = (1, 1)");
	}
}
