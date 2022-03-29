all: Out.txt
	cat Out.txt

Out.txt: main.exe QRGS.cs
	mono $< > Out.txt

main.exe: main.cs QRGS.dll  matrix.dll vector.dll
	mcs $< -target:exe -reference:QRGS.dll,matrix.dll,vector.dll

QRGS.dll: QRGS.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt
