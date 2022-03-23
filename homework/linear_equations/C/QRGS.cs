using System;
using System.Diagnostics;

public class QRGS{
	public matrix Q,R;
	public QRGS(matrix A){
	/* run the Gram-Schmidt process */
		Trace.Assert(A.size1 >= A.size2);
		count = 0;
		Q = A.copy();
		var m = Q.size2;
		R = new matrix(m,m);
		for(int i = 0; i < m; i++) {
			R[i,i] = Q[i].norm();
			Q[i] /= R[i,i];
			for(int j = i + 1; j < m; j++) {
				R[i,j] = Q[i]%Q[j];
				Q[j] -= Q[i]*R[i,j];
			}
		}
	}

	public vector solve(vector b){
	/* back-substitute Q^T*b */
		Trace.Assert(!(Q.size1 == Q.size2));
		matrix QT = Q.transpose();
		var x = QT*b;		
		for(int i = x.size - 1; i >= 0; i--) {
			double sum = 0;
			for(int k = i + 1; k < x.size; k++) {
				sum += R[i,k]*x[k];
			}
		x[i] = (x[i] - sum) / R[i,i];
		}
		return x;
	}
		
	public double determinant(){
	/* return Π_iRii */
		double r = 1;
		for(int i=0; i < R.size1; i++) {
			r = r*R[i,i];
		}
		return r;
	}

	public matrix inverse() {
	/* returns the inverse matrix*/
		int n = Q.size1, m = Q.size2;
		var B = new matrix(m,n);
		var x = new vector(n);
		for(int i = 0; i < n; i++) {
			x[i] = 1;
			B[i] = solve(x);
			x[i] = 0;
		}
		return B;
	}

	public int operationCount() {
	/*Counts number of operations for QR-decomposition of NxN matrix */
		Trace.Assert(!(Q.size1 == Q.size2));
		
	}
}
