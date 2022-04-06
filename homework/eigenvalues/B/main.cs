using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		//Making the Hamiltonian matrix
		//(matrix H, vector r, double dr) = makeHamiltonian(20, 10);
		//(matrix H1, vector r1, double dr1) = makeHamiltonian(10, 10);
		//(matrix H2, vector r2, double dr2) = makeHamiltonian(20, 5);
		
		//convergence with respct to rmax
		
		double[] tabVal_energy = new double[] {-0.5, -0.125}; //FIND TABLE VALUES
		rMaxConv(tabVal_energy);
	
		WriteLine(""); WriteLine("");
		
		nConv(tabVal_energy);
		
	}

	public static void rMaxConv(double[] tabVal_energy) {
		double maxR = 15,dr=0.1;
		for(int i = 0; i < tabVal_energy.Length; i++) { //checking for all tab values
			WriteLine(""); WriteLine("");
			for(double r = 1; r <= maxR; r += 0.5) {
				int noOfPoints = (int)(r/dr);
				matrix H1 = makeHamiltonian(noOfPoints, r);
				(vector e, matrix V) = jacobi.cyclic(H1);
				WriteLine($"{r} {e[i]} {tabVal_energy[i]}");
			}
		}
	}

	public static void nConv(double[] tabVal_energy) {
		int maxN = 100;
		double rMax = 15.0;
		for(int i = 0; i < tabVal_energy.Length; i++) { //checking for all tab values
			WriteLine(""); WriteLine("");
			for(int n = 10; n <= maxN; n++) {
				matrix H1 = makeHamiltonian(n, rMax);
				(vector e, matrix V) = jacobi.cyclic(H1);
				WriteLine($"{rMax/n} {e[i]} {tabVal_energy[i]}");
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
