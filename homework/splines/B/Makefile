linterp.png: data.txt plots.gpi
	pyxplot plots.gpi

data.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll
	mcs -target:exe -reference:math.dll $<

math.dll: qspline.cs integrate.cs
	mcs -target:library -out:./$@ $^
.PHONY:
clean:
	rm *.exe *.txt *.png
