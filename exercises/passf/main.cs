using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class passf {
	public static void Main() {
		WriteLine($"Table of Sin(x) from 0 to {1*PI} in steps of {1*PI/10}:");
		tab(1);
		WriteLine("");
		WriteLine($"Table of Sin(2x) from 0 to {2*PI} in steps of {2*PI/10}:");
		tab(2);
		WriteLine("");
		WriteLine($"Table of Sin(3x) from 0 to {3*PI} in steps of {3*PI/10}:");
		tab(3);
	}
	public static void tab(double k) {
		table.make_table(Sin, 0, k*PI, k*PI/10);
	}
}
