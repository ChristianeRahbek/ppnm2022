fit.png: fit_data.txt fit.gpi
	pyxplot fit.gpi

fit_data.txt: main.exe
	mono  $<

main.exe: main.cs leastSquare.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:leastSquare.dll,matrix.dll,vector.dll

leastSquare.dll: leastSquare.cs QRGS.dll  matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll,QRGS.dll

QRGS.dll: QRGS.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	em *.exe *.txt *.png
