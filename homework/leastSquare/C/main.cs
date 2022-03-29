using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main() {
		vector ts = new vector(new double[] {1, 2, 3, 4, 6, 9, 10, 12, 15});
		vector ys = new vector(new double[] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1});
		vector dys = new vector(new double[] {5, 5, 5, 5, 5, 5, 1, 1, 1, 1});
		var f = new Func<double, double>[] {z => 1, z => z};
		
		vector t = new vector(ts.size), y = new vector(ys.size), dy = new vector(dys.size);
		for(int i = 0; i < ts.size; i++) {
			t[i] = ts[i];
			y[i] = Log(ys[i]);
			dy[i] = dys[i]/ys[i];
		}
				
		for(int i = 0; i < t.size; i++) {
			WriteLine($"{t[i]} {y[i]} {dy[i]}");
		}

		var ls = new lsfit(t, y, dy, f);

		WriteLine(""); WriteLine("");

		Tuple<double, double, double> fitfuncs;
		for(double i = t[0]; i <= t[t.size - 1]; i += 1.0/8) {
			fitfuncs = ls.eval(i);
			WriteLine($"{i} {fitfuncs.Item1} {fitfuncs.Item2} {fitfuncs.Item3}");
		}
		
	}
}
