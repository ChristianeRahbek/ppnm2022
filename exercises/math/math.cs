using static System.Console;
using static System.Math;

public static class math{
	public static void test(){
		double x = Sin(9), y = Cos(9);
		Write($"Sin^2 + Cos^2 = {x*x + y*y}\n");
		
	}

	public static void sqrt2(){
		double sqrt2 = Sqrt(2.0);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal to 2)\n");

	}
	
	public static void expPi(){
		double expPi = Exp(PI);
		Write($"exp(pi) = {expPi}\n");
		Write($"ln(exp(pi)) = {Log(expPi)} (should be equal to pi)\n");
	}
	public static void piE(){
		double piE = Pow(PI, E);
		Write($"pow(pi,e) = {piE}\n");
		Write($"Log(pow(pi,e),pi) = {Log(piE,PI)} (should be equal to e)\n");
	}

}
