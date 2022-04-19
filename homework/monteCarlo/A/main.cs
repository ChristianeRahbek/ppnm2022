using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main() {
		int N = 1000;
		vector a = new vector(0, 0), b = new vector(1, 1), c = new vector(1, PI);
		vector a0 = new vector(0,0,0), b0 = new vector(PI,PI,PI);

		Func<vector, double> f1 = v => {return v[0] * v[1];};
		Func<vector, double> f2 = v => {return v[0] * Sin(v[1]);};
		Func<vector, double> f3 = v => {return 1/(Pow(PI,3)*(1-Cos(v[0])*Cos(v[1])*Cos(v[2])));};

		WriteLine($"Some interesting two-dimensional integrals:");
		WriteLine($"");
		WriteLine($"Integrating x * y dxdy from x = {a[0]} to {b[0]} and y = {a[1]} to {b[1]}) with {N} points...");
		var res1 = multIntegration.plainmc(f1, a, b, N);
		WriteLine($"Result is = {res1.Item1} +- {res1.Item2}, expected to be 0.25");
		WriteLine("");
		WriteLine($"Integrating x * y dxdy from x = {a[0]} to {b[0]} and y = {a[1]} to {b[1]}) with {10*N} points...");
		var res11 = multIntegration.plainmc(f1, a, b, 10*N);
		WriteLine($"Result is = {res11.Item1} +- {res11.Item2}, expected to be 0.25");
		
		WriteLine("");

		WriteLine($"Integrating x * Sin(y) dxdy from x = {a[0]} to {c[0]} and y = {a[1]} to {c[1]}) with {N} points...");
		var res2 = multIntegration.plainmc(f2, a, c, N);
		WriteLine($"Result is = {res2.Item1} +- {res2.Item2}, expected to be 1");
		WriteLine("");
		WriteLine($"Integrating Sin(x) * y dxdy from x = {a[0]} to {c[0]} and y = {a[1]} to {c[1]}) with {10*N} points...");
		var res21 = multIntegration.plainmc(f2, a, c, 10*N);
		WriteLine($"Result is = {res21.Item1} +- {res21.Item2}, expected to be 0.1");
		
		WriteLine("");
		WriteLine("Now trying to calculate:");
		WriteLine($"Integrating 1/(PI^3 * (1-cos(x)cos(y)cos(z))) dxdydz from x = 0 to pi, y = 0 to pi, z = 0 to pi with {10 * N} points...");
		var res3 = multIntegration.plainmc(f3, a0, b0, 10 * N);
		WriteLine($"Result is = {res3.Item1} +- {res3.Item2}, expected to be 1.39320393");
		WriteLine("");
		WriteLine($"Integrating 1/(PI^3 * (1-cos(x)cos(y)cos(z))) dxdydz from x = 0 to pi, y = 0 to pi, z = 0 to pi with {100*N} points...");
		var res31 = multIntegration.plainmc(f3, a0, b0, N*100);
		WriteLine($"Result is = {res31.Item1} +- {res31.Item2}, expected to be 1.39320393");
	}
}
