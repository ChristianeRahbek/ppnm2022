using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main() {
		int N = 10000;
		vector a = new vector(0, 0), b = new vector(1, 1), c = new vector(1, PI);
		vector a0 = new vector(0,0,0), b0 = new vector(PI,PI,PI);

		Func<vector, double> f1 = v => {return v[0] * v[1];};
		Func<vector, double> f2 = v => {return v[0] * Sin(v[1]);};
		Func<vector, double> f3 = v => {return 1/(Pow(PI,3)*(1-Cos(v[0])*Cos(v[1])*Cos(v[2])));};

		WriteLine($"Some interesting two-dimensional integrals:");
		WriteLine($"");
		WriteLine($"Integrating x * y dxdy from x = {a[0]} to {b[0]} and y = {a[1]} to {b[1]}) with {N} points...");
		var res1 = multIntegration.plainmc(f1, a, b, N);
		WriteLine("Plain monte carlo:");
		WriteLine($"Result is = {res1.Item1} +- {res1.Item2}, expected to be 0.25");
		WriteLine("");
		WriteLine($"Halton monte carlo:");
		var res11 = multIntegration.haltonmc(f1, a, b, N);
		WriteLine($"Result is = {res11.Item1} +- {res11.Item2}, expected to be 0.25");
		
		WriteLine("_______________________________________________");
		WriteLine("");

		WriteLine($"Integrating x * Sin(y) dxdy from x = {a[0]} to {c[0]} and y = {a[1]} to {c[1]}) with {N} points...");
		var res2 = multIntegration.plainmc(f2, a, c, N);
		WriteLine("Plain monte carlo");
		WriteLine($"Result is = {res2.Item1} +- {res2.Item2}, expected to be 1");
		WriteLine("");
		WriteLine($"Halton monte carlo");
		var res21 = multIntegration.haltonmc(f2, a, c, N);
		WriteLine($"Result is = {res21.Item1} +- {res21.Item2}, expected to be 0.1");
		
		WriteLine("_______________________________________________");
		WriteLine("");
		WriteLine("Now trying to calculate:");
		WriteLine($"Integrating 1/(PI^3 * (1-cos(x)cos(y)cos(z))) dxdydz from x = 0 to pi, y = 0 to pi, z = 0 to pi with {10 * N} points...");
		WriteLine("Plain monte carlo");
		var res3 = multIntegration.plainmc(f3, a0, b0, 10*N);
		WriteLine($"Result is = {res3.Item1} +- {res3.Item2}, expected to be 1.39320393");
		WriteLine("");
		WriteLine($"Halton monte carlo:");
		var res31 = multIntegration.haltonmc(f3, a0, b0, 10*N);
		WriteLine($"Result is = {res31.Item1} +- {res31.Item2}, expected to be 1.39320393");
	}
}
