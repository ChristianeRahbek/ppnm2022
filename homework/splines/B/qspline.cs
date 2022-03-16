using System;
using System.Diagnostics;
using static System.Console;

public class qspline {
	double[] x,y,b,c;
	public qspline(double[] x,double[] y){
		/* store xs and ys; calculate b and c */	
		this.x = x;
		this.y = y;
		int n = x.Length;
		b = new double[n-1];
		c = new double[n-1];
		c[0] = 0;
		var p = new double[n-1];
		var h = new double[n-1];
		for(int i = 0; i < n-1; i++) {
			h[i] = x[i+1] - x[i];
			p[i] = (y[i+1] - y[i]) / h[i];
		}
		for(int i = 0; i < n - 2; i++) {
			c[i + 1] = p[i + 1] - p[i] - c[i]*h[i]/h[i + 1]; 
		}
		c[n-2] /= 2;
		for(int i = n - 3; i >= 0; i--) {
			c[i] = (p[i + 1] - p[i] - c[i + 1] * h[i + 1]) / h[i];
		}
		for(int i = 0; i < n - 1; i++) {
			b[i] = p[i] - c[i]*h[i];
		}		
	}

	public double spline(double z){
	/* evaluate the spline */
		int i = binsearch(x, z);
		return y[i] + b[i]*(z-x[i]) + c[i]*(z-x[i])*(z-x[i]);


	}
	public double derivative(double z){
	/* evaluate the derivative */
		Trace.Assert(z >= x[0] && z <= x[x.Length - 1]);
		int i = binsearch(x, z);
		double dx = z - x[i];
		return b[i] + dx*2*c[i];
	}
	public double integral(double z){
	/* evaluate the integral */
		Func<double, double> f = delegate(double z1) {
			return spline(z1);
		};
		double result = integrate.quad(f, x[0], z);
		return result;
	}


	public static int binsearch(double[] x, double z) {
	/* locates the interval for z by bisection */
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

}
