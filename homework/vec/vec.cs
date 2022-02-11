using static System.Console;

public class vec{
	public double x, y, z;
	
	//constructors
	public vec() {x = y = z = 0;}
	public vec(double a, double b, double c) {
		x = a;
		y = b;
		z = c;
	}

	//applying print methods
	public void print(string s) {
		Write(s);
		Write($"{x} {y} {z}\n");
	}
	
	public void print() {this.print("");} //using the other print method to define this one.
	
	//mathematical operators
	public static vec operator*(vec v, double c) {
		return new vec(c*v.x, c*v.y, c*v.z);
	}
	public static vec operator*(double c, vec v) {
		return v*c;		//using the operator from above
	}
	public static vec operator+(vec u, vec v) {
		return new vec(u.x + v.x, u.y + v.y, u.z + v.z);
	}
	public static vec operator-(vec u, vec v) {
		return new vec(u.x - v.x, u.y - v.y, u.z - v.z);
	}
	public static vec operator-(vec v) {
		return -1*v;				//using the multiply operator
	}

}
