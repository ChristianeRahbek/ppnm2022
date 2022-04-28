Out.txt: main.exe
	mono $< >$@

main.exe: main.cs roots.dll vector.dll matrix.dll ode.dll
	mcs $< -target:exe -reference:roots.dll,vector.dll,matrix.dll,ode.dll

ode.dll: ode.cs vector.dll
	mcs $< -target:library -reference:vector.dll

roots.dll: roots.cs vector.dll matrix.dll QRGS.dll
	mcs $< -target:library -reference:vector.dll,matrix.dll,QRGS.dll

QRGS.dll: QRGS.cs vector.dll matrix.dll
	mcs $< -target:library -reference:vector.dll,matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt *.png
