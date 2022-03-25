using System;

class times {
	void timesJ(matrix A, int p, int q, double theta) {
		double c=cos(theta), s=sin(theta);
		for(int i = 0; i < A.size1; i++) {
			double aip=A[i,p], aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}
	}
	
	void Jtimes(matrix A, int p, int q, double theta) {
		double c=cos(theta),s=sin(theta);
		for(int j = 0; j < A.size1; j++){
			double apj=A[p,j], aqj=A[q,j];
			A[p,j]= c*apj+s*aqj;
			A[q,j]=-s*apj+c*aqj;
		}
	}

	public void jacobiDiag(matrix A, matrix V) {
		bool changed;
		do {
			changed = false;
			for(int p = 0; p < n-1; p++) {
				for(int q = p + 1; q < n; q++){
					double apq = matrix.get(A, p, q);
					double app = matrix.get(A, p, p);
					double aqq = matrix.get(A, q, q);
					double theta =  0.5*atan2(a*apq, aqq-app);
					double c = cos(theta), s = sin(theta);
					double new_app = c*c*app - 2*s*c*apq + s*s*aqq;
					double new_aqq = s*s*app + 2*s*c*apq + c*c*aqq;
					if(new_app != app || new_aqq != aqq) {
						change = true;
						timesJ(A, p, q, theta);
						Jtimes(A, p, q, theta);
						timesJ(V, p, q, theta);
					}
				}
			}
		} while(changed);
	} 
}
