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
		
		int N = 100;
		double step = (t[t.size - 1] - t[0]) / N;		

		for(int i = 0; i < t.size; i++) {
			WriteLine($"{t[i]} {y[i]} {dy[i]}");
		}

		var ls = new lsfit(t, y, dy, f);
		 
/*		var c = ls.c;
		var cov = ls.cov;		

		double lambda = c[1];
		double dlambda = Sqrt(cov[1,1]); //uncertainty om lambda
		
		double T = -Log(2.0)/lambda; //Findind half life.
		//double dT = T*; //uncertainty on T
*/		
		WriteLine(""); WriteLine("");

		for(double i = t[0] ; i <= t[t.size - 1]; i += step) {
			WriteLine($"{i} {Exp(ls.eval(i))}");
		}		
	}
}
