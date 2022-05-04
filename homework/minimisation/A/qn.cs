using System;
using static System.Console;
using static System.Math;

public class qn{
	public static vector qnewton(
		Func<vector,double> f,  /* objective function */ 
		vector xstart, /* starting point */
		double acc = 1e-3 /* accuracy goal, on exit abs(gradient) < acc */
	) {
		
	}

	public static vector gradient(Func<vector, double> f, vector x) {
		int n = x.size;
		vector grad = new vector(n);
		double fx = f(x);

		double eps = Pow(2, -26); //making a small number to make small step size
		
		for(int i = 0; i < n; i++) {
			dx = Abs(x[i]) * eps;
			if(Abs(x[i]) < Sqrt(eps)) dx = eps;
			
			x[i] += dx;
			g[i] = (f(x) - fx)/dx; //(fx2 - fx1)/(x2-x1) when finding gradient traditionally
			x[i] -= dx;
		}

		return g;
	}
}
