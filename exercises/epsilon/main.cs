using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		maxVal();
		minVal();
		machineEpsilon();
		tiny();
		WriteLine($"");
		Write($"Testing approx function...");
		Write($"a = 1.0, b = 2.0 should return false, does return: {approx(1.0, 2.0)}\n");
		Write($"a = 1.0, b = 1.0 should return true, does return: {approx(1.0, 1.0)}\n");
	}

	static void maxVal(){
		int i = 1; while(i+1 > 1) {i++;}
		Write($"my max int = {i}\n");
		int k = int.MaxValue;
		Write($"Compared to: int_exp = {k}\n");
		WriteLine($"");
	}
	static void minVal(){
		int i = 1; while(i-1 < i) {i--;}
		Write($"my min int = {i}\n");
		int k = int.MinValue;
		Write($"Compared to int_exp = {k}\n");
		WriteLine($"");
	}
	static void machineEpsilon(){
		double x = 1; while(1+x!=1) {x/=2;} x*=2;
		float y = 1F; while((float) (1F + y) != 1F) {y/=2F;} y*=2F;
		Write($"my double machine epsilon = {x}\n");
		Write($"compared to: {Pow(2,-52)}\n");
		Write($"my float machine epsilon = {y}\n");
		Write($"compared to: {Pow(2,-23)} \n");
		WriteLine($"");
	}
	static void tiny(){
		int n = (int) 1e6;
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA = 0, sumB = 0;

		sumA += 1; for(int i = 0; i<n; i++) {sumA += tiny;}
		Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e}\n");

		for(int i = 0; i < n; i++) {sumB += tiny;} sumB += 1;
		Write($"sumB-1 = {sumB-1:e} should be {n*tiny:e}\n");
		//when i add epsilon to 1 i will still get 1, as the computer runs down the numbers.
		//but when I add a lot of epsilons first they add up to become big, and then I can add them to 1.
		WriteLine($"");
	}
	static bool approx(double a, double b, double tau = 1e-9, double epsilon= 12e-9){
		return Abs(a-b) < tau || Abs(a-b)/(Abs(a) + Abs(b)) < epsilon;
	}
}
