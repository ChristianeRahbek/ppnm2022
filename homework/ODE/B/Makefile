odeIntManData.png: Out.txt odeIntManData.gpi
	pyxplot odeIntManData.gpi

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs ode.dll matrix.dll vector.dll genlist.dll
	mcs $< -target:exe -reference:ode.dll,matrix.dll,vector.dll,genlist.dll

ode.dll: ode.cs matrix.dll vector.dll genlist.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll,genlist.dll

genlist.dll: genlist.cs
	mcs $< -target:library 

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt *.png
