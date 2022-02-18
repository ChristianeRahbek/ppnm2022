using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class passf {
	public static void Main() {
		make_table(Sin, 0, PI, PI/10);
		make_table(Sin, 0, 2*PI, 2*PI/10);
		make_table(Sin, 0, 3*PI, 3*PI/10);	
	}

	static void make_table(Func<double, double> f, double a, double b, double dx) {
		//List<string> list = new List<string>();
		
		WriteLine($"Printing table from x = {a} to x = {b} in steps of {dx} of the function:");
		WriteLine(f);
		if(a > b) {
			WriteLine($"{a} {f(a)}");
			return;
		}
		else {
			WriteLine($"{a} {f(a)}");
			for(double x = 1; a + x*dx < b; x+=1) {
				WriteLine($"{a + x*dx} {f(a + x*dx)}");
			}

			WriteLine($"{b} {f(b)}");
			return;
		}
	}
}
