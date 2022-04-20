Out.txt: main.exe
	mono $< >$@

main.exe: main.cs multIntegration.dll vector.dll
	mcs $< -target:exe -reference:multIntegration.dll,vector.dll

multIntegration.dll: multIntegration.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt *.png
