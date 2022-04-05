odeIntManData.png: odeIntManData.txt odeIntManData.gpi Out.txt
	pyxplot odeIntManData.gpi

test.png: testData.txt test.gpi Out.txt
	pyxplot test.gpi

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs ode.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:ode.dll,matrix.dll,vector.dll

ode.dll: ode.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt *.png
