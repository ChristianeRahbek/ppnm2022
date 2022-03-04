using System;
using static System.Console;
using static System.Math;

class main{

	public static void Main(){
		int ncalls = 0;
		Func<double, double> f = delegate(double x){
			ncalls++;
			return Log(x)/Sqrt(x);
		}
		double result = integrate.quad(f, a:0, b:1, acc: 1e-6, eps: 1e-6);
		WriteLine($"{result}");
	}

}
