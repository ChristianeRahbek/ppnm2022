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
		var y_found = ode.driver(sch, rmin, sch0, rmax, "ode_calcs.txt",acc:1e-3,eps:1e-3);
		return new vector(y_found);
	}

	public static double findingEnergy(double rmin, double rmax) {
		Func<vector,vector> M_eps = delegate(vector e) {
			var f = F_r(e[0], rmax, rmin);
			var res=new vector(f[0]);
			return res;
		};
		var energies = roots.newton(M_eps, new vector(-1.0), eps:1e-3);
		return energies[0];
	}

	//public static void Main(string[] args) {
	public static void Main() {
		double rmin = 1e-3;
		double rmax = 8.0;
		//if(args.Length>0) rmin=double.Parse(args[0]);
		//if(args.Length>1) rmax=double.Parse(args[1]);
		
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
			}
		}


		using(var outfile = new System.IO.StreamWriter("convergence.txt")) {
			for(double r_max = 0.5; r_max <= rmax; r_max += 0.2) {
				outfile.WriteLine($"{r_max} {findingEnergy(rmin, r_max)} {-0.5}");
			}
			
			outfile.WriteLine();
		
			for(double r_min = 0.5; r_min >= rmin; r_min -= 0.01) {
				outfile.WriteLine($"{r_min} {findingEnergy(r_min, rmax)} {-0.5}");
			}
		}
	}
}
