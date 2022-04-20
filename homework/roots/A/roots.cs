using System;
using static System.Math;

public class roots{
	public static vector newton(Func<vector,vector> f, vector x0, double eps = 1e-2) {
		int n = x0.size;
		vector fx = f(x0);
		vector x1, fx1;
		while(true) {
			var J = jacobian(f, x0, fx);
			var qrgs = new QRGS(J);
			var invJ = qrgs.inverse();
			vector dx = -invJ*fx;
			double s = 1;
			while(true) {
				x1 = x0 + dx*s;
				fx1 = f(x1);
				if(fx1.norm() < (1 - s)/2*fx.norm() || s < 1.0/32) {
					break;
				}
				s /= 2;
			}
			x0 = x1;
			fx = fx1;
			if(fx.norm() < eps) break;
		}
		return x0;
	}

	public static matrix jacobian(Func<vector,vector> f, vector x, vector fx = null, double dx = 1e-7) {
		int n = x.size;
		matrix J = new matrix(n,n);
		if(fx == null) fx = f(x);
		for(int i = 0; i < n; i++) {
			x[i] += dx;
			vector df = f(x) - fx;
			for(int j = 0; j < n; j++){
				J[j, i] = df[j] / dx;
			}
			x[i] -= dx;
		}
		return J;
	}
}
