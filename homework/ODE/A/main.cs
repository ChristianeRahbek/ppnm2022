using System;
using static System.Math;

class main{
	public static void Main(){
		Func<double, vector, vector> f_test = delegate(double t, vector y) {
			double theta = y[0];
			double omega = y[1];
			return new vector(theta, -omega);
		};

		double start = 0, end = 10;
		vector y0_test = new vector(PI, PI);
		vector yend_test = ode.driver(f_test, start, y0_test,end, "testData.txt");
		yend_test.print();

		double b = 0.25, c = 5.0;
		Func<double, vector, vector> f = delegate(double t, vector y) {
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega -c*Sin(theta));
		};

		vector y0 = new vector(PI - 0.1, 0.0);
		vector yend = ode.driver(f_test, start, y0,end, "odeIntManData.txt");
		yend.print();
	}
}
