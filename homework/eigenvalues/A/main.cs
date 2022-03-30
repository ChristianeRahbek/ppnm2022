using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		//Making a random symmetric matrix
		int n = 5, m = n;
		var D = new matrix(n,m);
		var I = new matrix(n,n);
		I.set_identity();
		var rand = new Random();
		for(int i = 0; i < n; i++) {
			for(int j = 0; j <= i; j++) {
				D[i, j] = rand.NextDouble();
				D[j, i] = D[i, j];
			}
		}
		
		//Performing eigenvalue decomposition
		var A = D.copy();
		vector e; matrix V;
		(e, V) = jacobi.cyclic(D);

		//Printing results
		A.print("Random matrix A: ");
		WriteLine($"");
		V.print("Orthorgonal matrix of eigenvectors V: ");
		WriteLine($"");
		D.print("Diagonal matrix with corresponding eigenvalues D: ");
		WriteLine($"");
		WriteLine("Checking that");
		WriteLine($"A = VD(V^T): {A.approx(V*D*V.transpose())}");
		WriteLine($"(V^T)AV = D: {D.approx(V.transpose()*A*V)}");
		WriteLine($"(V^T)V = I: {I.approx(V.transpose()*V)}");
		WriteLine($"V(V^T) = I: {I.approx(V*V.transpose())}");

	}
}
