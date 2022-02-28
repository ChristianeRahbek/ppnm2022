complex_gamma.pyxplot.png: erf.data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set xlabel "$$Re(z)$$" \n\
	set ylabel "$$Im(z)$$" \n\
	set zlabel "$$|Gamma(z)|$$" \n\
	set title "Gamma function" \n\
	set key below \n\
	plot 3d [-5: 5] [-5: 5] [0: 6] "$<" index 0 using 2:3:1 with surface title "Gamma function" \n\
	'| tee log.gpi | pyxplot

#add points manually to  erf.tab.txt file
#erf.tab.txt: Makefile
#	echo 0 0 1 > $@
#	echo *next values*

erf.data.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

CMATHDIR = ~/repos/ppnm2022/exercises/complex
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^
