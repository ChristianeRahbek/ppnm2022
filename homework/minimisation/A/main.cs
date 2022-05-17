using System;
using static System.Console;
using static System.Math;

public class main {
	public static void Main() {
		int i = 0, j = 0;
		Func<vector, double> rosenbrock = x => {
			i++;
			return Pow((1 - x[0]), 2) + 100 * Pow((x[1] - Pow(x[0], 2)), 2);
		};

		Func<vector, double> himmelblau = x => {
			j++;
			return Pow((Pow(x[0], 2) + x[1] - 11), 2) + Pow((x[0] + Pow(x[1], 2) - 7), 2);
		};

		vector ros_x0 = new vector(0, 0), him_x0 = new vector(0,0); //start guesses
		
		vector ros_res = qn.qnewton(rosenbrock, ros_x0);
		WriteLine($"Finding minima...");
		WriteLine($"");
		WriteLine($"Looking at the Rosenbrock valley function:");
		WriteLine($"Minima found to be at ({ros_res[0]}, {ros_res[1]}) in {i} steps.");
		WriteLine($"Actual minima is at (1, 1)");
		
		WriteLine($"");
		
		vector him_res = qn.qnewton(himmelblau, him_x0);
		WriteLine($"Looking at the Himmelblau function:");
		WriteLine($"Minima found to be at ({him_res[0]}, {him_res[1]}) in {j} steps.");
		WriteLine($"Actual minima is (3, 2)");

	}

}
