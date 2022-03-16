

public class QRGS{
	public matrix Q,R;
	public QRGS(matrix A){
	/* run the Gram-Schmidt process */
		
	}

	public vector solve(vector b){
	/* back-substitute Q^T*b */
		matrix QT = Q.transpose();		
		
	}
		
	public double determinant(){
	/* return Π_iRii */
		double r = 1;
		for(int i=0; i < R.size1; i++) {
			r = r*R[i,i];
		}
		return r;
	}
}
