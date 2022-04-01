using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		//Making the Hamiltonian matrix
		(matrix H, vector r, double dr) = makeHamiltonian(20, 10);
		(matrix H1, vector r1, double dr1) = makeHamiltonian(10, 10);
		(matrix H2, vector r2, double dr2) = makeHamiltonian(20, 5);
		
		//convergence with respct to rmax
		double[] tabVal_energy = new double[] {}; //FIND TABLE VALUES
		rMaxConv(tabVal_energy);
		nConv(tabVal_energy);


		//Performing eigenvalue decomposition
		vector e, e1, e2; matrix V, V1, V2;
		(e, V) = jacobi.cyclic(H);
		(e1, V1) = jacobi.cyclic(H1);
		(e2, V2) = jacobi.cyclic(H2);

		//Printing results
		e.print("Eigenvalues points = 20, dr = 10: ");
		e1.print("Eigenvalues points = 10, dr = 10: ");
		e2.print("Eigenvalues points = 20, dr = 5: ");

	}

	public static void rMaxConv(double[] tabVal_energy) {
		double maxR = 10;
		int nOofPoints = 20
		using(var outfile = new System.IO.StreamWriter("rMaxConv_data")) {
			for(int i = 0; i < tabVal_energy.Length(); i++) { //checking for all tab values
				for(double r = 0; r <= maxR; r += 1.0/8) {
					(matrix H1, vector r1, double dr1) = makeHamiltonian(noOfPoints, r);
					(vector e, matrix V) = jacobi.cyclic(H1);
					outfile.WriteLine({r} {e[i]} {tabVal_energy[i]});
				}
			}
		}
	}

	public static void nConv(double[] tabVal_energy) {
		int maxN = 20;
		double rMax = 10;
		using(var outfile = new System.IO.StreamWriter("nConv_data")) {
			for(int i = 0; i < tabVal_energy.Length(); i++) { //checking for all tab values
				for(int n = 0; n <= maxN; n++) {
					(matrix H1, vector r1, double dr1) = makeHamiltonian(n, rMax);
					(vector e, matrix V) = jacobi.cyclic(H1);
					outfile.WriteLine({n} {e[i]} {tabVal_energy[i]});
				}
			}
		}
	}

	public static (matrix, vector, double) makeHamiltonian(int noOfPoints, double rmax) {
		double dr = rmax / (noOfPoints + 1);
		vector r = new vector(noOfPoints);
		
		for(int i = 0; i < noOfPoints; i++) {
			r[i]=dr*(i+1);
		}

		matrix H = new matrix(noOfPoints,noOfPoints);

		for(int i = 0; i < noOfPoints - 1; i++){
			matrix.set(H, i, i, -2);
			matrix.set(H, i, i+1, 1);
			matrix.set(H, i+1, i, 1);
		}

		matrix.set(H, noOfPoints - 1, noOfPoints - 1, -2);
		H*=-0.5/dr/dr;

		for(int i = 0; i < noOfPoints; i++) {
			H[i,i] += -1 / r[i];
		}
		return (H, r, dr);
	}
}
