using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main() {
		int i = 0, j = 0, k = 0, l = 0;
		double a = 0.0, b = 1.0;
		
		Func<double, double> f1 = x => {
			i++;
			return 1/Sqrt(x);
		};
		
		Func<double, double> f2 = x => {
			j++;
			return 1/Sqrt(x);
		};

		Func<double, double> f3 = x => {
			k++;
			return Log(x)/Sqrt(x);
		};

		
		Func<double, double> f4 = x => {
			l++;
			return Log(x)/Sqrt(x);
		};

		double res1 = integrator.integrate(f1, a, b);
		double res2 = integrator.ccIntegrate(f2, a, b);
		double res3 = integrator.integrate(f3, a, b);
		double res4 = integrator.ccIntegrate(f4, a, b);

		WriteLine("Comparing the number of integrand evaluations...");
		WriteLine();
		WriteLine($"integral from {a} to {b} of 1/Sqrt(x), classical method = {res1}, number of evals was {i}.");
		WriteLine($"integral from {a} to {b} of 1/Sqrt(x), Clenshaw-Curtis method = {res2}, number of evals was {j}.");		
		WriteLine($"");
		WriteLine($"integral from {a} to {b} of Log(x)/Sqrt(x), classical method = {res3}, number of evals was {k}.");
		WriteLine($"integral from {a} to {b} of Log(x)/Sqrt(x), Clenshaw-Curtis method = {res4}, number of evals was {l}.");		
	}
}
