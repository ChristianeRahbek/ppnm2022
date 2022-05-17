ann.png: ann.gpi Out.txt
	pyxplot $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs vector.dll nn.dll qn.dll
	mcs $< -target:exe -reference:vector.dll,nn.dll,qn.dll

nn.dll: nn.cs vector.dll qn.dll
	mcs $< -target:library -reference:vector.dll,qn.dll

qn.dll: qn.cs vector.dll matrix.dll
	mcs $< -target:library -reference:vector.dll,matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library
