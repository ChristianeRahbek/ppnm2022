using System;
using static System.Console;
using static System.Math;

public class qn{
	public static readonly double eps = Pow(2, -26);

	public static vector qnewton(
		Func<vector,double> f,  /* objective function */ 
		vector x, /* starting point */
		double acc = 1e-3 /* accuracy goal, on exit abs(gradient) < acc */
	) {
		int n = x.size;
		int steps = 0;
		int max_step = 10000;

		vector grad_x = gradient(f, x);
		double fx = f(x);
		matrix B = new matrix(n,n); //identity matrix
		B.setid();
		
		while(steps < max_step) { //no more than max_step 
			steps++;
			vector dx = -B*grad_x;
			if(dx.norm() < eps*x.norm() || dx.norm() < acc) {
				Error.WriteLine("Step not accepted");
				break;
			}

			vector z;
			double fz, lambda = 1;

			while(true) {
				z = x + dx*lambda;
				fz = f(z);
				
				if(fz < fx) break;
				
				if(lambda < eps) {
					B.setid(); //resetting B
					break; //accepting after max_step steps
				}

				lambda /= 2;
			}
			
			vector s = z - x;
			vector grad_z = gradient(f, z);
			vector y = grad_z - grad_x; //comes from under eq 12
			vector u = s - B*y; //comes from under eq 12
			double u_Trans_y = u.dot(y);
		
			if(Abs(u_Trans_y) > 1e-6) {
				B.update(u, u, 1/u_Trans_y); //eq 18
			}
		
			x = z;
			grad_x = grad_z;
			fx = fz;
		}
		return x;
		
	}
	

	public static vector gradient(Func<vector, double> f, vector x) {
		int n = x.size;
		vector grad = new vector(n);
		double fx = f(x);

		for(int i = 0; i < n; i++) {
			double dx = Abs(x[i]) * eps;
			if(Abs(x[i]) < Sqrt(eps)) dx = eps;
			
			x[i] += dx;
			grad[i] = (f(x) - fx)/dx; //(fx2 - fx1)/(x2-x1) when finding gradient traditionally
			x[i] -= dx;
		}

		return grad;
	}
}
