using System;
using System.Runtime;
using static System.Console;

class main{
	public static void Main() {
		int n =5, m = 5;
		matrix A = new matrix(n,m);
		var rand = new Random(1);
	
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < m; j++) {
				A[i, j] = rand.NextDouble();
			}
		}
		
		A.print("Matrix A:");
		var qrgs = new QRGS(A);
		matrix R = qrgs.R;
		matrix Q = qrgs.Q;
		R.print("Matrix R:");
		Q.print("Matrix Q:");
		
		var QR = Q*R;
		
		var B = qrgs.inverse();
		
		QR.print("Q*R:");
		B.print("Matrix B:");
		WriteLine($"Testing if A*B = I");
		
		var I = new matrix(n,n);
		for(int i = 0; i < n; i++) {
			I[i,i] = 1;
		}

		var AB = A*B;		
		AB.print("Matrix A*B:");

		if(AB.approx(I)) {
			WriteLine($"Successfull test");
		}
		else {
			WriteLine($"Test failed");
		}
	}
}
