using System;
using static System.Console;
using static System.Math;
using static cmath;

class main {
	
	static complex gamma(complex x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
		complex lngamma=x*log(x+1/(12*x-1/x/10))-x+log(2*PI/x)/2;
		return exp(lngamma);
	} 

	public static void Main() {
		complex a, b;
		for(double x = -4; x <= 4;  x += 1.0/8) {
			for(double y = -4; y <= 4;  y += 1.0/8) {
				a = new complex(x, y);
				b = gamma(a);
				WriteLine($"{abs(b)} {x} {y}");
			}
		}
	}

}
