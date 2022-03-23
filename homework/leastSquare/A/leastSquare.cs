using System;

class leastSquare{
	vector x, y, dy;
	public leastSquare(vector x, vector y, vector dy) {
		this.x = x;
		this.y = y;
		this.dy = dy;
	}

	static (vector, matrix) lsfit {
		var fs = new Func<double,double>[] {z => 1.0, z => z};
		int n = x.size, m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i = 0; i < n; i++) {
			b[i] = y[i]/dy[i];
			for(int j = 0; j < m; j++) {
				A[i, k] = fs[k](x[i])/dy[i]
			}
		}
		var qrgs = new qrgs(A);
		vector c = qrgs.solve(b); //finding fitting values
		var chi2 = qrgs.inverse() * qrgs.inverse().T; //finding covariance matrix
		return (c, chi2);
	}
}
