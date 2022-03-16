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
			ylist[a] = Sin(xlist[a]);
			intlist[a] = 1-Cos(xlist[a]);
			divlist[a] = Cos(xlist[a]);
			WriteLine($"{xlist[a]} {ylist[a]} {divlist[a]} {intlist[a]}");
			a++;
		}

		Write("\n\n");

		qspline s = new qspline(xlist, ylist);
		
		for(double z = xlist[0]; z <= xlist[xlist.Length-1]; z+=1.0/16) {
			WriteLine($" {z} {s.spline(z)} {s.derivative(z)} {s.integral(z)}");
		}

	}
}
