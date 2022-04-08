using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(){
		double start = 0, end = 10;
		double m1 = 1;
		double m2 = 1;
		double m3 = 1;		

		Func<double, vector, vector> f = delegate(double t, vector y) {
			var x1 = new vector(y[0], y[1]);
			var v1 = new vector(y[2], y[3]);

			var x2 = new vector(y[4], y[5]);
			var v2 = new vector(y[6], y[7]);

			var x3 = new vector(y[8], y[9]);
			var v3 = new vector(y[10], y[11]); 
			
			var dv1dt = m2*(x2-x1)/Pow((x2-x1).norm(),3) + m3*(x3-x1)/Pow((x3-x1).norm(),3);
			var dv2dt = m1*(x1-x2)/Pow((x1-x2).norm(),3) + m3*(x3-x2)/Pow((x3-x2).norm(),3);
			var dv3dt = m1*(x3-x1)/Pow((x3-x1).norm(),3) + m2*(x2-x3)/Pow((x2-x3).norm(),3);

			double[] data = new double[12] {v1[0], v1[1], dv1dt[0], dv1dt[1], v2[0], v2[1], dv2dt[0], dv2dt[1], v3[0], v3[1], dv3dt[0], dv3dt[1]};
			return new vector(data);
		};

		//defining initial values

		double x11 = -0.9700436, x12 = 0.24308753, x21 = 0, x22 = 0;
		double x31 = -x11, x32 = -x12, v11 = 0.466203685, v12 = 0.432366573;
		double v21 = -0.93240737, v22 = -0.86473146, v31 = v11, v32 = v12;  

		double[] data0 = new double[12] {x11, x12, v11, v12, x21, x22, v21, v22, x31, x32, v31, v32};
		vector y0 = new vector(data0);

		genlist<double> xs = new genlist<double>();
		genlist<vector> ys = new genlist<vector>();
		vector yend = ode.driver(f, start, y0, end, xs , ys);
		
		for(int i = 0; i < xs.size; i++) {
			Write($"{xs.data[i]} ");
			for(int j = 0; j < ys.data[0].size; j++) {
				Write($"{ys.data[i][j]} ");
			}
			Write("\n");
		}
	}
}
