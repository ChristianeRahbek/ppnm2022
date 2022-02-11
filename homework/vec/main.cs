using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		vec u = new vec(1, 2, 3);
		u.print("u = ");
		(-u).print("-u = ");
		vec v = new vec(-1, 0, 1);
		v.print("v = ");
		(u+v).print("u + v = ");
		var tmp = u*5;
		tmp.print("u * 5 = ");
		var w = 3*u - v;
		w.print("w = 3*u - v = ");
	}
}
