using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main() {
		WriteLine("Testing the integrator");
		double a = 0.0, b = 1.0;
		
		Func<double, double> f1 = x => Sqrt(x);
		Func<double, double> f2 = x => 1/Sqrt(x);
		Func<double, double> f3 = x => 4*Sqrt(1-x*x);
		Func<double, double> f4 = x => Log(x)/Sqrt(x);

		double res1 = integrator.integrate(f1, a, b);
		double res2 = integrator.integrate(f2, a, b);
		double res3 = integrator.integrate(f3, a, b);
		double res4 = integrator.integrate(f4, a, b);


		WriteLine($"integral of Sqrt(x) from {a} to {b} = {res1}, expected result = {2.0/3}");
		WriteLine($"integral of 1/Sqrt(x) from {a} to {b} = {res2}, expected result = {2}");
		WriteLine($"integral of 4/Sqrt(1-x^2) from {a} to {b} = {res3}, expected result = {PI}");
		WriteLine($"integral of Log(x)/Sqrt(x) from {a} to {b} = {res4}, expected result = {-4}");
	
		using(var outfile = new System.IO.StreamWriter("erfCalc.txt")) {
			for(double x = -2; x <= 2; x += 1.0/8) {
				outfile.WriteLine($"{x} {integrator.erf(x)}");
			}
		}
	}
}
