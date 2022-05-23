using System;
using static System.Console;
using System.Diagnostics;

class main{
	public static void Main() {
		int N = 4;
		var rand = new Random();

		for(int n = 3; n <= N; n += 1) {
			Error.WriteLine($"For loop {n-2}/{N-2}");
			var A = new matrix(n, n);
			Error.WriteLine($"Made {n}x{n} matrix successfully");
			for(int i = 0; i < n; i++) {
				for(int j = 0; j < n; j++) {
					A[i, j] = rand.Next(1, 9);
				}
			}

			Error.WriteLine($"Filled random matrix successfully");

			var timer = new Stopwatch();
			var timerOptim = new Stopwatch();

			Error.WriteLine($"Starting first timer");
			timer.Start();
			var (e, V) = jacobi.cyclic(A);
			timer.Stop();
			Error.WriteLine($"Ended first timer");

			var timeElapsed = timer.ElapsedTicks; 

			Error.WriteLine($"Starting second timer");
			timerOptim.Start();
			var (e1, V1) = jacobi.cyclicOptim(A);
			timerOptim.Stop();
			Error.WriteLine($"Ended second timer");

			var timeElapsedOptim = timerOptim.ElapsedTicks;

			Error.WriteLine($"e[{n-1}] = {e[n-1]}");
			Error.WriteLine($"e1[{n-1}] = {e1[n-1]}");

			WriteLine($"{n} {timeElapsed} {timeElapsedOptim}");

		}
	}
}
