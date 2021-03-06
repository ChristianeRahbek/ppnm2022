using System;
using static System.Console;
using static System.Math;
using static vec;

class main{
	static void Main(){
		WriteLine($"Testing question A:");
		vec u = new vec(1, 2, 3);
		u.print("u = ");
		(-u).print("-u = ");
		vec v = new vec(-1, 0, 1);
		v.print("v = ");
		(u+v).print("u + v = ");
		var tmp = u*5;
		tmp.print("u * 5 = ");
		var w = 3*u - v;
		w.print("3*u - v = ");
		WriteLine($"");		

		WriteLine($"Testing question B:");
		double d = dot(u,v);
		Write($"dot(u, v) = {d}\n");
		w = cross(u, v);
		w.print("cross(u, v) = ");
		double n = u.norm();
		Write($"norm(u) = {n}\n");
		Write($"Testing toString() on u in next line: \n");
		WriteLine(u); //u.toString();
		
		WriteLine($"Testing question C:");
		Write($"Testing approx(u, u), expecting true: \n");
		Write($"u.approx(u) = {u.approx(u)}\n");
		Write($"approx(u,u) = {approx(u,u)}\n");
		Write($"Testing approx(u, v), expecting false: \n");
		Write($"u.approx(v) = {u.approx(v)}\n");
		Write($"approx(u,v) = {approx(u,v)}\n");
	}
}
