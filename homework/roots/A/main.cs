using System;
using static System.Console;
using static System.Math;

class main {
	public static void Main() {
		var x0 = new vector(0, 0);
		Func<vector,vector> f = x => Pow(1 - x[0], 2) + 100 * Pow(x[1] - x[0]*x[0], 2); 
		var res = roots.newton(f, x0);
		res.print("The roots are: ");
		WriteLine("does it compile?");
	}
}
