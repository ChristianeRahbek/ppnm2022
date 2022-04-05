Hydrogen.png: hydrogen.gpi Out.txt
	pyxplot $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs jacobi.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:jacobi.dll,matrix.dll,vector.dll

jacobi.dll: jacobi.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

