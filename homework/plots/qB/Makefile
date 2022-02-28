all:
	make gamma.pyxplot.png lngamma.pyxplot.png

gamma.pyxplot.png: erf.data.txt Makefile erf.tab.txt
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set xlabel "$$x$$" \n\
	set ylabel "$$y$$" \n\
	set title "Gamma function" \n\
	set key left top \n\
	plot [0: 5] [0: 10]"$<" index 0 using 1:2 with lines title "Gamma function",\ \n\
	"erf.tab.txt" index 0 using 1:2 with points pointtype 3 title "Tabulated values" \n\
	'| tee log.gpi | pyxplot

lngamma.pyxplot.png: erf.data.txt Makefile erf.tab.txt
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set xlabel "$$x$$" \n\
	set ylabel "$$y$$" \n\
	set title "Lngamma function" \n\
	set key left top \n\
	plot [0:5] [-1:5]"$<" index 0 using 1:3 with lines title "Ln gamma function",\ \n\
	"erf.tab.txt" index 0 using 1:3 with points pointtype 3 title "Tabulated values" \n\
	'| tee log.gpi | pyxplot


#add points manually to  erf.tab.txt file
#erf.tab.txt: Makefile
#	echo 0 0 1 > $@
#	echo *next values*

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
