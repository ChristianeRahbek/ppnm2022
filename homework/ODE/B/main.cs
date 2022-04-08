using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(){
		double start = 0, end = 10;
		double b = 0.25, c = 5.0;

		Func<double, vector, vector> f = delegate(double t, vector y) {
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega -c*Sin(theta));
		};

		vector y0 = new vector(PI - 0.1, 0.0);
		genlist<double> xs = new genlist<double>();
		genlist<vector> ys = new genlist<vector>();
		vector yend = ode.driver(f, start, y0, end, xs , ys);
		
		for(int i = 0; i < xs.size; i++) {
			WriteLine($"{xs.data[i]} {ys.data[i][0]} {ys.data[i][1]}");
		}
	}
}
