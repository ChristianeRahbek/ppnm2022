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

}
