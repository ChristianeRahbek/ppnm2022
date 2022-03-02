using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class expData{
	public static void Main(){
		int n = 5;
		for(int i = -n; i <= n; i++) {  
			WriteLine($"{i} {Exp(i)}");
		}
	}

}
