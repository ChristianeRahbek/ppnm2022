using System;
using static System.Console;

class main{
	public static void Main(){
		double n = 5;
		double dx = 1.0/64;
		for(double x = -n; x <= n; x+=dx) {
			WriteLine($"{x} {sfuns.exp(x)}");
		}
	}
}
