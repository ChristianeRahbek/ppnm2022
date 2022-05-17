using System;
using static System.Console;
using static System.Math;

public class main {
	static Func<double, double> f = x => x * Exp(-x*x);
	static Func<double, double> g = x => Cos(5 * x - 1) * Exp(-x*x);
	
	public static void Main() {
		int n = 5; //number of hidden neurons.
		var ann = new ann(n, f);
		int nx = 20; //Number of control points

		var xs = new vector(nx); 
		var ys = new vector(nx);
		double a = -1, b = 1; //interval of interest		


		for(int i = 0; i < nx; i++) {
			xs[i] = a + (b - a) * i / (nx - 1); //making even steps between a and b
			ys[i] = g(xs[i]);
			WriteLine($"{xs[i]} {ys[i]}");
		}

		WriteLine($"");
		WriteLine($"");

		for(int i = 0; i < ann.n; i++) {
			ann.p[3 * i] = a + (b - a) * i / (ann.n - 1); //filling up as above
			ann.p[3 * i + 1] = 1; //initial guess is 1
			ann.p[3 * i + 2] = 1; //initial guess is 1 
		}

		ann.train(xs, ys);
		
		for(double z = a; z <= b; z += 1.0/64) {
			WriteLine($"{z} {ann.response(z)}");
		}
	}
}
