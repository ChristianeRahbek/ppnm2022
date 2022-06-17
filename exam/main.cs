using System;
using static System.Console;
using System.Diagnostics;
using static System.Math;

class main{
	public static void Main() {
		WriteLine("_______________________________________________________________________________");
		WriteLine("");

		//Testing if the program works
		int n = 5;

		WriteLine($"Testing if we can find the lowest eigenvalue and its eigenvector of a random {n}x{n} matrix...");
		var (e, x, A) = findRandom(n);

		//Printing results
		A.print("Random matrix A = ");
		WriteLine($"Lowest eigenvalue, e, of A is {e}");
		x.print("Eigenvector x = ");
		WriteLine($"Testing if Ax = ex...");

		var Ax = A*x;
		var ex = e*x;
		double err = (Ax - ex).norm();
		if(err < 0.01) {
			WriteLine("Ax = ex, the right eigenvalue and eigenvector was found!");
			WriteLine($"The error is {err}");
		}
		else {
			WriteLine("Ax != ex, the pression is either not good enough or the wrong values has been found.");
			WriteLine($"The error is {err}");
		}

		WriteLine("");
		WriteLine("_______________________________________________________________________________");
		WriteLine("");

		WriteLine("Now we will investigate the scaling of the method...");
		string scaleFile = "scaling.txt";
		double maxTime = 3; //time in seconds
		testScaling(maxTime, scaleFile);
		WriteLine("Results can be found in '" + scaleFile + "' and will be plotted in 'scaling.png'");

		WriteLine("");
		WriteLine("_______________________________________________________________________________");
		WriteLine("");

		WriteLine("We will now try to find the ground state of the Hydrogen atom");
		int noOfPoints = 50;
		double rmax = 10;
		var rand = new Random();
		var H = makeHamiltonian(noOfPoints, rmax);
		vector v = new vector(noOfPoints); //random first guess
		for(int i = 0; i < noOfPoints; i++) {
			v[i] = -rand.NextDouble();
		}

		WriteLine($"Finding the ground state with a {noOfPoints}x{noOfPoints} Hamiltonian with rmax = {rmax}...");
		var (e0, x0) = qn.qnewton(H, v);
		WriteLine($"The found ground state energy is: {e0} Hartree");
		WriteLine($"The tabel value is given by: -0.5 Hartree");
		WriteLine($"The difference is {Abs(-0.5-e0)} Hartree");

	}

	private static (double, vector, matrix) findRandom(int n) {
		var rand = new Random();
		var A = new matrix(n,n);
		var v = new vector(n);
		for(int i = 0; i < n; i++) {
			for(int j = i; j < n; j++) {
				A[i,j] = rand.NextDouble(); //Making a random symmetric matrix
				A[j, i] = A[i, j];
			}
			v[i] = rand.NextDouble(); //random first guess for v
		}

		//Finding lowest eigenval and its eigenvector
		var (e, x) = qn.qnewton(A, v);

		return (e, x, A);
	}

	private static void testScaling(double maxTime, string filename) { //insert maxTime in seconds
		int i = 10;
		double e; vector x; matrix A;
		using(var outfile = new System.IO.StreamWriter(filename)) {
			while(true){
				//timing my implementation
				Stopwatch timer = new Stopwatch();
				timer.Start();
				(e, x, A) = findRandom(i);
				timer.Stop();

				double time = timer.ElapsedMilliseconds;

				outfile.WriteLine($"{i} {time}");

				if(time >= maxTime * 1000) break;
				i += 20;
			}
		}
	}

	public static matrix makeHamiltonian(int noOfPoints, double rmax) {
		double dr = rmax/noOfPoints;
		vector r = new vector(noOfPoints);

		for(int i = 0; i < noOfPoints; i++) {
			r[i] = dr * (i+1);
		}

		matrix H = new matrix(noOfPoints,noOfPoints);

		for(int i = 0; i < noOfPoints - 1; i++){
			matrix.set(H, i, i, -2);
			matrix.set(H, i, i+1, 1);
			matrix.set(H, i+1, i, 1);
		}

		matrix.set(H, noOfPoints - 1, noOfPoints - 1, -2);
		H *= -0.5/dr/dr;

		for(int i = 0; i < noOfPoints; i++) {
			H[i,i] += -1 / r[i];
		}
		return H;
	}
}
