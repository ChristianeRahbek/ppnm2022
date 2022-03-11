linterp.png: data.txt linterp.gpi
	pyxplot linterp.gpi

data.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll
	mcs -target:exe -reference:math.dll $<

math.dll: vector.cs integrate.cs
	mcs -target:library -out:./$@ $^
.PHONY:
clean:
	rm *.exe *.txt *.png
