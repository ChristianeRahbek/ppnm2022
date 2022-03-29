using System;
using static System.Console;
using static System.Math;

public class lsfit{
	public vector c;
	public matrix cov;
	public Func<double, double>[] fs;
	public lsfit(vector x, vector y, vector dy, Func<double,double>[] f) {
		fs = f;
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

	public Tuple<double, double, double> eval(double x) {
		double fitfunc = 0, fitfuncPlus = 0, fitfuncMinus = 0;
		for(int i = 0; i < fs.Length; i++) {
			fitfunc += c[i]*fs[i](x);
			fitfuncPlus += (c[i] + c[i]*Sqrt(cov[i,i]))*fs[i](x);
			fitfuncMinus += (c[i] - c[i]*Sqrt(cov[i,i]))*fs[i](x);
		}
		var fitfuncs = new Tuple<double, double, double>(fitfunc, fitfuncPlus, fitfuncMinus);
		return fitfuncs;
	}
}
