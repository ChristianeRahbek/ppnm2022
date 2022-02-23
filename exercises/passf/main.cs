using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class passf {
	public static void Main() {
		table(1);
		table(2);
		table(3);
	}
	public static void table(double k) {
		make_table(Sin, 0, k*PI, k*PI/10);	
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
