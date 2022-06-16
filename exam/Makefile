all: Out.txt scaling.png
	cat Out.txt

scaling.png: scaling.gpi scaling.txt Out.txt
	pyxplot $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs rayleigh.dll qn.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:rayleigh.dll,qn.dll,matrix.dll,vector.dll

qn.dll: qn.cs rayleigh.dll matrix.dll vector.dll
	mcs $< -target:library -reference:rayleigh.dll,matrix.dll,vector.dll

rayleigh.dll: rayleigh.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt
