using System;
using static System.Double;
using static System.Math;

public class multIntegration{
	public static (double,double) plainmc(
		Func<vector, double> f, 
		vector a,
		vector b,
		int N
	) {
		var rand = new Random();
		int dim=a.size; double V=1; 
		for(int i = 0; i < dim; i++) { 
			V *= b[i]-a[i];
		}
		double sum=0,sum2=0, fx;
		var x = new vector(dim);
		for(int i = 0; i < N; i++){
			for(int k = 0; k < dim; k++) { 
				x[k] = a[k] + rand.NextDouble() * (b[k]-a[k]);
			}
			fx = f(x); 
			sum += fx; 
			sum2 += fx*fx;
		}
		double mean = sum/N, sigma = Sqrt(sum2 / N - mean * mean);
		var result = (mean * V, sigma * V / Sqrt(N));
		return result;
	}

	public static (double,double) haltonmc(
		Func<vector, double> f, 
		vector a,
		vector b,
		int N
	) {
		int dim=a.size; double V=1; 
		for(int i = 0; i < dim; i++) { 
			V *= b[i]-a[i];
		}
		double sum=0,sum2=0, fx;
		var x = new vector(dim);

		for(int i = 0; i < N; i++){
			var rand = halton(i, dim);
			for(int k = 0; k < dim; k++) { 
				x[k] = a[k] + rand[k] * (b[k]-a[k]);
			}
			fx = f(x); 
			sum += fx; 
			sum2 += fx*fx;
		}
		double mean = sum/N, sigma = Sqrt(sum2 / N - mean * mean);
		var result = (mean * V, sigma * V / Sqrt(N));
		return result;
	}

	private static double corput(int n, int Base) {
		double q = 0, bk = 1.0/Base;
		while(n > 0) {
			q += (n % Base) * bk;
			n /= Base;
			bk /= Base;
		}
		return q;
	}

	private static vector halton(int n, int d) {
		vector x = new vector(d);
		int[] Base = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
		
		if(d > Base.Length) {
			throw new System.Exception("Helton method does not work, the dimension is too large.");
		}

		for(int i = 0; i < d; i++) {
			x[i] = corput(n, Base[i]);
		}

		return x;
	}

}
