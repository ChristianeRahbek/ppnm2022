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
		int a = 0;
		
		for(double i = 0.0; i <= N- stepLength; i += stepLength) {
			xlist[a] = i;
			ylist[a] = Sin(xlist[a]);
			intlist[a] = 1 - Cos(xlist[a]);
			WriteLine($"{xlist[a]} {ylist[a]} {intlist[a]}");
			a++;
		}

		Write("\n\n"); //making new index

		for(double z = xlist[0]; z <= xlist[xlist.Length - 1]; z += 1.0/16) {
			WriteLine($"{z} {linterp(xlist, ylist, z)} {linterpInteg(xlist, ylist, z)}");
		}

	}



//binary search
	public static int binsearch(vector x, double z) {
	/* locates the interval for z by bisection */ 
		int i=0, j=x.size-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}


//Linear interpolation at z
	public static double linterp(vector x, vector y, double z){
		int i = binsearch(x, z);
		double dy = y[i + 1] - y[i];
		double dx = x[i + 1] - x[i];
		return y[i] + dy/dx * (z-x[i]); 
	}

//calculate integral from x[0] to z
	public static double linterpInteg(vector x, vector y, double z) {
		Func<double, double> f = delegate(double z1){
			return linterp(x, y, z1);
		};
		double result = integrate.quad(f, x[0], z);
		return result;
	}
}
