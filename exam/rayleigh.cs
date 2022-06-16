using static System.Math;
using static System.Console;
using System;

public class rayleigh{
	public static double Rayleigh(matrix H, vector v) {
		return (v%(H*v))/(v%v); // vT*H*v/(vT*v)
	}

	public static vector RayleighGrad(matrix H, vector v) {
		return 2*((H*v) - Rayleigh(H,v)*v)/(v%v);
	}
}
