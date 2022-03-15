using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(){
		int N = 10;
		int steps = 2;
		double stepLength = 1.0/steps;
		double[] xlist = new double[N*steps];
		double[] ylist = new double[N*steps];
		double[] intlist = new double[N*steps]; //list to check integral
		double[] divlist = new double[N*steps]; //lost to check derrivative
		int a = 0;
		
		for(double i = 0.0; i<= N-stepLength; i += stepLength) {
			xlist[a] = i;
			ylist[a] = Sin(i);
			intlist[a] = -Cos(i);
			divlist[a] = Cos(i);
			a++;
		}

		qspline s = new qspline(xlist, ylist);
		
		for(int i = 0; i < xlist.Length; i++) {
			WriteLine($"{xlist[i]} {ylist[i]} {s.spline(xlist[i])} {s.integral(xlist[i])} {intlist[i]} {s.derivative(xlist[i])} {divlist[i]}");
		}

	}
}
