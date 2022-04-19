Out.txt: main.exe
	mono $< >$@

main.exe: main.cs integrator.dll
	mcs $< -target:exe -reference:integrator.dll

integrator.dll: integrator.cs 
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt *.png
