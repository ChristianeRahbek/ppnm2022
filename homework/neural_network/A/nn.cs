using System;
using static System.Math;
using static System.Console;

public class ann{
	public int n; /* number of hidden neurons */
	public Func<double,double> f; /* activation function */
	public vector p; /* network parameters */

	public ann(int n,Func<double,double> f) {/* constructor */
		this.n = n;
		this.f = f;
		this.p = new vector(3*n);
	}
	
	public double response(double x) {
		/* return the response of the network to the input signal x */
		double outputSum = 0;
		for(int i = 0; i < n; i++) {
			double a = p[3*i + 0]; 
			double b = p[3*i + 1];
			double w = p[3*i + 2];
			outputSum += w * f((x - a) / b);
		}
		return outputSum;
	}
	
	public void train(vector x, vector y) {
		/* train the network to interpolate the given table {x,y}*/
		Func<vector, double> Cp = u => {
			p = u;
			double sum = 0;

			for(int i = 0; i < x.size; i++) {
				sum += Pow(response(x[i]) - y[i], 2); //formula 3 in the notes
			}

			return sum / x.size;
		};
		var v = p;
		p = qn.qnewton(Cp, v); 
	}
}
