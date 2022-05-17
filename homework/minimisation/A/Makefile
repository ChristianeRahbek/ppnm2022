all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs qn.dll vector.dll matrix.dll
	mcs $< -target:exe -reference:qn.dll,vector.dll,matrix.dll

qn.dll: qn.cs vector.dll matrix.dll
	mcs $< -target:library -reference:vector.dll,matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt
