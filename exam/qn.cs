using System;
using static System.Console;
using static System.Math;

public class qn{
	public static readonly double eps = Pow(2, -26);

	private static Func<matrix, vector, double> f = (H, v) => {
		return rayleigh.Rayleigh(H, v);
	};

	public static (double, vector) qnewton(
		matrix H, /* matrix we want to find eigenvalue of */
		vector x, /* starting point */
		double acc = 1e-3 /* accuracy goal, on exit abs(gradient) < acc */
	) {
		int n = x.size;
		int steps = 0;
		int max_step = 10000;

		vector grad_x = gradient(H, x);
		double fx = f(H, x);
		matrix B = new matrix(n,n); //identity matrix
		B.setid();

		while(steps < max_step) { //no more than max_step
			steps++;
			vector dx = -B*grad_x;
			if(dx.norm() < eps*x.norm() || dx.norm() < acc) {
				Error.WriteLine("Accuracy is small enough");
				break;
			}

			vector z;
			double fz, lambda = 1;

			while(true) {
				z = x + dx*lambda;
				fz = f(H, z);

				if(fz < fx) break; //good step

				if(lambda < eps) {
					B.setid(); //resetting B
					break; //accepting after max_step steps
				}

				lambda /= 2;
			}

			vector s = z - x;
			vector grad_z = gradient(H, z);
			vector y = grad_z - grad_x; //comes from under eq 12
			vector u = s - B*y; //comes from under eq 12
			double u_Trans_y = u.dot(y);

			if(Abs(u_Trans_y) > 1e-6) {
				B.update(u, u, 1/u_Trans_y); //eq 18
			}

			double max = 1.5;
			double normz = z.norm();
			if(normz > max || normz < 1/max) { //renormalization
				x = z/normz;
				fx = f(H, x);
				grad_x = gradient(H, x);
			}
			else {
				x = z;
				grad_x = grad_z;
				fx = fz;
			}
		}
		return (fx, x);

	}


	public static vector gradient(matrix H, vector x) {
		return rayleigh.RayleighGrad(H, x);
	}
}
