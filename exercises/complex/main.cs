using static System.Math;
using static System.Console;
using static cmath;

public class main {
	public static void Main(){
		calculate();
	}

	public static void calculate(){
		complex a = -1;
		WriteLine($"sqrt(-1) = {sqrt(a)}");
		WriteLine($"sqrt(i) = {sqrt(I)}");
		WriteLine($"exp(i) = {exp(I)}");
		WriteLine($"exp(i*pi) = {exp(I * PI)}");
		WriteLine($"i^i = {cmath.pow(I, I)}");
		WriteLine($"ln(i) = {log(I)}");
		WriteLine($"sin(i*pi) = {sin(I * PI)}");
	}
}
