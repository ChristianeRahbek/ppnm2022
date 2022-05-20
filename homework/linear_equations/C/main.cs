using System;
using static System.Console;
using System.Diagnostics;

class main{
	public static void Main() {
		int N = 300;
		var rand = new Random();

		for(int n = 10; n <= N; n += 10) {
			var A = new matrix(n, n);

			for(int i = 0; i < n; i++) {
				for(int j = 0; j < n; j++) {
					A[i, j] = rand.Next();
				}
			}

			var timer = new Stopwatch();

			timer.Start();
			var qrgs = new QRGS(A);
			timer.Stop();

			var timeElapsed = timer.ElapsedTicks; 

			WriteLine($"{n} {timeElapsed}");

		}
	}
}
