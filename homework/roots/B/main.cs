using System;
using static System.Console;
using static System.Math;

class main {
	public static vector F_r(double eps, double rmax, double rmin) {	
		vector sch0 = new vector(new double[] {rmin-rmin*rmin, 1-2*rmin}); //f and f'
		Func<double,vector,vector> sch = (r, y) => {
			vector res = new vector(2);
			res[0] = y[1];
			res[1] = -2*y[0]*(1/r + eps);
			return res;
		};
		//Error.WriteLine("ode beginning...");
		var y_found = ode.driver(sch, rmin, sch0, rmax, "ode_calcs.txt");
		//Error.WriteLine("ode end...");
		return new vector(y_found);
	}

	public static double findingEnergy(double rmin, double rmax) {
		Func<vector,vector> M_eps = delegate(vector e) {
			return F_r(e[0], rmax, rmin);
		};
		Error.WriteLine("Made it through F_(r)?");
		var energies = roots.newton(M_eps, new vector(-1.0));
		return energies[0];
	}

	public static void Main() {
		double rmin = 1e-3;
		double rmax = 8.0;
/*		
		double E = findingEnergy(rmin, rmax);
		WriteLine($"Finding the lowest energy solution for rmin = {rmin} and rmax = {rmax}...");
		WriteLine($"The energy is found to be {E} Hartree");
		WriteLine($"The expected result is -0.5 Hartree");
		if(Abs(E+0.5) <= 0.1) {
			WriteLine("The results match");
		}
		else WriteLine("The results does not match");

		using(var outfile = new System.IO.StreamWriter("wavefunc_result.txt")) {
			for(double r = rmin; r <= rmax; r+= 1.0/64) {
				double Fr = F_r(E, r, rmin)[0];
				outfile.WriteLine($"{r} {Fr} {r*Exp(-r)}");
			}//infinite loop (maybe) somewhere after this.
		}
*/
		using(var outfile = new System.IO.StreamWriter("convergence.txt")) {
			Error.WriteLine("Entering first for loop");
			for(double r_max = 1; r_max <= 8; r_max += 0.2) {
				Error.WriteLine($"r_max = {r_max}");
				outfile.WriteLine($"{r_max} {findingEnergy(rmin, r_max)} {-0.5}");
				Error.WriteLine("writeline success");
			}
			Error.WriteLine("first for loop done");
			outfile.WriteLine();

			for(double r_min = 1; r_min <= 1e-3; r_min -= 0.01) {
				outfile.WriteLine($"{r_min} {findingEnergy(r_min, rmax)} {-0.5}");
			}
		}

	}
}
