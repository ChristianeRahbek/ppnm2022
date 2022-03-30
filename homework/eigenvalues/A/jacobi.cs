using System;
using static System.Math;
using static System.Console;

public class jacobi {
	static void timesJ(matrix A, int p, int q, double theta) {
		double c = Cos(theta), s = Sin(theta);
		for(int i = 0; i < A.size1; i++) {
			double aip=A[i,p], aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}
	}
	
	static void Jtimes(matrix A, int p, int q, double theta) {
		double c = Cos(theta), s = Sin(theta);
		for(int j = 0; j < A.size1; j++){
			double apj=A[p,j], aqj=A[q,j];
			A[p,j]= c*apj+s*aqj;
			A[q,j]=-s*apj+c*aqj;
		}
	}

	static public (vector, matrix) cyclic(matrix A) {
		bool changed;
		int n = A.size1;
		vector e = new vector(n);
		matrix V = new matrix(n, A.size2);

		for(int i = 0; i < n; i++) {
			e[i] = A[i,i];
			V[i, i]= 1.0;
			for(int j = i + 1; j < n; j++) {
				V[i,j] = 0;
				V[j,i] = 0;
			}
		}

	
		do {
			changed = false;
			for(int p = 0; p < n-1; p++) {
				for(int q = p + 1; q < n; q++){
					double apq = matrix.get(A, p, q);
					double app = matrix.get(A, p, p);
					double aqq = matrix.get(A, q, q);
					double theta =  0.5*Atan2(2*apq, aqq-app);
					double c = Cos(theta), s = Sin(theta);
					double new_app = c*c*app - 2*s*c*apq + s*s*aqq;
					double new_aqq = s*s*app + 2*s*c*apq + c*c*aqq;
					if(new_app != app || new_aqq != aqq) {
						changed = true;
						e[p] = new_app;
						e[q] = new_aqq;
						timesJ(A, p, q, theta);
						Jtimes(A, p, q, -theta);
						timesJ(V, p, q, theta);
					}
				}
			}
		} while(changed);
	return (e, V);
	} 
}
