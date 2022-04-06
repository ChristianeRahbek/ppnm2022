using System;
using static System.Math;

public class ode {	
	public static (vector, vector) rkstep12(Func<double, vector, vector> f, double x, vector y, double h) {
		vector k0 = f(x,y); /* embedded lower order formula (Euler) */
		vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
		vector yh = y+k1*h;     /* y(x+h) estimate */
		vector er = (k1-k0)*h;  /* error estimate */
		return (yh,er);
	}

	public static vector driver(
		Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
		double x,                    /* the start-point x */
		vector y,                    /* y(x) */
		double b,                    /* the end-point of the integration */
		string filename,	     /* name of datafile used to plot */
		double h=0.01,               /* initial step-size */
		double acc=0.01,             /* absolute accuracy goal */
		double eps=0.01              /* relative accuracy goal */
	) {
		if(x > b) throw new Exception("driver: we cannot have x > b");
		using(var outfile = new System.IO.StreamWriter(filename)) {
		do {
			if (x >= b) {
				return y; /* loops stops and job is done */
			}

			if(x + h > b) {
				h = b - x; /* last step should be at b */
			}
			
			var (yh, erv) = rkstep12(f, x, y, h);
			double tol = Max(acc, yh.norm()*eps) * Sqrt(h/(b - x));
			double err = erv.norm();
			if(err <= tol) { //accepting step
				x += h;
				y = yh;

				outfile.WriteLine($"{x} {y[0]} {y[1]}");
			}

			h *= Min(Pow(tol/err, 0.25)*0.95, 2);
			
		} while(true);
		}

	}

}




