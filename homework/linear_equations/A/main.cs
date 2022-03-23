using System;
using System.Runtime;
using static System.Console;

class main{
	public static void Main() {
		int n = 7, m = 5, n2 = 5;
		matrix A = new matrix(n,m);
		matrix A2 = new matrix(n2,n2);
		vector b = new vector(n2);
		var rand = new Random(1);
	
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < m; j++) {
				A[i, j] = rand.NextDouble();
			}
		}

		for(int i = 0; i < n2; i++) {
			b[i] = rand.NextDouble();
			for(int j = 0; j < n2; j++) {
				A2[i, j] = rand.NextDouble();
			}
		}
		
		A.print("Matrix A:");
		var qrgs = new QRGS(A);
		matrix R = qrgs.R;
		matrix Q = qrgs.Q;
		R.print("Matrix R:");
		Q.print("Matrix Q:");
		
		var QR = Q*R;
		var QTQ = Q.T*Q;

		QTQ.print("Q.T*Q:");
		QR.print("Q*R:");
		WriteLine($"Testing if Q*R = A");
		
		if((Q*R).approx(A)) {
			WriteLine($"Successfull test");
		}
		else {
			WriteLine($"Test failed");
		}

		WriteLine($"");
		WriteLine($"Testing equation solving an {n2}x{n2} matrix");
		A2.print("Matrix A2:");
		b.print("Vector b:");
		var qrgs1 = new QRGS(A2);
		WriteLine($"Solving Q2*R2*x = b:");
		var x = qrgs1.solve(b);
		x.print("Using qrgs to solve for x");
		WriteLine($"Testing if A2*x = b");
		var Ax = A*x;
		Ax.print("Vector A2*x:");
		if((A2*x).approx(b)) {
			WriteLine($"Successfull test, we found x!");
		}
		else {
			WriteLine($"Test failed");
		}
	}
}
