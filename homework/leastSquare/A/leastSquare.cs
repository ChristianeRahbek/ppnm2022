using System;

public class lsfit{
	public vector c;
	public matrix cov;
	public Func<double, double>[] fs;
	public lsfit(vector x, vector y, vector dy, Func<double,double>[] f) {
		f = fs;
		int n = x.size, m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i = 0; i < n; i++) {
			b[i] = y[i]/dy[i];
			for(int j = 0; j < m; j++) {
				A[i, j] = fs[j](x[i])/dy[i];
			}
		}
		var qrgs = new QRGS(A);
		c = qrgs.solve(b); //finding fitting values
		cov = qrgs.inverse() * qrgs.inverse().T; //finding covariance matrix
	}

	public double eval(double x) {
		double fitfunc = 0;
		for(int i = 0; i <= fs.Length; i++) {
			fitfunc += c[i]*fs[i](x);
		}
		return fitfunc;
	}
}
