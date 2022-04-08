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
		Func<double,vector,vector> f,    /* the f from dy/dx=f(x,y) */
		double x,                        /* the start-point x */
		vector y,                        /* y(x) */
		double b,                        /* the end-point of the integration */
		genlist<double> xsFound = null,	 /* stores found xs*/
		genlist<vector> ysFound = null,  /* stores found ys */
		double h=0.01,                   /* initial step-size */
		double acc=0.01,                 /* absolute accuracy goal */
		double eps=0.01                  /* relative accuracy goal */
	) {
		if(x > b) throw new Exception("driver: we cannot have x > b");
		
		do {
			if (x >= b) {
				return y; /* loops stops and job is done */
			}

			if(x + h > b) {
				h = b - x; /* last step should be at b */
			}
			
			var (yh, erv) = rkstep12(f, x, y, h);
			vector tol = new vector(erv.size);
			bool tolIsFine = true;
			for(int i = 0; i < tol.size; i++) {
				tol[i] = Max(acc, Abs(yh[i])*eps) * Sqrt(h/(b - x));
				tolIsFine = tolIsFine && erv[i] < tol[i];
			}
			if(tolIsFine) { //accepting step
				x += h;
				y = yh;

				xsFound.push(x);
				ysFound.push(y);
			}
			double factor = tol[0]/Abs(erv[0]);
			for(int i = 1; i < tol.size; i++) {
				factor = Min(factor, tol[i]/Abs(erv[i]));
			}

			h *= Min(Pow(factor, 0.25)*0.95, 2);
			
		} while(true);

	}

}




