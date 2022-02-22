using static System.Console;
using static System.Math;

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
	//QUESTION B:
	public double dot(vec other) {
		return this.x * other.x + this.y * other.y + this.z * other.z; //takes dot product like this: vec1.dot(vec2)
	}
	public static double dot(vec v, vec w) {
		return v.dot(w);
		//return v.x * w.x + v.y * w.y + v.z * w.z;
	}
	public vec cross(vec other) {
		double a1, b1, c1;
		a1 = this.y * other.z - this.z * other.y;
		b1 = this.z * other.x - this.x * other.z;
		c1 = this.x * other.y - this.y * other.x;
		return new vec(a1, b1, c1);
	}
	public static vec cross(vec v, vec w) {
		return v.cross(w);
	}
	public double norm() {
		return Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
	}
	public static double norm(vec v) {
		return v.norm();
	}
	public override string ToString() {
		return "Vector: [" + x + ", " + y + ", " + z + "]\n";
	}

	//QUESTION C:
	//making approx method
	
	static bool approx(double a, double b, double tau = 1e-9, double eps = 1e-9) {
		return Abs(a-b) < tau || Abs(a-b) / (Abs(a) + Abs(b)) < eps;
	}
	public bool approx(vec other) {
		return approx(this.x, other.x) || approx(this.y, other.y) || approx(this.z, other.z);
	}
	public static bool approx(vec v, vec w) {
		return v.approx(w);
	}
}
